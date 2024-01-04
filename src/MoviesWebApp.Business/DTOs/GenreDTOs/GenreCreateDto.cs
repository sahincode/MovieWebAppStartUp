using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.GenreDTOs
{
    public class GenreCreateDto
    {
        public string Name { get; set; }
    }
    public class GenreCreateDtoValidator : AbstractValidator<GenreCreateDto>
    {
        public GenreCreateDtoValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
        }
    }
}
