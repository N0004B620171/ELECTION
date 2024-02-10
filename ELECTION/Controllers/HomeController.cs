using ELECTION.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ELECTION.Data;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace ELECTION.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ELECTIONContext _context;

        public HomeController(ILogger<HomeController> logger, ELECTIONContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            // Requête SQL pour récupérer le nombre de votes pour chaque candidat par région à travers les bureaux de vote
            var resultatParRegion = _context.Vote
                .GroupBy(v => new { v.BureauDeVote.RegionID, v.CandidatID })
                .Select(g => new
                {
                    RegionID = g.Key.RegionID,
                    CandidatID = g.Key.CandidatID,
                    NombreDeVotes = g.Count()
                })
                .ToList();

            // Jointure avec les tables des candidats et des régions pour obtenir les noms correspondants
            var resultatFinal = (from resultat in resultatParRegion
                                 join candidat in _context.Candidat on resultat.CandidatID equals candidat.CandidatID
                                 join bureau in _context.BureauDeVote on resultat.RegionID equals bureau.RegionID
                                 select new ResultatParRegionViewModel
                                 {
                                     RegionID = resultat.RegionID,
                                     RegionNom = bureau?.Region?.NomRegion,             
                                     CandidatNom = candidat.Nom,
                                     NombreDeVotes = resultat.NombreDeVotes
                                 }).ToList();

            return View(resultatFinal);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
