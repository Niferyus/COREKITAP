using COREKİTAP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace COREKİTAP.Controllers
{
    public class RecommendedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecommendedBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userReadingHistory = _context.okumaGecmisis
                .Where(r => r.KullanıcıID == userId)
                .Select(r => r.KitapID)
                .ToList();

            var userGenres = _context.okumaGecmisis
                .Include(r => r.Kitap)
                .Where(r => r.KullanıcıID == userId && r.Kitap != null && r.Kitap.TürID != null)
                .Select(r => r.Kitap.TürID)
                .Distinct()
                .ToList();

            var recommendedBooks = _context.kitaps
                .Where(k => userGenres.Contains(k.TürID) && !userReadingHistory.Contains(k.KitapID))
                .OrderByDescending(k => k.YayınlanmaTarihi)
                .ToList();

            return View(recommendedBooks);
        }
    }
}
