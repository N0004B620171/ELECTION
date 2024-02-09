using ELECTION.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ELECTION.Data;
using Microsoft.EntityFrameworkCore;
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
            var eLECTIONContext = _context.Vote.Include(v => v.BureauDeVote).Include(v => v.Candidat).Include(v => v.Electeur);
            return View(await eLECTIONContext.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
