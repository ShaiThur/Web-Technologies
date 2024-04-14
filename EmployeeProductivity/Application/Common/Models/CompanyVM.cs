using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class CompanyVM : IMapWith<Company>
    {
        public string? CompanyName { get; init; }

        public string? MainInfo { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Company, CompanyVM>();
        }
    }
}
