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
    public class LuongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LuongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Luong
        public async Task<IActionResult> Index()
        {
              return _context.Luong != null ? 
                          View(await _context.Luong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Luong'  is null.");
        }

        // GET: Luong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Luong == null)
            {
                return NotFound();
            }

            var luong = await _context.Luong
                .FirstOrDefaultAsync(m => m.LuongID == id);
            if (luong == null)
            {
                return NotFound();
            }

            return View(luong);
        }

        // GET: Luong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Luong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LuongID,SoLuong")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luong);
        }

        // GET: Luong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Luong == null)
            {
                return NotFound();
            }

            var luong = await _context.Luong.FindAsync(id);
            if (luong == null)
            {
                return NotFound();
            }
            return View(luong);
        }

        // POST: Luong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LuongID,SoLuong")] Luong luong)
        {
            if (id != luong.LuongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuongExists(luong.LuongID))
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
            return View(luong);
        }

        // GET: Luong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Luong == null)
            {
                return NotFound();
            }

            var luong = await _context.Luong
                .FirstOrDefaultAsync(m => m.LuongID == id);
            if (luong == null)
            {
                return NotFound();
            }

            return View(luong);
        }

        // POST: Luong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Luong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Luong'  is null.");
            }
            var luong = await _context.Luong.FindAsync(id);
            if (luong != null)
            {
                _context.Luong.Remove(luong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuongExists(string id)
        {
          return (_context.Luong?.Any(e => e.LuongID == id)).GetValueOrDefault();
        }
    }
}
