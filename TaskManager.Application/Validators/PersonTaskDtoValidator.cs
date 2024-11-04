using FluentValidation;
using TaskManager.Application.DTO;

namespace TaskManager.Application.Validators;

public class PersonTaskDtoValidator : AbstractValidator<PersonTaskDto>
{
    public PersonTaskDtoValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required").MinimumLength(3)
            .WithMessage("Description must have at least 3 characters");
    }
}