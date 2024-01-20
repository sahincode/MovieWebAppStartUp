using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Business.DTOs.MovieDTOs
{
    public class MovieIndexDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeletedTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }


        public float IMDB { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
    }
}
