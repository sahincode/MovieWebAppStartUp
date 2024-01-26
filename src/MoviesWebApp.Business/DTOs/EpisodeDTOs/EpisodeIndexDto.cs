using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Business.DTOs.EpisodeDTOs
{
    public class EpisodeIndexDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeletedTime { get; set; }
        public string Name { get; set; }

        public string Actors { get; set; }
        public List<EpisodeGenre> EpisodeGenres { get; set; }

        public string Director { get; set; }

        public Season Season { get; set; }
        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
    }
}
