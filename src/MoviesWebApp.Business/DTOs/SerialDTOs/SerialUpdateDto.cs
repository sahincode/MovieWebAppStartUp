using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SerialDTOs
{
    public class SerialUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
    }
    public class SerialUpdateDtoValidator : AbstractValidator<SerialCreateDto>
    {
        public SerialUpdateDtoValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                    MinimumLength(3).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.Description).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(300).WithMessage("Can not be greater than 300 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.IMDB).NotNull().WithMessage("Can not be null").
                                  NotEmpty().WithMessage("Can not be empty").
                                  GreaterThan(0).WithMessage("Can not be greater than 10 digits").
                                  LessThan(10).WithMessage("Can not be less than 0 digits");

        }
    }
}
