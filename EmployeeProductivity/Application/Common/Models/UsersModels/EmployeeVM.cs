using Application.Common.Interfaces;
using Application.Models.UsersModels;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.Common.Models.UsersModels
{
    public class EmployeeVM : BaseUserVM, IMapWith<Employee>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeVM>();
        }
    }
}
