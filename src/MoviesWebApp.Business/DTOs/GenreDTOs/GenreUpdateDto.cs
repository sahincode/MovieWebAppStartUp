using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.GenreDTOs
{
    public class GenreUpdateDto
    {
        [StringLength(12000)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class GenreUpdateDtoValidator : AbstractValidator<GenreUpdateDto>
    {

        public GenreUpdateDtoValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
        }
    }
}
