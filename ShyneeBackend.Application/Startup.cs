using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Services;
using ShyneeBackend.Infrastructure.Repositories;
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
            services.AddMvc();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = Configuration["App:Title"],
                    Version = Configuration["App:Version"],
                    Description = Configuration["App:Description"]
                });
                options.IncludeXmlComments(string.Format(@"{0}/ShyneeBackend.Application.xml", 
                    AppDomain.CurrentDomain.BaseDirectory));
                options.IncludeXmlComments(string.Format(@"{0}/ShyneeBackend.Domain.xml",
                    AppDomain.CurrentDomain.BaseDirectory));
                options.DescribeAllEnumsAsStrings();
            });

            services.AddSingleton<IShyneesService, ShyneesService>();

            services.AddSingleton<IShyneesRepository, ShyneesRepository>();
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
                   options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ranty API v1.0");
               });
        }
    }
}
