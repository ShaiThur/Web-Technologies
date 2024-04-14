using Application.Jobs.Commands.CreateJob;
using FluentValidation;

namespace Application.Jobs.Commands.CreateCommands
{
    internal class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(j => j.Title).NotEmpty()
                .WithErrorCode("400")
                .WithMessage("Title is required");
        }
    }
}
