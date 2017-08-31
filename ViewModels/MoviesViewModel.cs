namespace TIYVideoStorePartDeux.Models
{
    public class MoviesViewModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string GenreName { get; set; }

        public MoviesViewModel()
        {

        }
        public MoviesViewModel(MoviesModel movie)
        {
            this.MovieName = movie.MovieName;
            this.MovieDescription = movie.MovieDescription;
            this.GenreName = movie.GenresModel?.GenreName;
            
        }

    }
}