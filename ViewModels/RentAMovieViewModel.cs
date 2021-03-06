using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TIYVideoStorePartDeux.Models;

namespace TIYVideoStorePartDeux.Models
{
    public class RentAMovieViewModel
    {
        public List<MoviesModel> Movies { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public List<CustomersModel> Customers { get; set; }
        public RentAMovieViewModel()
        {
        }

        public RentAMovieViewModel(RentalRecordsModel movieRental)
        {
            this.Customers = new List<CustomersModel>();
            this.Movies = new List<MoviesModel>();
        }
    }
}