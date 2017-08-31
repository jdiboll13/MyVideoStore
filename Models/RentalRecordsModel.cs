using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIYVideoStorePartDeux.Models
{
    public class RentalRecordsModel
    {
        private RentalRecordsModel s;

        public RentalRecordsModel(RentalRecordsModel s)
        {
            this.s = s;
        }

        [Key]
        public int RentalID { get; set; }

        [ForeignKey("MovieID")]
        public int MovieID { get; set; }
        public MoviesModel MoviesModel { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public CustomersModel CustomersModel { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}