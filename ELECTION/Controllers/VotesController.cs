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
    public class VotesController : Controller
    {
        private readonly ELECTIONContext _context;

        public VotesController(ELECTIONContext context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {
            var eLECTIONContext = _context.Vote.Include(v => v.BureauDeVote).Include(v => v.Candidat).Include(v => v.Electeur);
            return View(await eLECTIONContext.ToListAsync());
        }

        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.BureauDeVote)
                .Include(v => v.Candidat)
                .Include(v => v.Electeur)
                .FirstOrDefaultAsync(m => m.VoteID == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        public IActionResult Create()
        {
            ViewData["BureauDeVoteID"] = new SelectList(_context.BureauDeVote, "BureauID", "Emplacement");
            ViewData["CandidatID"] = new SelectList(_context.Candidat, "CandidatID", "Nom");
            ViewData["ElecteurID"] = new SelectList(_context.Electeur, "ElecteurID", "Nom");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoteID,ElecteurID,CandidatID,BureauDeVoteID,DateVote")] Vote vote)
        {
          //  if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["BureauDeVoteID"] = new SelectList(_context.BureauDeVote, "BureauID", "Emplacement", vote.BureauDeVoteID);
            ViewData["CandidatID"] = new SelectList(_context.Candidat, "CandidatID", "Nom", vote.CandidatID);
            ViewData["ElecteurID"] = new SelectList(_context.Electeur, "ElecteurID", "Nom", vote.ElecteurID);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            ViewData["BureauDeVoteID"] = new SelectList(_context.BureauDeVote, "BureauID", "Emplacement", vote.BureauDeVoteID);
            ViewData["CandidatID"] = new SelectList(_context.Candidat, "CandidatID", "Nom", vote.CandidatID);
            ViewData["ElecteurID"] = new SelectList(_context.Electeur, "ElecteurID", "Nom", vote.ElecteurID);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoteID,ElecteurID,CandidatID,BureauDeVoteID,DateVote")] Vote vote)
        {
            if (id != vote.VoteID)
            {
                return NotFound();
            }

            //   if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.VoteID))
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
            ViewData["BureauDeVoteID"] = new SelectList(_context.BureauDeVote, "BureauID", "Emplacement", vote.BureauDeVoteID);
            ViewData["CandidatID"] = new SelectList(_context.Candidat, "CandidatID", "Nom", vote.CandidatID);
            ViewData["ElecteurID"] = new SelectList(_context.Electeur, "ElecteurID", "Nom", vote.ElecteurID);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.BureauDeVote)
                .Include(v => v.Candidat)
                .Include(v => v.Electeur)
                .FirstOrDefaultAsync(m => m.VoteID == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vote = await _context.Vote.FindAsync(id);
            if (vote != null)
            {
                _context.Vote.Remove(vote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.VoteID == id);
        }
    }
}
