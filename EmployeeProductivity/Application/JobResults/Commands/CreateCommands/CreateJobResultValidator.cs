using Application.JobResults.Commands.CreateJobResult;
using FluentValidation;

namespace Application.JobResults.Commands.CreateCommands
{
    internal class CreateJobResultValidator : AbstractValidator<CreateJobResultCommand>
    {
        public CreateJobResultValidator()
        {
            RuleFor(r => r.TextResult).NotNull().WithMessage("Text result is required");
        }
    }
}
