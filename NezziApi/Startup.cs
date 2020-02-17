using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using NezziApi.Interface;
using NezziApi.Persistence.Repository;
using NezziApi.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NezziApi.Helpers;
using NezziApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using NezziApi.Controllers;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Net.NetworkInformation;

namespace NezziApi
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
            services.AddCors();

            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            //// configure jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEducationCategoryRepository, EducationCategoryRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddDbContext<NezziDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NezziConnection")));

            services.AddHealthChecks()
                //.AddCheck("Foo", () =>
                //HealthCheckResult.Healthy("Foo is Ok!"), tags: new[] { "foo_tag" })
                //.AddCheck("Bar", () =>
                //HealthCheckResult.Healthy("Bar is NOk!"), tags: new[] { "bar_tag" })
                .AddCheck("Ping", () => {
                    try
                    {
                        using (var ping = new Ping())
                        {
                            var reply = ping.Send("localhost");
                            if(reply.Status != IPStatus.Success)
                            {
                                return HealthCheckResult.Unhealthy();
                            }
                            if (reply.RoundtripTime > 100)
                            {
                                return HealthCheckResult.Degraded();
                            }
                            return HealthCheckResult.Healthy();
                        }
                    }
                    catch
                    {
                        return HealthCheckResult.Unhealthy();
                    }
                })
                .AddCheck<ExampleHealthCheck>("sample", null, new[] { "sample"});


            services.AddSingleton(mapper);

            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapHealthChecks("/health");
            });

        }

        public class ExampleHealthCheck : IHealthCheck
        {
            public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
            {
                var healthCheckResultHealthy = true;

                if (healthCheckResultHealthy)
                {
                    return Task.FromResult(
                            HealthCheckResult.Healthy("A healthy result.")
                        );
                }

                return Task.FromResult(
                            HealthCheckResult.Unhealthy("A unhealthy result.")
                        );
            }
        }
    }
}
