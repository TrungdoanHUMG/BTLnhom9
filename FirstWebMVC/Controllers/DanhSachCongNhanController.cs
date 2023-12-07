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
    public class DanhSachCongNhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhSachCongNhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhSachCongNhan
        public async Task<IActionResult> Index()
        {
              return _context.DanhSachCongNhan != null ? 
                          View(await _context.DanhSachCongNhan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DanhSachCongNhan'  is null.");
        }

        // GET: DanhSachCongNhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhSachCongNhan == null)
            {
                return NotFound();
            }

            var danhSachCongNhan = await _context.DanhSachCongNhan
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (danhSachCongNhan == null)
            {
                return NotFound();
            }

            return View(danhSachCongNhan);
        }

        // GET: DanhSachCongNhan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhSachCongNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,FullName,Vitri,Luong,Trangthai")] DanhSachCongNhan danhSachCongNhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhSachCongNhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhSachCongNhan);
        }

        // GET: DanhSachCongNhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhSachCongNhan == null)
            {
                return NotFound();
            }

            var danhSachCongNhan = await _context.DanhSachCongNhan.FindAsync(id);
            if (danhSachCongNhan == null)
            {
                return NotFound();
            }
            return View(danhSachCongNhan);
        }

        // POST: DanhSachCongNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,FullName,Vitri,Luong,Trangthai")] DanhSachCongNhan danhSachCongNhan)
        {
            if (id != danhSachCongNhan.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhSachCongNhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhSachCongNhanExists(danhSachCongNhan.MaNV))
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
            return View(danhSachCongNhan);
        }

        // GET: DanhSachCongNhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhSachCongNhan == null)
            {
                return NotFound();
            }

            var danhSachCongNhan = await _context.DanhSachCongNhan
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (danhSachCongNhan == null)
            {
                return NotFound();
            }

            return View(danhSachCongNhan);
        }

        // POST: DanhSachCongNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhSachCongNhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhSachCongNhan'  is null.");
            }
            var danhSachCongNhan = await _context.DanhSachCongNhan.FindAsync(id);
            if (danhSachCongNhan != null)
            {
                _context.DanhSachCongNhan.Remove(danhSachCongNhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhSachCongNhanExists(string id)
        {
          return (_context.DanhSachCongNhan?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
}
