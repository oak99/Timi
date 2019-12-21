using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Team159.Data;
using Team159.Models;

namespace Team159.Controllers
{
    public class ArmsController : Controller
    {
        private readonly TimiContext _context;

        public ArmsController(TimiContext context)
        {
            _context = context;
        }

        // GET: Arms
        public async Task<IActionResult> Index(int? armType, int? league)
        {
            var players = from m in _context.Arms.AsNoTracking()
                          select m;

            if (armType.HasValue)
            {
                players = players.Where(e => e.ArmType == (ArmType)armType);
            }
            if (league.HasValue)
            {
                players = players.Where(e => e.League == (League)league);
            }
            var VM = new ArmTypeLeagueViewModel
            {
                Arms = await players.ToListAsync()
            };

            return View(VM);
        }

        // GET: Arms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arm = await _context.Arms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arm == null)
            {
                return NotFound();
            }

            return View(arm);
        }

        // GET: Arms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Arm arm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arm);
        }

        // GET: Arms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arm = await _context.Arms.FindAsync(id);
            if (arm == null)
            {
                return NotFound();
            }
            return View(arm);
        }

        // POST: Arms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Attach,Defance,Life,Damage,ArmType,Player,League")] Arm arm)
        {
            if (id != arm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmExists(arm.Id))
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
            return View(arm);
        }

        // GET: Arms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arm = await _context.Arms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arm == null)
            {
                return NotFound();
            }

            return View(arm);
        }

        // POST: Arms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arm = await _context.Arms.FindAsync(id);
            _context.Arms.Remove(arm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Compare(int id1, int id2)
        {
            var arm1 = await _context.Arms.FindAsync(id1);
            var arm2 = await _context.Arms.FindAsync(id2);
            CompareViewModel VM = new CompareViewModel()
            {
                Arm1 = arm1,
                Arm2 = arm2
            };
            return View(VM);
        }

        private bool ArmExists(int id)
        {
            return _context.Arms.Any(e => e.Id == id);
        }


    }
}
