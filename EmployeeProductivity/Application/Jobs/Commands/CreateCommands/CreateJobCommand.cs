using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Jobs.Commands.CreateJob
{
    public record CreateJobCommand : IRequest
    {
        public required string UserName { get; set; }

        public string? Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }
    }

    public class CreateJobCommandHandler(IApplicationDbContext applicationDbContext, IIdentityService identityService) : IRequestHandler<CreateJobCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;

        public async Task Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {           
            var user = await _identityService
                .FindUserAsync(request.UserName);
            await _identityService.SaveChangesAsync(user);

            var job = new Job
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                MainInfo = request.MainInfo,
                Complexity = request.Complexity,
                Deadline = request.Deadline,
                CreatorId = Guid.Parse(user.Id),
                Department = user.Department
            };

            await _applicationDbContext.Jobs.AddAsync(job, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
