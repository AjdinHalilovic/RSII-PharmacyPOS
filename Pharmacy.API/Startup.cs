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
using Pharmacy.Core.Constants;
using Pharmacy.Core.Constants.Configurations;
//using NSwag;
using Microsoft.OpenApi.Models;
using Pharmacy.Infrastructure.Contexts.Base;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Infrastructure.UnitOfWorks;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Infrastructure.Services.IService;
using Pharmacy.Infrastructure.Services.Service;
using Pharmacy.Api.Mobile.Helpers.Culture;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Pharmacy.Api.Mobile.Helpers;
using Microsoft.AspNetCore.Http;

namespace Pharmacy.API
{
    public class Startup
    {
        #region Properties

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppSettingsConfiguration _appSettingsConfiguration = new AppSettingsConfiguration();

        #endregion

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

            BuildConfiguration().Bind("Configuration", _appSettingsConfiguration);
        }

        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder().SetBasePath(_hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName.ToLowerInvariant()}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        //public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMainServices(services);
            ConfigureDatabases(services);
            ConfigureDataUnitOfWork(services);
            ConfigureCustomServices(services);
            ConfigureAuthorization(services);
            ConfigureMvc(services);


            services.AddControllers();

        }

        private void ConfigureMainServices(IServiceCollection services)
        {
            if (!_hostingEnvironment.IsDevelopment())
                services.Configure<MvcOptions>(options => {
                    options.EnableEndpointRouting = false;
                    //options.Filters.Add(new RequireHttpsAttribute());
                });
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContextPool<PharmacyContext>(options =>
                options.UseNpgsql(_appSettingsConfiguration.Database.BaseConnectionString));
            
        }

        private static void ConfigureDataUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IDataUnitOfWork, DataUnitOfWork>();
        }

        private void ConfigureCustomServices(IServiceCollection services)
        {
            #region Core

            services.AddSingleton(_appSettingsConfiguration);
            services.AddSingleton(_appSettingsConfiguration.Database);
            //_appSettingsConfiguration.Token = new TokenConfiguration()
            //{
            //    Issuer = "https://localhost:58643",
            //    Audience = "https://localhost:58643",
            //    SecurityString = "E48VLW8JF8UTMPZNR801QD9DPAZ75625HNU59YSU",
            //    AccessExpiresInMinutes = 20,
            //    RefreshExpiresInMinutes = 1440
            //};
            services.AddSingleton(_appSettingsConfiguration.Token); //docker ex

            #endregion

            #region Core - helpers
            services.AddScoped<ITokenProcessor, TokenProcessor>();
            #endregion

            #region Data access layer
            services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Helpers
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICulture, Culture>();
            #endregion
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_appSettingsConfiguration.Token.SecurityString)),

                        ValidateIssuer = true,
                        ValidIssuer = _appSettingsConfiguration.Token.Issuer,
                        ValidateAudience = true,
                        ValidAudience = _appSettingsConfiguration.Token.Audience,

                        RequireExpirationTime = true, //false
                        ValidateLifetime = true
                    };
                });
        }

        private static void ConfigureMvc(IServiceCollection services)
        {
            services.AddDistributedMemoryCache()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                //.AddJsonOptions(options => { options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm"; });
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new DateTimeConverter()); });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "ToDo API",
            //        Description = "A simple example ASP.NET Core Web API",
            //        TermsOfService = new Uri("https://example.com/terms"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Ajdin Halilović",
            //            Email = "ajdin.halilovic@edu.fit.ba",
            //            Url = new Uri("https://twitter.com/spboyer"),
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "Use under LICX",
            //            Url = new Uri("https://example.com/license"),
            //        }
            //    });
            //});

            services.AddRouting(options => options.LowercaseUrls = true);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects(Configuration.ErrorsPath).UseHsts();
            }

            //// Register the Swagger generator and the Swagger UI middlewares
            //app.UseOpenApi(); // Doesn't work on this verion of .net core
            app.UseSwagger(); // There is old method but works on this version of .net
                              //app.UseSwaggerUi3();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
