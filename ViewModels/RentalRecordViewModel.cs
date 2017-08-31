using System;

namespace TIYVideoStorePartDeux.Models
{
    public class RentalRecordViewModel
    {
        private RentalRecordsModel s;

        public int RentalID { get; set; }
        public  int MovieID { get; set; }
        public string MovieName { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public DateTime ReturnDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        

        public RentalRecordViewModel()
        {
        }

        public RentalRecordViewModel(RentalRecordsModel record)
        {
           this.RentalID = record.RentalID;
           this.MovieID = record.MovieID;
           this.MovieName = record.MoviesModel.MovieName;
           this.RentalDate = record.RentalDate;
           this.DueDate = record.DueDate;
           this.ReturnDate = record.ReturnDate;
           this.CustomerID = record.CustomerID;
           this.CustomerName = record.CustomersModel.CustomerName;
        }
    }
}