﻿using IHolder.Data.Context;
using IHolder.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using IHolder.Application.Queries;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Interfaces;
using IHolder.Application.Base;
using IHolder.Data.Repository.Base;
using MediatR;
using IHolder.Application.Queries.Distribuicoes;

namespace IHolder.Api.Configurations.Extensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IHandlerBase), typeof(HandlerBase));
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

            services.AddScoped<IHolderContext>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUser, AspNetUser>();
            services.AddTransient<IUsuarioQueries, UsuarioQueries>();
            services.AddTransient<IDistribuicaoPorTipoInvestimentoQueries, DistribuicaoPorTipoInvestimentoQueries>();
            services.AddTransient<IDistribuicaoPorAtivoQueries, DistribuicaoPorAtivoQueries>();
            services.AddScoped<IAporteRepository, AporteRepository>();  
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAporteRepository, AporteRepository>();




            return services;
        }
    }
}
