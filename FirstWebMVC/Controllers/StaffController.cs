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
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Staff.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.StaffViTri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.StaffViTri)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID");
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID");
            ViewData["ViTriStaffID"] = new SelectList(_context.StaffViTri, "ViTriStaffID", "ViTriStaffID");
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,StaffName,StaffPhoneNumber,StaffAddress,StaffBirth,StaffSex,StaffBank,StaffCCCD,ViTriStaffID,LuongID,HopDongID,StaffStart,StaffEnd")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", staff.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", staff.LuongID);
            ViewData["ViTriStaffID"] = new SelectList(_context.StaffViTri, "ViTriStaffID", "ViTriStaffID", staff.ViTriStaffID);
            return View(staff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", staff.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", staff.LuongID);
            ViewData["ViTriStaffID"] = new SelectList(_context.StaffViTri, "ViTriStaffID", "ViTriStaffID", staff.ViTriStaffID);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StaffID,StaffName,StaffPhoneNumber,StaffAddress,StaffBirth,StaffSex,StaffBank,StaffCCCD,ViTriStaffID,LuongID,HopDongID,StaffStart,StaffEnd")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            ViewData["HopDongID"] = new SelectList(_context.HopDong, "HopDongID", "HopDongID", staff.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Luong, "LuongID", "LuongID", staff.LuongID);
            ViewData["ViTriStaffID"] = new SelectList(_context.StaffViTri, "ViTriStaffID", "ViTriStaffID", staff.ViTriStaffID);
            return View(staff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.StaffViTri)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Staff'  is null.");
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(string id)
        {
          return (_context.Staff?.Any(e => e.StaffID == id)).GetValueOrDefault();
        }
    }
}
