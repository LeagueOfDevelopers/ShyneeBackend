using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.Jwt;
using ShyneeBackend.Application.Middlewares;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Services;
using ShyneeBackend.Domain.Settings;
using ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories;
using ShyneeBackend.Infrastructure.Repositories.InMemoryRepositories;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

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

            var applicationConfiguration = Configuration.GetSection("Application");
            var applicationSettings = new ApplicationSettings(
                applicationConfiguration["DefaultNickname"],
                applicationConfiguration.GetValue<double>("RadiusAround"),
                applicationConfiguration["UploadsFolderName"]);
            services.AddSingleton(applicationSettings);

            var securityConfiguration = Configuration.GetSection("Security");
            var securitySettings = new SecuritySettings(
                securityConfiguration["EncryptionKey"], 
                securityConfiguration["Issue"],
                securityConfiguration.GetValue<TimeSpan>("ExpirationPeriod"));
            services.AddSingleton(securitySettings);

            // REPOSITORIES

            IShyneesRepository shyneesRepository;

            if (Configuration.GetValue<bool>("Database:IsInMemory"))
            {
                shyneesRepository = new InMemoryShyneesRepository();
            }
            else
            {
                shyneesRepository = new ShyneesRepository();
            }

            // SERVICES

            var shyneesService = new ShyneesService(shyneesRepository, applicationSettings);
            var assetsService = new AssetsService(applicationSettings, shyneesService);
            
            services.AddSingleton<IShyneesService>(shyneesService);
            services.AddSingleton<IAssetsService>(assetsService);

            // OTHER DEPENDENCIES

            services.AddScoped<ModelValidationAttribute>();

            var jwtIssuer = new JwtIssuer(securitySettings);
            services.AddSingleton<IJwtIssuer>(jwtIssuer);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(securitySettings.EncryptionKey))
                    };
                });

            services
                .AddAuthorization(options =>
                {
                    options.DefaultPolicy =
                        new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser().Build();
                });

                    services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

            services.AddMvc(config => 
            {
                config.ReturnHttpNotAcceptable = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = Configuration["Swagger:Title"],
                    Version = Configuration["Swagger:Version"],
                    Description = Configuration["Swagger:Description"]
                });
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
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

            // MIDDLEWARES

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();

            app.UseCors("EnableCORS");

            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shynee API v1.0");
               });

            app.UseMvc();
        }
    }
}
