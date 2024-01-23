using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public class EpisodeGenre :BaseEntity
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
