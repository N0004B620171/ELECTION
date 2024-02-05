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
    public class ElecteursController : Controller
    {
        private readonly ELECTIONContext _context;

        public ElecteursController(ELECTIONContext context)
        {
            _context = context;
        }

        // GET: Electeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Electeur.ToListAsync());
        }

        // GET: Electeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electeur = await _context.Electeur
                .FirstOrDefaultAsync(m => m.ElecteurID == id);
            if (electeur == null)
            {
                return NotFound();
            }

            return View(electeur);
        }

        // GET: Electeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Electeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElecteurID,Nom,Prenom,DateNaissance,Adresse,NumeroIdentification")] Electeur electeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electeur);
        }

        // GET: Electeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electeur = await _context.Electeur.FindAsync(id);
            if (electeur == null)
            {
                return NotFound();
            }
            return View(electeur);
        }

        // POST: Electeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElecteurID,Nom,Prenom,DateNaissance,Adresse,NumeroIdentification")] Electeur electeur)
        {
            if (id != electeur.ElecteurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElecteurExists(electeur.ElecteurID))
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
            return View(electeur);
        }

        // GET: Electeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electeur = await _context.Electeur
                .FirstOrDefaultAsync(m => m.ElecteurID == id);
            if (electeur == null)
            {
                return NotFound();
            }

            return View(electeur);
        }

        // POST: Electeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electeur = await _context.Electeur.FindAsync(id);
            if (electeur != null)
            {
                _context.Electeur.Remove(electeur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElecteurExists(int id)
        {
            return _context.Electeur.Any(e => e.ElecteurID == id);
        }
    }
}
