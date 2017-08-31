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
    public class MoviesController : Controller
    {
        private readonly videodbContext _context;

        public MoviesController(videodbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var videodbContext = _context.Movies.Include(m => m.GenresModel);
            return View(await videodbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MovieName,MovieDescription,GenreName")] MoviesModel movieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", movieModel.GenreID);
            return View(movieModel);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }
            ViewData["GenreName"] = new SelectList(_context.Genres, "GenreName", "GenreName", moviesModel.GenresModel.GenreName);
            return View(moviesModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,MovieName,MovieDescription,GenreName")] MoviesModel moviesModel)
        {
            if (id != moviesModel.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesViewModelExists(moviesModel.MovieID))
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
            ViewData["GenreName"] = new SelectList(_context.Genres, "GenreName", "Genre Name", moviesModel.GenresModel.GenreName);
            return View(moviesModel);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.MovieID == id);
            _context.Movies.Remove(moviesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesViewModelExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}
