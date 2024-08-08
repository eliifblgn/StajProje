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
    public class KkdGrubuController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public KkdGrubuController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: KkdGrubu
        public async Task<IActionResult> Index()
        {
            return View(await _context.KkdGrubu
                .Where(e=>e.Silindi==false)
                .ToListAsync());
        }

        // GET: KkdGrubu/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kkdGrubu = await _context.KkdGrubu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kkdGrubu == null)
            {
                return NotFound();
            }

            return View(kkdGrubu);
        }

        // GET: KkdGrubu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KkdGrubu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KkdGrubu kkdGrubu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kkdGrubu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kkdGrubu);
        }

        // GET: KkdGrubu/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kkdGrubu = await _context.KkdGrubu.FindAsync(id);
            if (kkdGrubu == null)
            {
                return NotFound();
            }
            return View(kkdGrubu);
        }

        // POST: KkdGrubu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,KkdGrubu kkdGrubu)
        {
            if (id != kkdGrubu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = await _context.KkdGrubu.FindAsync(id);
                if (guncellenecek == null)
                {
                    return NotFound();
                }

                guncellenecek.KkdGrubuAdi = kkdGrubu.KkdGrubuAdi;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kkdGrubu);
        }

        // GET: KkdGrubu/Delete/5
        public async Task<IActionResult> Delete(long? id, KkdGrubu kkdGrubu)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silinecek = await _context.KkdGrubu.FindAsync(id);
            if (silinecek == null)
            {
                return NotFound();
            }

            silinecek.Silindi = true;
            _context.KkdGrubu.Update(silinecek);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private bool KkdGrubuExists(long id)
        {
            return _context.KkdGrubu.Any(e => e.Id == id);
        }
    }
}
