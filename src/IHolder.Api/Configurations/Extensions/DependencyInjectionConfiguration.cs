﻿using IHolder.Domain.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Services;
using IHolder.Data.Context;
using IHolder.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using IHolder.Business.Queries;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Interfaces;
using IHolder.Business.Base;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Notifications;

namespace IHolder.Api.Configurations.Extensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHolderContext>();
            services.AddScoped<IResponse, Response>();
            services.AddScoped<INotifier, Notifier>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUser, AspNetUser>();
            services.AddTransient<IUsuarioQueries, UsuarioQueries>();
            services.AddTransient<IRepositoryBase<Usuario>, UsuarioRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAporteRepository, AporteRepository>();
            services.AddScoped<IAtivoRepository, AtivoRepository>();
            services.AddScoped<IAtivoService, AtivoService>();

            services.AddScoped<ITipoInvestimentoRepository, TipoInvestimentoRepository>();
            services.AddScoped<ITipoInvestimentoService, TipoInvestimentoService>();

            services.AddScoped<IRepositoryBase<Usuario>, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IDistribuicaoPorTipoInvestimentoRepository, DistribuicaoPorTipoInvestimentoRepository>();
            services.AddScoped<IDistribuicaoPorTipoInvestimentoService, DistribuicaoPorTipoInvestimentoService>();

            services.AddScoped<IAporteRepository, AporteRepository>();
            services.AddScoped<IAporteService, AporteService>();



            return services;
        }
    }
}
