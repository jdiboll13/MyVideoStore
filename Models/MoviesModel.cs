using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIYVideoStorePartDeux.Models
{
    public class MoviesModel
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        [ForeignKey("GenreID")]
        public int GenreID { get; set; }
        public GenresModel GenresModel { get; set; }


    }
}