using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Queries
{
    public record GetDepartmentQuery : IRequest<DepartmentVM>
    {
        public required string UserName { get; set; }
    }

    public class GetDepartmentQueryHandler(
        IApplicationDbContext applicationDbContext,
        IIdentityService identityService,
        IMapper mapper)
        : IRequestHandler<GetDepartmentQuery, DepartmentVM>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;
        private readonly IMapper _mapper = mapper;

        public async Task<DepartmentVM> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserAsync(request.UserName);

            var department = await _applicationDbContext.Departments
                .Where(d => d.DirectorId == Guid.Parse(user.Id) 
                || d.CompanyStaffId != null 
                && d.CompanyStaffId.Contains(Guid.Parse(user.Id)))
                .FirstOrDefaultAsync()
                ?? throw new NullEntityException(nameof(Department));

            return _mapper.Map<DepartmentVM>(department);
        }
    }
}
