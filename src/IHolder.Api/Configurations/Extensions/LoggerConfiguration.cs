using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.SqlServer;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;


namespace IHolder.Api.Configurations.Extensions
{
    public static class LoggerConfiguration
    {

        public static IServiceCollection AddLoggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "3f005f20b0fc4bebac5924698b13ce44";
                o.LogId = new Guid("3d92b498-fc4e-4230-8b73-04d041e29cb2");
            });

            services.AddLogging(builder =>
            {
                builder.Services.AddElmahIo(o =>
               {
                   o.ApiKey = "3f005f20b0fc4bebac5924698b13ce44";
                   o.LogId = new Guid("3d92b498-fc4e-4230-8b73-04d041e29cb2");
               });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Information);
            });

            services.AddHealthChecks()
            .AddElmahIoPublisher(options =>
            {
                options.ApiKey = "3f005f20b0fc4bebac5924698b13ce44";
                options.LogId = new Guid("3d92b498-fc4e-4230-8b73-04d041e29cb2");
                options.HeartbeatId = "1";
            })
            .AddCheck("Banco de dados populado", new SqlServerHealthCheck(configuration.GetConnectionString("IHolderConnectionDemo"), "SELECT TOP 1 1 FROM TIPOINVESTIMENTO"))
            .AddSqlServer(configuration.GetConnectionString("IHolderConnectionDemo"), name: "BancoSQL");
            services.AddHealthChecksUI();
            return services;
        }

        public static IApplicationBuilder UseLoggerConfiguration(this IApplicationBuilder app)
        {
            const string healthCheckApiPath = "/health-checks";
            app.UseElmahIo();
            app.UseHealthChecks(healthCheckApiPath,
            new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecksUI(options =>
            {
                options.UIPath = $"{healthCheckApiPath}-ui";
                options.ApiPath = $"{healthCheckApiPath}-api";
                options.UseRelativeApiPath = false;
                options.UseRelativeResourcesPath = false;
            });
            return app;
        }

    }
}
