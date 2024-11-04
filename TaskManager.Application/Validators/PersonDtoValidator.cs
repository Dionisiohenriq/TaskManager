using FluentValidation;
using FluentValidation.Validators;
using TaskManager.Application.DTO;

namespace TaskManager.Application.Validators;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(p => p.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Email is invalid")
            .NotEmpty().WithMessage("Email is required");
        RuleFor(p => p.Name).Length(3, 100).WithMessage("Name must be between 3 and 100 characters").NotEmpty()
            .WithMessage("Name is required");
        RuleFor(p => p.BirthDate).NotNull().WithMessage("BirthDate is required").GreaterThan(DateTime.MinValue)
            .WithMessage("BirthDate should be greater than 0");
    }
}