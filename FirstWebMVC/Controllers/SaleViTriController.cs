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
    public class SaleViTriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleViTriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleViTri
        public async Task<IActionResult> Index()
        {
              return _context.SaleViTri != null ? 
                          View(await _context.SaleViTri.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SaleViTri'  is null.");
        }

        // GET: SaleViTri/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SaleViTri == null)
            {
                return NotFound();
            }

            var saleViTri = await _context.SaleViTri
                .FirstOrDefaultAsync(m => m.ViTriSaleID == id);
            if (saleViTri == null)
            {
                return NotFound();
            }

            return View(saleViTri);
        }

        // GET: SaleViTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleViTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViTriSaleID,VitriSale")] SaleViTri saleViTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleViTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleViTri);
        }

        // GET: SaleViTri/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SaleViTri == null)
            {
                return NotFound();
            }

            var saleViTri = await _context.SaleViTri.FindAsync(id);
            if (saleViTri == null)
            {
                return NotFound();
            }
            return View(saleViTri);
        }

        // POST: SaleViTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ViTriSaleID,VitriSale")] SaleViTri saleViTri)
        {
            if (id != saleViTri.ViTriSaleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleViTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleViTriExists(saleViTri.ViTriSaleID))
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
            return View(saleViTri);
        }

        // GET: SaleViTri/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SaleViTri == null)
            {
                return NotFound();
            }

            var saleViTri = await _context.SaleViTri
                .FirstOrDefaultAsync(m => m.ViTriSaleID == id);
            if (saleViTri == null)
            {
                return NotFound();
            }

            return View(saleViTri);
        }

        // POST: SaleViTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SaleViTri == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SaleViTri'  is null.");
            }
            var saleViTri = await _context.SaleViTri.FindAsync(id);
            if (saleViTri != null)
            {
                _context.SaleViTri.Remove(saleViTri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleViTriExists(string id)
        {
          return (_context.SaleViTri?.Any(e => e.ViTriSaleID == id)).GetValueOrDefault();
        }
    }
}
