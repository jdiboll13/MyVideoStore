using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TIYVideoStorePartDeux.Models;

namespace TIYVideoStorePartDeux.Models
{
    public class CreateRecordViewModel
    {
        public  List<MoviesModel> Movies { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public DateTime ReturnDate { get; set; }
        public List<CustomersModel> Customers { get; set; }
        

        public CreateRecordViewModel()
        {
        }

        public CreateRecordViewModel(RentalRecordsModel movieRental)
        {
            this.Customers = new List<CustomersModel>();
            this.Movies = new List<MoviesModel>();
        }
    }
}
