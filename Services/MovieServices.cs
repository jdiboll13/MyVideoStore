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
        public IEnumerable<MoviesViewModel> GetAllMovies()
        {
            var CurrentMovies = _context.Movies;
            return CurrentMovies.Include(i => i.GenresModel).Select(s => new MoviesViewModel(s));
        }

        public CreateRecordViewModel CreateRentalRecord()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var newRecord = new CreateRecordViewModel
            {
                Customers = customerInfo.ToList(),
                Movies = movieInfo.ToList(),
            };

            return newRecord;
        }

        public IEnumerable<RentalRecordsModel> GetAllRentalRecords()
        {
            var RentalRecord = _context.RentalRecords;
            return RentalRecord.Include(i => i.MoviesModel).Include(i => i.CustomersModel).Select(s => new RentalRecordsModel(s));
        }
        public IEnumerable<RentalRecordsModel> GetOverdueRecords()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            var today = DateTime.Today;
            return allRecords.Where(t => t.DueDate.CompareTo(today)<0).Include(m => m.MoviesModel).Include(c => c.CustomersModel).Select(s => new RentalRecordsModel(s));
        }
    }
}