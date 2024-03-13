using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Jobs.Commands.CreateJob
{
    public record CreateJobCommand : IRequest<Guid>
    {
        public required string Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }

        public Employee? Employee { get; set; }

        public required Director JobCreator { get; set; }

        public JobResult? JobResult { get; set; }
    }

    public class CreateJobCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                MainInfo = request.MainInfo,
                Complexity = request.Complexity,
                JobCreator = request.JobCreator,
                JobResult = request.JobResult,
                Employee = request.Employee,
                Deadline = request.Deadline,
                DeliveryTime = null,
                IsFinished = false
            };

            await _applicationDbContext.Jobs.AddAsync(job, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return job.Id;
        }
    }
}
