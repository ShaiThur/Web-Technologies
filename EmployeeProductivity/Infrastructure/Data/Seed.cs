using Application.Common.Interfaces.Identity;
using Application.Companies.Commands.CreateCommands;
using Application.Departments.Commands.UpdateCommands;
using MediatR;

namespace Infrastructure.Data
{
    public class Seed
    {
        private readonly IIdentityService _identityService;
        private readonly IRolesService _rolesService;
        private readonly ISender _sender;

        public Seed(IIdentityService identityService, IRolesService rolesService, ISender sender)
        {
            _identityService = identityService;
            _rolesService = rolesService;
            _sender = sender;
        }

        public async Task TrySeed()
        {
            var adminResult = await _identityService.CreateUserAsync("", "", "Admi@n.ru", "Admin_0102");
            var emp1Result = await _identityService.CreateUserAsync("Jane", "Air", "emp1@loy.ee", "Employee_01");
            var emp2Result = await _identityService.CreateUserAsync("Alen", "Ginger", "emp2@loy.ee", "Employee_02");
            var emp3Result = await _identityService.CreateUserAsync("Robert", "House", "emp3@loy.ee", "Employee_03");
            var directorResult = await _identityService.CreateUserAsync("Andy", "Parks", "dir@ect.or", "Director_01");


            await _rolesService.CreateUserRoleAsync("Administrator");
            await _rolesService.CreateUserRoleAsync("Director");
            await _rolesService.CreateUserRoleAsync("Employee");

            await _rolesService.UpdateUserRoleAsync("Admi@n.ru", "Administrator");
            
            await _rolesService.UpdateUserRoleAsync("emp1@loy.ee", "Employee");
            await _rolesService.UpdateUserRoleAsync("emp1@loy.ee", "Employee");
            await _rolesService.UpdateUserRoleAsync("emp1@loy.ee", "Employee");

            await _rolesService.UpdateUserRoleAsync("dir@ect.or", "Director");


            await _sender.Send(new CreateDepartmentCommand { DepartmentName = "Main department", DirectorName = "dir@ect.or" });

            await _sender.Send(new UpdateDepartmentStaffCommand { DirectorName = "dir@ect.or", NewEmployeeLogin = "emp1@loy.ee" });
            await _sender.Send(new UpdateDepartmentStaffCommand { DirectorName = "dir@ect.or", NewEmployeeLogin = "emp2@loy.ee" });
            await _sender.Send(new UpdateDepartmentStaffCommand { DirectorName = "dir@ect.or", NewEmployeeLogin = "emp3@loy.ee" });


        }
    }
}
