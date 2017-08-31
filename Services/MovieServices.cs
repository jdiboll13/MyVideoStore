using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public IEnumerable<RentalRecordsModel> GetOverdueRecords()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            var today = DateTime.Today;
            return allRecords.Where(t => t.DueDate.CompareTo(today) < 0).Include(m => m.MoviesModel).Include(c => c.CustomersModel).Select(s => new RentalRecordsModel(s));
        }

        public IEnumerable<RentalRecordsModel> GetCurrentlyRented()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            return allRecords.Where(t => t.ReturnDate.CompareTo(default(DateTime)) == 0).Include(m => m.MoviesModel).Include(c => c.CustomersModel).Select(s => new RentalRecordsModel(s));
        }
    }
}