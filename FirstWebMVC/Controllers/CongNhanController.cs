using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.Models.Process;

namespace FirstWebMVC.Controllers
{
    public class CongNhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CongNhanController(ApplicationDbContext context)
        {
            _context = context;
        }
        private ExcelProcess _excelProcess = new ExcelProcess();
        // GET: CongNhan
        public async Task<IActionResult> Index()
        {
              return _context.CongNhan != null ? 
                          View(await _context.CongNhan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CongNhan'  is null.");
        }

        // GET: CongNhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhan == null)
            {
                return NotFound();
            }

            return View(congNhan);
        }

        // GET: CongNhan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CongNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,PhongBan,ViTri,Luong,TrangThai")] CongNhan congNhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congNhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congNhan);
        }

        // GET: CongNhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan.FindAsync(id);
            if (congNhan == null)
            {
                return NotFound();
            }
            return View(congNhan);
        }

        // POST: CongNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,PhongBan,ViTri,Luong,TrangThai")] CongNhan congNhan)
        {
            if (id != congNhan.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congNhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongNhanExists(congNhan.MaCongNhan))
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
            return View(congNhan);
        }

        // GET: CongNhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhan == null)
            {
                return NotFound();
            }

            return View(congNhan);
        }

        // POST: CongNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CongNhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CongNhan'  is null.");
            }
            var congNhan = await _context.CongNhan.FindAsync(id);
            if (congNhan != null)
            {
                _context.CongNhan.Remove(congNhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng lặp for để đọc dữ liệu dạng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var hd = new CongNhan();
                            //set values for attribiutes
                            hd.MaCongNhan = dt.Rows[i][0].ToString();
                            hd.PhongBan = dt.Rows[i][1].ToString();
                            hd.ViTri = dt.Rows[i][2].ToString();
                            hd.Luong = dt.Rows[i][3].ToString();
                            hd.TrangThai = dt.Rows[i][4].ToString();
                            //add oject to context
                            _context.CongNhan.Add(hd);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
        private bool CongNhanExists(string id)
        {
          return (_context.CongNhan?.Any(e => e.MaCongNhan == id)).GetValueOrDefault();
        }
    }
}
