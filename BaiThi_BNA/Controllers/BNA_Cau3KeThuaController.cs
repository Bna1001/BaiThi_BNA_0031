using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThi_BNA;

namespace BaiThi_BNA.Controllers
{
    public class BNA_Cau3KeThuaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BNA_Cau3KeThuaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BNA_Cau3KeThua
        public async Task<IActionResult> Index()
        {
              return _context.BNA_Cau3KeThua != null ? 
                          View(await _context.BNA_Cau3KeThua.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BNA_Cau3KeThua'  is null.");
        }

        // GET: BNA_Cau3KeThua/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BNA_Cau3KeThua == null)
            {
                return NotFound();
            }

            var bNA_Cau3KeThua = await _context.BNA_Cau3KeThua
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (bNA_Cau3KeThua == null)
            {
                return NotFound();
            }

            return View(bNA_Cau3KeThua);
        }

        // GET: BNA_Cau3KeThua/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BNA_Cau3KeThua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv,HoTen,SDT,DiaChi,LopHoc")] BNA_Cau3KeThua bNA_Cau3KeThua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bNA_Cau3KeThua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bNA_Cau3KeThua);
        }

        // GET: BNA_Cau3KeThua/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BNA_Cau3KeThua == null)
            {
                return NotFound();
            }

            var bNA_Cau3KeThua = await _context.BNA_Cau3KeThua.FindAsync(id);
            if (bNA_Cau3KeThua == null)
            {
                return NotFound();
            }
            return View(bNA_Cau3KeThua);
        }

        // POST: BNA_Cau3KeThua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,HoTen,SDT,DiaChi,LopHoc")] BNA_Cau3KeThua bNA_Cau3KeThua)
        {
            if (id != bNA_Cau3KeThua.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bNA_Cau3KeThua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BNA_Cau3KeThuaExists(bNA_Cau3KeThua.MaSv))
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
            return View(bNA_Cau3KeThua);
        }

        // GET: BNA_Cau3KeThua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BNA_Cau3KeThua == null)
            {
                return NotFound();
            }

            var bNA_Cau3KeThua = await _context.BNA_Cau3KeThua
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (bNA_Cau3KeThua == null)
            {
                return NotFound();
            }

            return View(bNA_Cau3KeThua);
        }

        // POST: BNA_Cau3KeThua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BNA_Cau3KeThua == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BNA_Cau3KeThua'  is null.");
            }
            var bNA_Cau3KeThua = await _context.BNA_Cau3KeThua.FindAsync(id);
            if (bNA_Cau3KeThua != null)
            {
                _context.BNA_Cau3KeThua.Remove(bNA_Cau3KeThua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BNA_Cau3KeThuaExists(string id)
        {
          return (_context.BNA_Cau3KeThua?.Any(e => e.MaSv == id)).GetValueOrDefault();
        }
    }
}
