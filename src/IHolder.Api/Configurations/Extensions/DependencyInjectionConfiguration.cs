using IHolder.Business.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Notifications;
using IHolder.Business.Repositories.Base;
using IHolder.Business.Services;
using IHolder.Data.Context;
using IHolder.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IHolder.Api.Configurations.Extensions.SwaggerConfiguration;

namespace IHolder.Api.Configurations.Extensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHolderContext>();
            services.AddScoped<INotifier, Notifier>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, AspNetUser>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAporteRepository, AporteRepository>();
            services.AddScoped<IAtivoRepository, AtivoRepository>();
            services.AddScoped<IAtivoService, AtivoService>();

            services.AddScoped<ITipo_investimentoRepository, Tipo_investimentoRepository>();
            services.AddScoped<ITipo_investimentoService, Tipo_investimentoService>();

            services.AddScoped<IRepositoryBase<Usuario>, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IDistribuicao_por_tipo_investimentoRepository, Distribuicao_por_tipo_investimentoRepository>();
            services.AddScoped<IDistribuicao_por_tipo_investimentoService, Distribuicao_por_tipo_investimentoService>();

            services.AddScoped<IAporteRepository, AporteRepository>();
            services.AddScoped<IAporteService, AporteService>();

            return services;
        }
    }
}
