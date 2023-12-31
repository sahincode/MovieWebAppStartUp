﻿using Microsoft.AspNetCore.Http;

using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.MovieDTOs
{
    public  class MovieIndexDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        [Range(0, 300)]
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(0, 10)]
        public float IMDB { get; set; }
        public string  ImageURL { get; set; }
        public string  VideoURL { get; set; }
    }
}
