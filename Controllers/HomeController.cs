using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TIYVideoStorePartDeux.Models;

namespace TIYVideoStorePartDeux.Controllers
{
    public class HomeController : Controller
    {
        private readonly videodbContext _context;

        public HomeController(videodbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overdue()
        {
            var service = new MovieService(_context);
            return View(service.GetOverdueRecords());
        }

        public IActionResult Return()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
