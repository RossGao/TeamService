using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using TeamService.BusinessLogic;
using TeamService.Dtos;
using TeamService.LocationClient;
using TeamService.Models;

namespace TeamService
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
            var locationServiceUrl = Configuration.GetSection("Url:LocationService").Value;
            services.AddSingleton<ILocationClient>(new LocationClientService(new Uri(locationServiceUrl)));
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamLogic, TeamLogic>();
            services.AddDbContext<TeamContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("Team"));
            });
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Team Service API", Version = "v1" });
                //var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, ".xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Development;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(errorApp => // Universe exception handling.
            {
                errorApp.Run(async context =>   // Add the middleware to handle exception.
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();   // Use the feature to get exception info.
                    if (error != null)
                    {
                        var ex = error.Error;
                        var logger = LogManager.GetCurrentClassLogger();
                        logger.Error(ex, "Internal server error.");

                        await context.Response.WriteAsync((new ErrorDto()
                        {
                            Code = 500,
                            Message = "Internal server error."
                        }).ToString(), Encoding.UTF8);
                    }
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Team Service API");
            });

            app.UseMvc();
        }
    }
}
