using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.DeleteCommands
{
    public record DeleteDepartmentCommand : IRequest
    {
        public required Guid DepartmentId { get; set; }
    }

    public class DeleteDepartmentCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _applicationDbContext.Departments
                .Where(d => d.Id == request.DepartmentId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Department));

            _applicationDbContext.Departments.Remove(department);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
