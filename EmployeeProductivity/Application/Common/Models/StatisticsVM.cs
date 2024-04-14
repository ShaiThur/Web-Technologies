﻿using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Common.Models
{
    public class StatisticsVM : IMapWith<Statistics>
    {
        public DeliveryTimeInfo? DeliveryTimeInfo { get; init; }

        public JobsComplexityKeeper? JobsComplexity { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Statistics, StatisticsVM>();
        }
    }
}
