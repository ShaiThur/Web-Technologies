using Application.Common.Interfaces;
using Application.Models.UsersModels;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.Common.Models.UsersModels
{
    public class AdminVM : BaseUserVM, IMapWith<Admin>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Admin, AdminVM>();
        }
    }
}
