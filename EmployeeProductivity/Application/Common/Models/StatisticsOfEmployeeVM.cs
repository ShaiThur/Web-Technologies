using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Common.Models
{
    public class StatisticsOfEmployeeVM : IMapWith<StatisticsOfEmployee>
    {
        public DeliveryTimeRating? DeliveryTime { get; set; }

        public ComplexityJobsCounter? JobsComplexity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StatisticsOfEmployee, StatisticsOfEmployeeVM>();
        }
    }
}
