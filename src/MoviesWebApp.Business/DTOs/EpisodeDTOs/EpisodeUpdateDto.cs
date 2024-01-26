using FluentValidation;
using Microsoft.AspNetCore.Http;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.EpisodeDTOs
{
    public class EpisodeUpdateDto
    {
        public int ? Id { get; set; }

        public string Name { get; set; }
        public string Actors { get; set; }
        public List<int> GenreIds { get; set; }
        public int SerialId { get; set; }

        public string Director { get; set; }
        public string Country { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int SeasonId { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Video { get; set; }
    }
    public class EpisodeUpdateDtoValidator : AbstractValidator<EpisodeUpdateDto>
    {
        public EpisodeUpdateDtoValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.SeasonId).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   GreaterThan(0).WithMessage("Can not be greater than 200 digits").
                                   LessThan(200).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Actors).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Country).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");

            RuleFor(e => e.Director).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Duration).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    GreaterThan(0).WithMessage("Movie duration can't be less than 0 minutes").
                                    LessThan(300).WithMessage("Movie duration can't be greater than 300 minute");


        }
    }
}
