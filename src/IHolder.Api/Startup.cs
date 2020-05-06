using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Configurations;
using IHolder.Api.Configurations.Extensions;
using IHolder.Api.Configurations.Middleware;
using IHolder.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IHolder.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IHolderContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IHolderConnectionDemo")));

            services.AddAutoMapper(typeof(Startup));

            DependencyInjectionConfiguration.ResolveDependencies(services);

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();

            services.AddAuthenticationConfiguration(Configuration);

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddLoggerConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

            //if (env.IsDevelopment())
            //{
            app.UseCors(policyName: "Development");
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseCors(policyName: "Development");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerConfiguration(env, provider);

            app.UseLoggerConfiguration();

        }
    }
}
