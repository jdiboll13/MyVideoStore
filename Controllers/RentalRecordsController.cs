using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TIYVideoStorePartDeux.Models;

namespace TIYVideoStorePartDeux.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly videodbContext _context;

        public RentalRecordsController(videodbContext context)
        {
            _context = context;
        }

        // GET: RentalRecords
        public async Task<IActionResult> Index()
        {
            var videodbContext = _context.RentalRecords.Include(r => r.CustomersModel).Include(r => r.MoviesModel);
            return View(await videodbContext.ToListAsync());
        }

        // GET: RentalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords
                .Include(r => r.CustomersModel)
                .Include(r => r.MoviesModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordsModel);
        }

        // GET: RentalRecords/Create
        public IActionResult Create()
        {
            ViewData["CustomerName"] = new SelectList(_context.Customers, "CustomerName", "Customer Name");
            ViewData["MovieName"] = new SelectList(_context.Movies, "MovieName", "Movie Name");
            return View();
        }

        // POST: RentalRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalID,MovieName,CustomerName,RentalDate,DueDate,ReturnDate")] RentalRecordsModel rentalRecordsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalRecordsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerName"] = new SelectList(_context.Customers, "CustomerName", "Customer Name", rentalRecordsModel.CustomersModel.CustomerName);
            ViewData["MovieName"] = new SelectList(_context.Movies, "MovieName", "Movie Name", rentalRecordsModel.MoviesModel.MovieName);
            return View(rentalRecordsModel);
        }

        // GET: RentalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerName"] = new SelectList(_context.Customers, "CustomerName", "Customer Name", rentalRecordsModel.CustomersModel.CustomerName);
            ViewData["MovieName"] = new SelectList(_context.Movies, "MovieName", "Movie Name", rentalRecordsModel.MoviesModel.MovieName);
            return View(rentalRecordsModel);
        }

        // POST: RentalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,MovieName,CustomerName,RentalDate,DueDate,ReturnDate")] RentalRecordsModel rentalRecordsModel)
        {
            if (id != rentalRecordsModel.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalRecordsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRecordsModelExists(rentalRecordsModel.RentalID))
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
            ViewData["CustomerName"] = new SelectList(_context.Customers, "CustomerName", "Customer Name", rentalRecordsModel.CustomersModel.CustomerName);
            ViewData["MovieName"] = new SelectList(_context.Movies, "MovieName", "Movie Name", rentalRecordsModel.MoviesModel.MovieName);
            return View(rentalRecordsModel);
        }

        // GET: RentalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords
                .Include(r => r.CustomersModel)
                .Include(r => r.MoviesModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordsModel);
        }

        // POST: RentalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalRecordsModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            _context.RentalRecords.Remove(rentalRecordsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRecordsModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalID == id);
        }
    }
}
