using FluentValidation;

namespace MoviesWebApp.Business.DTOs.CountryDTOs

{
    public class CountryCreateDto
    {
        public string Name { get; set; }
    }
    public class CountryCreateDtoValidator : AbstractValidator<CountryCreateDto>
    {
        public CountryCreateDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can't be greater than 100 chars").
                                    MinimumLength(3).WithMessage("Can not be less than 3 chars");
        }
    }
}
