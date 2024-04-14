using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Models.JobModels
{
    public class JobVM : IMapWith<Job>
    {
        public required string Title { get; init; }

        public string? MainInfo { get; init; }

        public DateTime Deadline { get; init; }

        public Complexity? Complexity { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, JobVM>().ForMember(d => d.Complexity,
                opt => opt.MapFrom(s => (int)s.Complexity));
        }
    }
}