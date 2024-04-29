using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Departments.Commands.UpdateCommands
{
    public record UpdateDepartmentStaffCommand : IRequest
    {
        public required string DirectorName { get; set; }

        public required string NewEmployeeLogin { get; set; }
    }

    public class UpdateDepartmentStaffCommandHandler(
        IApplicationDbContext applicationDbContext,
        IIdentityService identityService)
        : IRequestHandler<UpdateDepartmentStaffCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;

        public async Task Handle(UpdateDepartmentStaffCommand request, CancellationToken cancellationToken)
        {
            var employee = await _identityService.FindUserAsync(request.NewEmployeeLogin);

            var user = await _identityService.FindUserAsync(request.DirectorName);
            var department = await _applicationDbContext.Departments
                .Where(d => d.DirectorId == Guid.Parse(user.Id))
                .FirstOrDefaultAsync()
                ?? throw new NullEntityException(nameof(Department));

            if (user.Id == employee.Id)
                throw new NullEntityException(nameof(user.UserName));

            if (department.CompanyStaffId == null)
                department.CompanyStaffId = [Guid.Parse(employee.Id)];

            else if (department.CompanyStaffId.Contains(Guid.Parse(employee.Id)) )
                throw new NullEntityException(nameof(employee.UserName));

            else
                department.CompanyStaffId.Add(Guid.Parse(employee.Id));

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
