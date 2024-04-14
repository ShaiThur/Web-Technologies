using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Jobs.Commands.UpdateJob
{
    public record UpdateJobCommand : IRequest
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }

        public bool IsFinished { get; set; }
    }

    public class UpdateJobCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<UpdateJobCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs.FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            job.Title = request.Title;
            job.MainInfo = request.MainInfo;
            job.Deadline = request.Deadline;
            job.Complexity = request.Complexity;
            job.IsFinished = request.IsFinished;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
