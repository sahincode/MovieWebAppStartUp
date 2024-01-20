using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.AboutDTOs

{
    public class AboutUpdateDto
    {

        public string InfoAboutApp { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleFor(a => a.InfoAboutApp).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(8000).WithMessage("Can not be greater than 8000 digits").
                                    MinimumLength(500).WithMessage("Can not be less than 500 digits");
        }
    }
}
