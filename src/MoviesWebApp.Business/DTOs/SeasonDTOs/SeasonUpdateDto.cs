using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SeasonDTOs
{
    public class SeasonUpdateDto
    {
        public int SeasonNumber { get; set; }
        public string Country { get; set; }
        public int SerialId { get; set; }
    }
    public class SeasonUpdateDtoValidator : AbstractValidator<SeasonUpdateDto>
    {
        public SeasonUpdateDtoValidator()
        {
            RuleFor(e => e.Country).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(70).WithMessage("Can not be greater than 70 digits").
                                    MinimumLength(3).WithMessage("Can not be less than 5 digits");
        }
    }
}
