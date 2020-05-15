using IHolder.Application.Interfaces;
using IHolder.Application.Interfaces.Services;
using IHolder.Application.Services;
using IHolder.Data.Context;
using IHolder.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using IHolder.Application.Queries;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Interfaces;
using IHolder.Application.Base;
using IHolder.Application.Interfaces.Notifications;
using IHolder.Application.Notifications;
using IHolder.Data.Repository.Base;

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
            services.AddTransient<IDistribuicaoPorTipoInvestimentoQueries, DistribuicaoPorTipoInvestimentoQueries>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAporteRepository, AporteRepository>();  
            services.AddScoped<IAtivoService, AtivoService>();

            services.AddScoped<ITipoInvestimentoService, TipoInvestimentoService>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IDistribuicaoPorTipoInvestimentoRepository, DistribuicaoPorTipoInvestimentoRepository>();
            services.AddScoped<IDistribuicaoPorTipoInvestimentoService, DistribuicaoPorTipoInvestimentoService>();

            services.AddScoped<IAporteRepository, AporteRepository>();
            services.AddScoped<IAporteService, AporteService>();



            return services;
        }
    }
}
