using System.ComponentModel.DataAnnotations;

namespace TIYVideoStorePartDeux.Models
{
    public class GenresModel
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreName { get; set; }

    }
}