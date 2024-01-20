using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Core.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        
        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }
        public float IMDB { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }


    }


}
