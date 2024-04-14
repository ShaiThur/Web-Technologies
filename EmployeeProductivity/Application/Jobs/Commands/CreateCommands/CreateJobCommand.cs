using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Jobs.Commands.CreateJob
{
    public record CreateJobCommand : IRequest<Guid>
    {
        public string? Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }
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
                Deadline = request.Deadline,
            };

            await _applicationDbContext.Jobs.AddAsync(job, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return job.Id;
        }
    }
}
