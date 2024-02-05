using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELECTION.Data;
using ELECTION.Models;

namespace ELECTION.Controllers
{
    public class BureauDeVotesController : Controller
    {
        private readonly ELECTIONContext _context;

        public BureauDeVotesController(ELECTIONContext context)
        {
            _context = context;
        }

        // GET: BureauDeVotes
        public async Task<IActionResult> Index()
        {
            var eLECTIONContext = _context.BureauDeVote.Include(b => b.Region);
            return View(await eLECTIONContext.ToListAsync());
        }

        // GET: BureauDeVotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureauDeVote = await _context.BureauDeVote
                .Include(b => b.Region)
                .FirstOrDefaultAsync(m => m.BureauID == id);
            if (bureauDeVote == null)
            {
                return NotFound();
            }

            return View(bureauDeVote);
        }

        // GET: BureauDeVotes/Create
        public IActionResult Create()
        {
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "RegionID");
            return View();
        }

        // POST: BureauDeVotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BureauID,Emplacement,Responsable,RegionID")] BureauDeVote bureauDeVote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bureauDeVote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "RegionID", bureauDeVote.RegionID);
            return View(bureauDeVote);
        }

        // GET: BureauDeVotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureauDeVote = await _context.BureauDeVote.FindAsync(id);
            if (bureauDeVote == null)
            {
                return NotFound();
            }
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "RegionID", bureauDeVote.RegionID);
            return View(bureauDeVote);
        }

        // POST: BureauDeVotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BureauID,Emplacement,Responsable,RegionID")] BureauDeVote bureauDeVote)
        {
            if (id != bureauDeVote.BureauID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bureauDeVote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BureauDeVoteExists(bureauDeVote.BureauID))
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
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "RegionID", bureauDeVote.RegionID);
            return View(bureauDeVote);
        }

        // GET: BureauDeVotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureauDeVote = await _context.BureauDeVote
                .Include(b => b.Region)
                .FirstOrDefaultAsync(m => m.BureauID == id);
            if (bureauDeVote == null)
            {
                return NotFound();
            }

            return View(bureauDeVote);
        }

        // POST: BureauDeVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bureauDeVote = await _context.BureauDeVote.FindAsync(id);
            if (bureauDeVote != null)
            {
                _context.BureauDeVote.Remove(bureauDeVote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BureauDeVoteExists(int id)
        {
            return _context.BureauDeVote.Any(e => e.BureauID == id);
        }
    }
}
