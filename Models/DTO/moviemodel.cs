﻿using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models.DTO
{
    public class moviemodel
    {
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        

        public string  Actors { get; set; }
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }


        public string Director { get; set; }
        public string Country { get; set; }
        [Range(0, 300)]
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
     
        [Range(0, 10)]
        public float IMDB { get; set; }
        public string  ?ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public string VideoURL { get; set; }
        public IFormFile Video { get; set; }



    }
    
}
