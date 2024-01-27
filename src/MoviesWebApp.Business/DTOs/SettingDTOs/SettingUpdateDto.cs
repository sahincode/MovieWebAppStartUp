using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SettingDTOs
{
    public class SettingUpdateDto
    { public int Id { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string FaceUrl { get; set; }
        public string XUrl { get; set; }
        public string WhatUrl { get; set; }
        public string InstaUrl { get; set; }
    }
    public class SettingUpdateDtoValidator : AbstractValidator<SettingUpdateDto> 
    {
        public SettingUpdateDtoValidator()
        {
            RuleFor(e => e.Address).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
            RuleFor(e => e.Contact).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits");
            RuleFor(e => e.Email).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    EmailAddress().WithMessage("Please add valid email address").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                   MinimumLength(3).WithMessage("Can not be less than 3 digits"); ;
            RuleFor(e => e.FaceUrl).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.XUrl).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.WhatUrl).NotNull().WithMessage("Can not be null").
                                  NotEmpty().WithMessage("Can not be empty").
                                  MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                  MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(e => e.InstaUrl).NotNull().WithMessage("Can not be null").
                                  NotEmpty().WithMessage("Can not be empty").
                                  MaximumLength(200).WithMessage("Can not be greater than 200 digits").
                                  MinimumLength(5).WithMessage("Can not be less than 5 digits");
        }
    }
}
