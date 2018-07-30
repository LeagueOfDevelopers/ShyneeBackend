using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Services;
using ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories;
using ShyneeBackend.Infrastructure.Repositories.InMemoryRepositories;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace ShyneeBackend.Application
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
            // CONFIGURATION SETTINGS

            var defaultNickname = Configuration.GetValue<string>("App:DefaultNickname");
            var radiusAround = double.Parse(Configuration.GetValue<string>("App:RadiusAround"));

            // REPOSITORIES

            IShyneesRepository shyneesRepository;

            if (bool.Parse(Configuration.GetValue<string>("Database:IsInMemory")))
            {
                shyneesRepository = new InMemoryShyneesRepository();
            }
            else
            {
                shyneesRepository = new ShyneesRepository();
            }

            // SERVICES

            var shyneesService = new ShyneesService(shyneesRepository, defaultNickname, radiusAround);
            
            services.AddSingleton<IShyneesService>(shyneesService);

            // OTHER DEPENDENCIES

            services.AddMvc();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = Configuration["Swagger:Title"],
                    Version = Configuration["Swagger:Version"],
                    Description = Configuration["Swagger:Description"]
                });
                options.IncludeXmlComments(string.Format(@"{0}/ShyneeBackend.Application.xml",
                    AppDomain.CurrentDomain.BaseDirectory));
                options.IncludeXmlComments(string.Format(@"{0}/ShyneeBackend.Domain.xml",
                    AppDomain.CurrentDomain.BaseDirectory));
                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shynee API v1.0");
               });
        }
    }
}
