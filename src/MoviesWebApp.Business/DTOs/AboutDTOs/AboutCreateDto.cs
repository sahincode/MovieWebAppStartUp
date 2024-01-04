using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.AboutDTOs
{
    public class AboutCreateDto
    {
        public string InfoAboutApp { get; set; }
    }
    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(a => a.InfoAboutApp).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(8000).WithMessage("Can't be greater than 8000 chars").
                                    MinimumLength(500).WithMessage("Can not be less than 500 chars");
        }
    }
}
