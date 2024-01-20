using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SeasonDTOs
{
    public class SeasonCreateDto
    {
        public int SeasonNumber { get; set; }
        public string Country { get; set; }
        public int SerialId { get; set; }
    }
     public class SeasonCreateDtoValidator:AbstractValidator<SeasonCreateDto>
    {
        public SeasonCreateDtoValidator()
        {
            RuleFor(e => e.SeasonNumber).
                                 GreaterThan(0).WithMessage("Can not be less than 70 digits").
                                 LessThan(100).WithMessage("Can not be less than 5 digits");

            RuleFor(e => e.Country).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(3).WithMessage("Can not be less than 5 digits");
        }
    }
}
