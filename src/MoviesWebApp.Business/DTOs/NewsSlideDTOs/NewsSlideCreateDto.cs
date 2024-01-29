using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.NewsSlideDTOs
{
    public class NewsSlideCreateDto
    {
        public string Title { get; set; }
        public string SubDescription { get; set; }
        public string Description { get; set; }

    }
    public class NewsSlideCreateDtoValidator : AbstractValidator<NewsSlideCreateDto>
    {
        public NewsSlideCreateDtoValidator()
        {
            RuleFor(e => e.Title).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
            RuleFor(e => e.SubDescription).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(300).WithMessage("Can not be greater than 300 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
            RuleFor(e => e.Description).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    EmailAddress().WithMessage("Please add valid email address").
                                    MaximumLength(1000).WithMessage("Can not be greater than 1000 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
        }
    }
}
