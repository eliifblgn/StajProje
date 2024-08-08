using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize(Policy ="AdminOnly")]
    public class KkdEnvanterTakipController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public KkdEnvanterTakipController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: 
        public async Task<IActionResult> Index()
        {
            var secKaliteDbDbContext = _context.KkdEnvanterTakip
                .Include(p => p.Personel)
                .Include(p => p.BedenNumara)
                .Include(p => p.KkdGrubu)
                .Include(p => p.KkdNiteligi)
                .Include(p => p.Birim)
                .Where(p => p.Silindi == false);
            return View(secKaliteDbDbContext);
        }

        //// GET: 
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kkdet = await _context.KkdEnvanterTakip
        //        .Include(p => p.Personel)
        //        .Include(p => p.BedenNumara)
        //        .Include(p => p.KkdGrubu)
        //        .Include(p => p.KkdNiteligi)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (kkdet == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(kkdet);

        public IActionResult GetKkdNiteligi(long kkdGrubuId)
        {
            var nitelikler = _context.KkdNiteligi
            .Where(n => n.KkdGrubuId == kkdGrubuId)
            .ToList();

            if (nitelikler == null || !nitelikler.Any())
            {
                return NotFound();
            }

            return Json(nitelikler.Select(n => new
            {
                id = n.Id,
                nitelikAdi = n.KkdNiteligiAdi
            }));
        }

        // GET: KKDEnvanterTakip/Create
        public IActionResult Create()
        {
            
            var personelList = _context.Personel
                .Where(p => p.Silindi == false) 
                .ToList();

            var bedenNumaraList = _context.BedenNumara
                .Where(p => p.Silindi == false) 
                .ToList();

            var kkdGrubuList = _context.KkdGrubu
                .Where(p => p.Silindi == false) 
                .ToList();

            var kkdNiteligiList = _context.KkdNiteligi
                .Where(p => p.Silindi == false) 
                .ToList();
            
            var birimList = _context.Birim
                .Where(p => p.Silindi == false) 
                .ToList();

                ViewBag.PersonelId = new SelectList(personelList, "Id", "AdSoyad");
                ViewBag.BedenNumaraId = new SelectList(bedenNumaraList, "Id", "Beden");
                ViewBag.KkdGrubuId = new SelectList(kkdGrubuList, "Id", "KkdGrubuAdi");
                ViewBag.KkdNiteligiId = new SelectList(kkdNiteligiList, "Id", "KkdNiteligiAdi");
                ViewBag.BirimId = new SelectList(birimList, "Id","BirimAdi");
            return View();
            }

             // POST: KKDEnvanterTakip/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(KkdEnvanterTakip kkdet)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(kkdet);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            var personelList = _context.Personel
                .Where(p => p.Silindi == false)
                .ToList();

            var bedenNumaraList = _context.BedenNumara
                .Where(p => p.Silindi == false)
                .ToList();

            var kkdGrubuList = _context.KkdGrubu
                .Where(p => p.Silindi == false)
                .ToList();

            var kkdNiteligiList = _context.KkdNiteligi
                .Where(p => p.Silindi == false) 
                .ToList();

            var birimList = _context.Birim
                .Where(p => p.Silindi == false) 
                .ToList();

                ViewBag.PersonelId = new SelectList(personelList, "Id", "AdSoyad", kkdet.PersonelId);
                ViewBag.BedenNumaraId = new SelectList(bedenNumaraList, "Id", "Beden", kkdet.BedenNumaraId);
                ViewBag.KkdGrubuId = new SelectList(kkdGrubuList, "Id", "KkdGrubuAdi", kkdet.KkdGrubuId);
                ViewBag.KkdNiteligiId = new SelectList(kkdNiteligiList, "Id", "KkdNiteligiAdi", kkdet.KkdNiteligiId);
                ViewBag.BirimId = new SelectList(birimList, "Id", "BirimAdi", kkdet.BirimId);
            return View(kkdet);
            }

            //// GET: 
            //public async Task<IActionResult> Edit(long? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var kkdet = await _context.KkdEnvanterTakip.FindAsync(id);
            //    if (kkdet == null)
            //    {
            //        return NotFound();
            //    }
            //    ViewData["PersonelId"] = new SelectList(_context.Personel, "Id", "PersonelAdi");
            //    ViewData["BedenNumaraId"] = new SelectList(_context.BedenNumara, "Id", "BedenNumara");
            //    ViewData["KkdGrubuId"] = new SelectList(_context.KkdGrubu, "Id", "KkdGrubu");
            //    ViewData["KkdNiteligiId"] = new SelectList(_context.KkdNiteligi, "Id", "KkdNiteligi");
            //    return View(kkdet);
            //}

            ////POST: 
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Edit(long id, [Bind()] KkdEnvanterTakip kkdet)
            //{
            //    if (id != kkdet.Id)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(kkdet);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!KkdEnvanterTakipExists(kkdet.Id))
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
            //    ViewData["PersonelId"] = new SelectList(_context.Personel, "Id", "PersonelAdi");
            //    ViewData["BedenNumaraId"] = new SelectList(_context.BedenNumara, "Id", "BedenNumara");
            //    ViewData["KkdGrubuId"] = new SelectList(_context.KkdGrubu, "Id", "KkdGrubu");
            //    ViewData["KkdNiteligiId"] = new SelectList(_context.KkdNiteligi, "Id", "KkdNiteligi");
            //    return View(kkdet);
            //}

            ////// GET: 
            //public async Task<IActionResult> Delete(long? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var kkdet = await _context.KkdEnvanterTakip
            //        .Include(p => p.Personel)
            //        .Include(p => p.BedenNumara)
            //        .Include(p => p.KkdGrubu)
            //        .Include(p => p.KkdNiteligi)
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (kkdet == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(kkdet);
            //}

            ////// POST: 
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(long id)
            //{
            //    var kkdet = await _context.KkdEnvanterTakip.FindAsync(id);
            //    if (kkdet != null)
            //    {
            //        kkdet.Silindi = true;
            //        _context.KkdEnvanterTakip.Update(kkdet);
            //    }

            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //private bool KkdEnvanterTakipExists(long id)
            //{
            //    return _context.KkdEnvanterTakip.Any(e => e.Id == id);
            //}
        }
    }


