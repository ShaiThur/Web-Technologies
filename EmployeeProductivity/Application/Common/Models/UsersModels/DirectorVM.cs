using Application.Common.Interfaces;
using Application.Models.UsersModels;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.Common.Models.UsersModels
{
    public class DirectorVM : BaseUserVM, IMapWith<Director>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Director, DirectorVM>();
        }
    }
}
