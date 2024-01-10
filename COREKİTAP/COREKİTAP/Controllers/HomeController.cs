using COREKİTAP.Data;
using COREKİTAP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace COREKİTAP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var latestbook = _context.kitaps.OrderByDescending(b => b.YayınlanmaTarihi).Take(6).ToList();
            return View(latestbook);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
