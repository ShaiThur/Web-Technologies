using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Models.JobModels
{
    public class JobVM : IMapWith<Job>
    {
        public required string Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, JobVM>();
        }
    }
}