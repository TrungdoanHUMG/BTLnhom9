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
    public class StaffViTriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffViTriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffViTri
        public async Task<IActionResult> Index()
        {
              return _context.StaffViTri != null ? 
                          View(await _context.StaffViTri.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StaffViTri'  is null.");
        }

        // GET: StaffViTri/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.StaffViTri == null)
            {
                return NotFound();
            }

            var staffViTri = await _context.StaffViTri
                .FirstOrDefaultAsync(m => m.ViTriStaffID == id);
            if (staffViTri == null)
            {
                return NotFound();
            }

            return View(staffViTri);
        }

        // GET: StaffViTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffViTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViTriStaffID,VitriStaff")] StaffViTri staffViTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffViTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffViTri);
        }

        // GET: StaffViTri/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.StaffViTri == null)
            {
                return NotFound();
            }

            var staffViTri = await _context.StaffViTri.FindAsync(id);
            if (staffViTri == null)
            {
                return NotFound();
            }
            return View(staffViTri);
        }

        // POST: StaffViTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ViTriStaffID,VitriStaff")] StaffViTri staffViTri)
        {
            if (id != staffViTri.ViTriStaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffViTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffViTriExists(staffViTri.ViTriStaffID))
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
            return View(staffViTri);
        }

        // GET: StaffViTri/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.StaffViTri == null)
            {
                return NotFound();
            }

            var staffViTri = await _context.StaffViTri
                .FirstOrDefaultAsync(m => m.ViTriStaffID == id);
            if (staffViTri == null)
            {
                return NotFound();
            }

            return View(staffViTri);
        }

        // POST: StaffViTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.StaffViTri == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StaffViTri'  is null.");
            }
            var staffViTri = await _context.StaffViTri.FindAsync(id);
            if (staffViTri != null)
            {
                _context.StaffViTri.Remove(staffViTri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffViTriExists(string id)
        {
          return (_context.StaffViTri?.Any(e => e.ViTriStaffID == id)).GetValueOrDefault();
        }
    }
}
