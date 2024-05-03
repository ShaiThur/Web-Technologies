using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Domain.Entities;
using MediatR;

namespace Application.Companies.Commands.CreateCommands
{
    public record CreateDepartmentCommand : IRequest<Guid>
    {
        public required string DirectorName { get; set; }

        public required string DepartmentName { get; set; }

        public string? MainInfo { get; set; }
    }

    public class CreateDepartmentCommandHandler(
        IApplicationDbContext applicationDbContext,
        IIdentityService identityService)
        : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserAsync(request.DirectorName);
            var department = new Department
            {
                DepartmentName = request.DepartmentName,
                Id = Guid.NewGuid(),
                MainInfo = request.MainInfo,
                DirectorId = Guid.Parse(user.Id)
            };
            user.Department = department;
            await _applicationDbContext.Departments.AddAsync(department, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            await _identityService.SaveChangesAsync(user);

            return department.Id;
        }
    }
}
