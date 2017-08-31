using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using TIYVideoStorePartDeux.Models;

namespace TIYVideoStorePartDeux
{
    class MovieService
    {
        private readonly videodbContext _context;

        public MovieService(videodbContext context)
        {
            _context = context;
        }

        public RentAMovieViewModel CreateRentalRecord()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var newRecord = new RentAMovieViewModel
            {
                Customers = customerInfo.ToList(),
                Movies = movieInfo.ToList(),
            };

            return newRecord;
        }

        private static Func<RentalRecordViewModel, bool> hasDefaultDate => w => w.ReturnDate == default(DateTime);

        public IEnumerable<RentalRecordViewModel> GetOverdueRecords()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            var today = DateTime.Today;
            return allRecords.Where(t => t.DueDate.CompareTo(today)<0 && t.ReturnDate == default(DateTime)).Include(m => m.MoviesModel).Include(c => c.CustomersModel).Select(s => new RentalRecordViewModel(s));
        }

        public IEnumerable<RentalRecordViewModel> GetCurrentlyRented()
        {
            var customerInfo = _context.Customers;
            //get all movies
            var movieInfo = _context.Movies;
            //construct rental view model
            var allRecords = _context.RentalRecords;
            return allRecords.Where(t => t.ReturnDate == default(DateTime)).Include(m => m.MoviesModel).Include(c => c.CustomersModel).Select(s => new RentalRecordViewModel(s));
        }

    }
}