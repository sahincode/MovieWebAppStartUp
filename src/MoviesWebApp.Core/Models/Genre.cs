using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public  class Genre :BaseEntity
    {
        [StringLength(maximumLength:50 ,MinimumLength =3)]
        public string Name { get;set ; }
        public List<MovieGenre> GenreMovies { get; set; }

    }
}
