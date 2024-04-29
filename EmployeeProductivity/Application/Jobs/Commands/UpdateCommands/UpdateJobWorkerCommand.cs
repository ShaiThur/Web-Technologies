using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Jobs.Commands.UpdateCommands
{
    public record UpdateJobWorkerCommand : IRequest
    {
        public Guid JobId { get; set; }

        public required string UserName { get; set; }
    }

    public class UpdateJobWorkerCommandHandler(
        IApplicationDbContext applicationDbContext,
        IIdentityService identityService
        ) : IRequestHandler<UpdateJobWorkerCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;

        public async Task Handle(UpdateJobWorkerCommand request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs
                .Where(j => j.Id == request.JobId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            var user = await _identityService.FindUserAsync(request.UserName);
            job.WorkerId = Guid.Parse(user.Id);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
