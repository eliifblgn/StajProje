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
    [Authorize]
    public class IadeController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public IadeController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: Iade
        public async Task<IActionResult> Index()
        {
            var ıade = _context.Iade
               .Include(p => p.Personel)
               .Where(e => e.Silindi == false)
               .ToList();
            return View(ıade.ToList());
        }

        // GET: Iade/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var iade = await _context.Iade
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (iade == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(iade);
        //}

        // GET: Iade/Create
        public IActionResult Create()
        {
            var personelList = _context.Personel
               .Where(p => p.Silindi == false)
               .ToList();
            ViewData["PersonelId"] = new SelectList(personelList, "Id", "AdSoyad");
            //ViewBag.EnvanterDurumu = new SelectList(Enum.GetNames(typeof(EnvanterDurumu))
            //    //.Cast<EnvanterDurumu>()
            //    .Select(e => new { Id = e, Name = e.ToString() }), "Id", "Name");
            var envanterDurumuList = Enum.GetValues(typeof(EnvanterDurumu)).OfType<EnvanterDurumu>()
             .Select(e => new SelectListItem
             {
                   Value = ((int)e).ToString(),
                   Text = e.DisplayName()
             }).ToList();
            ViewData["EnvanterDurumu"] = new SelectList(envanterDurumuList, "Value", "Text");
            return View();
        }

        // POST: Iade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Iade iade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var personelList = _context.Personel
                 .Where(p => p.Silindi == false)
                 .ToList();
            ViewData["PersonelId"] = new SelectList(personelList, "Id", "AdSoyad");
            //ViewBag.EnvanterDurumu = new SelectList(Enum.GetNames(typeof(EnvanterDurumu))
            // .Cast<EnvanterDurumu>()
            //.Select(e => new { Id = e, Name = e.ToString() }), "Id", "Name");
            var envanterDurumuList = Enum.GetValues(typeof(EnvanterDurumu)).OfType<EnvanterDurumu>()
             .Select(e => new SelectListItem
             {
                   Value = ((int)e).ToString(),
                   Text = e.DisplayName()
             }).ToList();

            ViewData["EnvanterDurumu"] = new SelectList(envanterDurumuList, "Value", "Text");
           
            return View(iade);
        }

        // GET: Iade/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var iade = await _context.Iade.FindAsync(id);
        //    if (iade == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(iade);
        //}

        // POST: Iade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id,Iade iade)
        //{
        //    if (id != iade.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(iade);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!IadeExists(iade.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(iade);
        //}

        // GET: Iade/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var iade = await _context.Iade
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (iade == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(iade);
        //}

        // GET: Birim/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var silinecek = await _context.Birim.FindAsync(id);
        //    if (silinecek == null)
        //    {
        //        return NotFound();
        //    }

        //    silinecek.Silindi = true;
        //    _context.Update(silinecek);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool IadeExists(long id)
        //{
        //    return _context.Iade.Any(e => e.Id == id);
        //}
    }
}
