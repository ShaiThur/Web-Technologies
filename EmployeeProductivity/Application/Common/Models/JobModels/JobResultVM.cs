using Application.Common.Interfaces;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.Common.Models.JobModels
{
    public class JobResultVM : IMapWith<JobResult>
    {
        public required string TextResult { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobResult, JobResultVM>();
        }
    }
}