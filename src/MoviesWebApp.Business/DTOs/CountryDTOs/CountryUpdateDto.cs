using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.CountryDTOs

{
    public class CountryUpdateDto
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class AboutUpdateDtoValidator : AbstractValidator<CountryUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                    MinimumLength(3).WithMessage("Can not be less than 3 digits");
        }
    }
}
