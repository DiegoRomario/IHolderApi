using FluentValidation;
using IHolder.Application.Base;
using IHolder.Business.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace IHolder.Api.Configurations.Extensions
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfigurations(this IServiceCollection services)
        {
            Assembly assembly = AppDomain.CurrentDomain.Load("IHolder.Application");
            AssemblyScanner.FindValidatorsInAssembly(assembly)
                 .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(assembly);
            return services;
        }
    }
}
