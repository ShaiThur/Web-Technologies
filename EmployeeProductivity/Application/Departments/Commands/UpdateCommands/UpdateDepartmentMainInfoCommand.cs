using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.UpdateCommands
{
    public record UpdateDepartmentMainInfoCommand : IRequest
    {
        public Guid DepartmentId { get; set; }

        public string? MainInfo { get; set; }

        public required Guid DirectorId { get; set; }
    }

    public class UpdateDepartmentCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<UpdateDepartmentMainInfoCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(UpdateDepartmentMainInfoCommand request, CancellationToken cancellationToken)
        {
            var department = await _applicationDbContext.Departments
                .Where(d => d.Id == request.DepartmentId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Department));

            department.MainInfo = request.MainInfo;
            department.DirectorId = request.DirectorId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
