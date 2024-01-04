using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SubscriberDTOs
{
    public class SubscriberCreateDto
    {
        public string Email {  get; set; }
    }
    public class SubscriberUpdateDtoValidator : AbstractValidator<SubscriberCreateDto>
    {
        public SubscriberUpdateDtoValidator()
        {
            RuleFor(e => e.Email).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   EmailAddress().WithMessage("Please add valid email address").
                                   MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                  MinimumLength(3).WithMessage("Can not be less than 3 digits"); ;
        }
    }
}
