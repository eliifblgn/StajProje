using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class PersonelController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public PersonelController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: Personel
        public async Task<IActionResult> Index()
        {
            var secKaliteDbDbContext = _context.Personel
                .Include(p => p.PersonelBirim)
                .Include(p => p.Unvan)
                .Where(p=>p.Silindi==false);
            return View(await secKaliteDbDbContext.ToListAsync());
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .Include(p => p.PersonelBirim)
                .Include(p => p.Unvan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personel/Create
        public async Task<IActionResult> Create()
        {
            var personelBirimlList = _context.PersonelBirim
                .Where(p => p.Silindi == false)
                .ToList();
            var unvanList = _context.Unvan
                .Where(p => p.Silindi == false)
                .ToList();

            ViewBag.BirimId = new SelectList(personelBirimlList ,"Id", "BirimAdi");
            ViewBag.UnvanId = new SelectList(unvanList, "Id", "UnvanAdi");
            return View();
        }

        // POST: Personel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var personelBirimlList = _context.PersonelBirim
                .Where(p => p.Silindi == false)
                .ToList();
            var unvanList = _context.Unvan
                .Where(p => p.Silindi == false)
                .ToList();

            ViewBag.BirimId = new SelectList(personelBirimlList, "Id", "BirimAdi");
            ViewBag.UnvanId = new SelectList(unvanList, "Id", "UnvanAdi");
            return View(personel);
        }


        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                   .Include(p => p.PersonelBirim)
                   .Include(p => p.Unvan)
                   .FirstOrDefaultAsync(p => p.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            var personelBirimlList = _context.PersonelBirim
               .Where(p => p.Silindi == false)
               .ToList();
            var unvanList = _context.Unvan
                .Where(p => p.Silindi == false)
                .ToList();

            //ViewData["BirimId"] = new SelectList(personelBirimlList, "Id", "BirimAdi");
            //ViewData["UnvanId"] = new SelectList(unvanList, "Id", "UnvanAdi");
            //ViewBag.BirimId = new SelectList(await _context.PersonelBirim.ToListAsync(), "Id", "BirimAdi");
            //ViewBag.UnvanId = new SelectList(await _context.Unvan.ToListAsync(), "Id", "UnvanAdi");

            ViewBag.BirimId = personelBirimlList.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.BirimAdi
            }).ToList();

            ViewBag.UnvanId = unvanList.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.UnvanAdi
            }).ToList();

            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Personel personel)
        {
            if (id != personel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var personelBirimlList = _context.PersonelBirim
                .Where(p => p.Silindi == false)
                .ToList();
            var unvanList = _context.Unvan
                .Where(p => p.Silindi == false)
                .ToList();

            //ViewData["BirimId"] = new SelectList(personelBirimlList, "Id", "BirimAdi");
            //ViewData["UnvanId"] = new SelectList(unvanList, "Id", "UnvanAdi");
            //ViewBag.BirimId = new SelectList(await _context.PersonelBirim.ToListAsync(), "Id", "BirimAdi");
            //ViewBag.UnvanId = new SelectList(await _context.Unvan.ToListAsync(), "Id", "UnvanAdi");

            ViewBag.BirimId = personelBirimlList.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.BirimAdi
            }).ToList();

            ViewBag.UnvanId = unvanList.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.UnvanAdi
            }).ToList();

            return View(personel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete (long? id)
        {
            var silinecek = _context.Personel.Find(id);
            if (silinecek != null)
            {
                silinecek.Silindi = true;
                _context.SaveChangesAsync();
            }
                return RedirectToAction("Index"); 
        }
      

        private bool PersonelExists(long id)
        {
            return _context.Personel.Any(e => e.Id == id);
        }
    }
}
