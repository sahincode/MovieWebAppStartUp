using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.PrivacyDTOs
{
    public class PrivacyCreateDto
    {
        public string Info { get; set; }
    }
    public class PrivacyCreateDtoValidator : AbstractValidator<PrivacyCreateDto>
    {
        public PrivacyCreateDtoValidator()
        {
            RuleFor(a => a.Info).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(8000).WithMessage("Can't be greater than 8000 chars").
                                    MinimumLength(100).WithMessage("Can not be less than 500 chars");
        }
    }
}
