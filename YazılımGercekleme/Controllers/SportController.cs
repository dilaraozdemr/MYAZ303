using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YazılımGercekleme.Models;

namespace YazılımGercekleme.Controllers
{
    public class SportController:Controller
    {
        private readonly SportDbContext _context;
        public SportController(SportDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sports.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var sport = await _context.Sports
                .FirstOrDefaultAsync(s => s.AthleteId == id);
            if(sport ==null)
            {
                return NotFound();
            }
            return View(sport);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AthleteId,AthleteNum")] Sport sport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sport);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }
            return View(sport);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId")] Sport sport)
        {
            if (id != sport.AthleteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteExists(sport.AthleteId))
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
            return View(sport);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports
                .FirstOrDefaultAsync(s => s.AthleteId == id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sports == null)
            {
                return Problem("Entity set 'MvcDbContext.Orders'  is null.");
            }
            var sport = await _context.Sports.FindAsync(id);
            if (sport != null)
            {
                _context.Sports.Remove(sport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteExists(int id)
        {
            return _context.Sports.Any(s => s.AthleteId == id);
        }
    }
}

