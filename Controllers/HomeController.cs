using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var service = new MovieService(_context);
            return View(service.GetCurrentlyRented());
        }

        public async Task<IActionResult> ReturnMovie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }
            rentalRecordModel.ReturnDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("Return", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
