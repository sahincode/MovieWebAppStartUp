using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public  class Episode :BaseEntity
    {
        public int  EpisodeNumber { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
      
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get;set ; }

    }
}
