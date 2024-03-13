using Domain.Entities.Users;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Jobs.Commands.UpdateCommands
{
    public record UpdateJobDetailsCommand : IRequest<Guid>
    {
        public required string Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }

        public Employee? Employee { get; set; }

        public required Director JobCreator { get; set; }

        public JobResult? JobResult { get; set; }
    }
}
