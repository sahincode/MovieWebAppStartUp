using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.FAQDTOs
{
    public class FAQUpdateDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }
    public class NewsSlideUpdateDtoValidator : AbstractValidator<FAQUpdateDto>
    {
        public NewsSlideUpdateDtoValidator()
        {
            RuleFor(e => e.Question).NotNull().WithMessage("Can not be null").
                                  NotEmpty().WithMessage("Can not be empty").
                                  MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                  MinimumLength(3).WithMessage("Can not be less than 3 digits");
            RuleFor(e => e.Answer).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(500).WithMessage("Can not be greater than 500 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
           
        }
    }
}
