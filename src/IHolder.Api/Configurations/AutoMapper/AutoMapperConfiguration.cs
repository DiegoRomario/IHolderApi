﻿using AutoMapper;
using IHolder.Application.Mappings;
using IHolder.Data.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace IHolder.Api.Configurations.AutoMapper
{
    public static class AutoMapperProfileConfiguration
    {
        public static IServiceCollection AddAutoMapperProfileConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DomainToViewModelProfile),
                typeof(ViewModelToDomainProfile),
                typeof(CommandToDomainProfile),
                typeof(AutoMapperProfile)
                );
            return services;
        }
    }
}
