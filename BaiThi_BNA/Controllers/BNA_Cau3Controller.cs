using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThi_BNA;
using BaiThi_BNA.Models.Process;

namespace BaiThi_BNA.Controllers
{
    public class BNA_Cau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        StringProcess strPro = new StringProcess();

        public BNA_Cau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BNA_Cau3
        public async Task<IActionResult> Index()
        {
              return _context.BNA_Cau3 != null ? 
                          View(await _context.BNA_Cau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BNA_Cau3'  is null.");
        }

        // GET: BNA_Cau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BNA_Cau3 == null)
            {
                return NotFound();
            }

            var bNA_Cau3 = await _context.BNA_Cau3
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (bNA_Cau3 == null)
            {
                return NotFound();
            }

            return View(bNA_Cau3);
        }

        // GET: BNA_Cau3/Create
        public IActionResult Create()
        {
            var newID = "";
            if (_context.BNA_Cau3.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "STUDEN001";
            }
            else
            {
                var id = _context.BNA_Cau3.OrderByDescending(m => m.MaSv).First().MaSv;
                newID = strPro.AutoGenerateKey(id);
            }
            ViewBag.MaSv = newID;
            return View();
        }

        // POST: BNA_Cau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv,HoTen,SDT")] BNA_Cau3 bNA_Cau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bNA_Cau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bNA_Cau3);
        }

        // GET: BNA_Cau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BNA_Cau3 == null)
            {
                return NotFound();
            }

            var bNA_Cau3 = await _context.BNA_Cau3.FindAsync(id);
            if (bNA_Cau3 == null)
            {
                return NotFound();
            }
            return View(bNA_Cau3);
        }

        // POST: BNA_Cau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,HoTen,SDT")] BNA_Cau3 bNA_Cau3)
        {
            if (id != bNA_Cau3.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bNA_Cau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BNA_Cau3Exists(bNA_Cau3.MaSv))
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
            return View(bNA_Cau3);
        }

        // GET: BNA_Cau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BNA_Cau3 == null)
            {
                return NotFound();
            }

            var bNA_Cau3 = await _context.BNA_Cau3
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (bNA_Cau3 == null)
            {
                return NotFound();
            }

            return View(bNA_Cau3);
        }

        // POST: BNA_Cau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BNA_Cau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BNA_Cau3'  is null.");
            }
            var bNA_Cau3 = await _context.BNA_Cau3.FindAsync(id);
            if (bNA_Cau3 != null)
            {
                _context.BNA_Cau3.Remove(bNA_Cau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BNA_Cau3Exists(string id)
        {
          return (_context.BNA_Cau3?.Any(e => e.MaSv == id)).GetValueOrDefault();
        }
    }
}
