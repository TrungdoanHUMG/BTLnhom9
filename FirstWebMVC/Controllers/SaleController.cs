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
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sale
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sale.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.SaleViTri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sale/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.SaleViTri)
                .FirstOrDefaultAsync(m => m.SaleID == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sale/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID");
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID");
            ViewData["ViTriSaleID"] = new SelectList(_context.SaleViTri, "ViTriSaleID", "ViTriSaleID");
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleID,SaleName,SalePhoneNumber,SaleAddress,SaleBirth,SaleSex,SaleBank,SaleCCCD,ViTriSaleID,LuongID,HopDongID,SaleStart,SaleEnd")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.SaleViTri, "ViTriSaleID", "ViTriSaleID", sale.ViTriSaleID);
            return View(sale);
        }

        // GET: Sale/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.SaleViTri, "ViTriSaleID", "ViTriSaleID", sale.ViTriSaleID);
            return View(sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SaleID,SaleName,SalePhoneNumber,SaleAddress,SaleBirth,SaleSex,SaleBank,SaleCCCD,ViTriSaleID,LuongID,HopDongID,SaleStart,SaleEnd")] Sale sale)
        {
            if (id != sale.SaleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleID))
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
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.SaleViTri, "ViTriSaleID", "ViTriSaleID", sale.ViTriSaleID);
            return View(sale);
        }

        // GET: Sale/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.SaleViTri)
                .FirstOrDefaultAsync(m => m.SaleID == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sale'  is null.");
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale != null)
            {
                _context.Sale.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(string id)
        {
          return (_context.Sale?.Any(e => e.SaleID == id)).GetValueOrDefault();
        }
    }
}
