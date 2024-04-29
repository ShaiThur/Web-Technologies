using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class DepartmentVM : IMapWith<Department>
    {
        public Guid Id { get; set; }

        public string? CompanyName { get; init; }

        public string? MainInfo { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentVM>();
        }
    }
}
