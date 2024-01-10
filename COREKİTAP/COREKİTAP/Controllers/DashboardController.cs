using COREKİTAP.Data;
using COREKİTAP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace COREKİTAP.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {

            
            if (User.Identity.IsAuthenticated)
            {
                var userEmail = User.Identity.Name;
                var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

                if (user != null)
                {
                    var userReadingHistory = _context.okumaGecmisis
                        .Where(r => r.KullanıcıID == user.Id)
                        .Select(r => r.KitapID)
                        .ToList();

                    
                    var otherBooks = _context.kitaps
                        .Where(b => !userReadingHistory.Contains(b.KitapID))
                        .OrderByDescending(b => b.YayınlanmaTarihi)
                        .Take(6)
                        .ToList();

                    return View(otherBooks);
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddToReadingHistory(int bookId)
        {
            if (User.Identity.IsAuthenticated)
            {
                
                var userEmail = User.Identity.Name; 
                var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

                if (user != null)
                {
                    
                    var existingReadingRecord = _context.okumaGecmisis
                        .FirstOrDefault(r => r.KullanıcıID == user.Id && r.KitapID == bookId);

                    if (existingReadingRecord == null)
                    {
                        
                        var newReadingRecord = new OkumaGecmisi
                        {
                            KullanıcıID = user.Id,
                            KitapID = bookId,
                            Tarih = DateTime.Now 
                        };

                        
                        _context.okumaGecmisis.Add(newReadingRecord);
                        _context.SaveChanges();
                    }

                    
                    var readingHistory = _context.okumaGecmisis
                        .Include(r => r.Kitap)
                        .Where(r => r.KullanıcıID == user.Id)
                        .ToList();

                    return View("ReadingHistory", readingHistory);
                }
            }

            
            return RedirectToAction("Login", "Giris");

        }
        [HttpGet]
        public ActionResult ReadingHistory()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                Console.WriteLine($"UserId: {userId}");

                
                var readingHistory = _context.okumaGecmisis
                    .Include(r => r.Kitap) 
                    .Where(r => r.KullanıcıID == userId)
                    .GroupBy(r => r.KitapID)
                    .Select(grp => grp.OrderByDescending(r => r.Tarih).FirstOrDefault())
                    .ToList();

                
                Console.WriteLine($"ReadingHistory Count: {readingHistory.Count}");

                
                return View(readingHistory);
            }

            
            return RedirectToAction("Login", "Giris");
        }
    }
}
