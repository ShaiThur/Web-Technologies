using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models.JobModels
{
    public class JobResultVM : IMapWith<JobResult>
    {
        public required string TextResult { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobResult, JobResultVM>();
        }
    }
}