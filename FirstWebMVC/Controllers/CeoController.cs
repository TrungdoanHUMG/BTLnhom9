using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class CeoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CeoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ceo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ceo.Include(c => c.HopDong).Include(c => c.Luong);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ceo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceo
                .Include(c => c.HopDong)
                .Include(c => c.Luong)
                .FirstOrDefaultAsync(m => m.CeoID == id);
            if (ceo == null)
            {
                return NotFound();
            }

            return View(ceo);
        }

        // GET: Ceo/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID");
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID");
            return View();
        }

        // POST: Ceo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CeoID,CeoName,CeoPhoneNumber,CeoAddress,CeoBirth,CeoSex,CeoBank,CeoCCCD,ViTriCeoID,LuongID,HopDongID,CeoStart,CeoEnd")] Ceo ceo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ceo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", ceo.LuongID);
            return View(ceo);
        }

        // GET: Ceo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceo.FindAsync(id);
            if (ceo == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", ceo.LuongID);
            return View(ceo);
        }

        // POST: Ceo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CeoID,CeoName,CeoPhoneNumber,CeoAddress,CeoBirth,CeoSex,CeoBank,CeoCCCD,ViTriCeoID,LuongID,HopDongID,CeoStart,CeoEnd")] Ceo ceo)
        {
            if (id != ceo.CeoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ceo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CeoExists(ceo.CeoID))
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
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", ceo.LuongID);
            return View(ceo);
        }

        // GET: Ceo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceo
                .Include(c => c.HopDong)
                .Include(c => c.Luong)
                .FirstOrDefaultAsync(m => m.CeoID == id);
            if (ceo == null)
            {
                return NotFound();
            }

            return View(ceo);
        }

        // POST: Ceo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ceo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ceo'  is null.");
            }
            var ceo = await _context.Ceo.FindAsync(id);
            if (ceo != null)
            {
                _context.Ceo.Remove(ceo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CeoExists(string id)
        {
          return (_context.Ceo?.Any(e => e.CeoID == id)).GetValueOrDefault();
        }
    }
}
