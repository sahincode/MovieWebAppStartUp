﻿using FluentValidation;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.MovieDTOs
{
    public  class MovieCreateDto
    { 
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
       public List<int> GenreIds { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        [Range(0, 300)]
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(0, 10)]
        public float IMDB { get; set; }
        public IFormFile Image { get; set; } 
        public IFormFile Video { get; set; }
    }
    public class MovieCreateDtoValidator:AbstractValidator<MovieCreateDto>
    {
        public MovieCreateDtoValidator()
        {
            RuleFor(e => e.Title).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Description).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Actors).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Country).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Director).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Duration).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    GreaterThan(300).WithMessage("Movie duration can't be greater than 300 minutes").
                                    LessThan(0).WithMessage("Movie duration can't be less than 0 minute");

                                   
        }
    }
}
