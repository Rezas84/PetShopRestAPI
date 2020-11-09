using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PetShop.Core.AplicationServices.Interfaces;
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Core.DomainServices.Services;
using PetShop.Infrastracture.Entity;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;
using PetShop.RestAPI.ApplicationServices;

namespace PetShop.RestAPI
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
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddDbContext<PetShopAppContext>(
                opt => opt.UseSqlServer("Data Source=LAPTOP-4URTQQAP\\MSSQLSERVER2019;Initial Catalog=PetShop;User ID=sa;Password=vika12345")
                );
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetValidatorService, PetValidatorService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerservice, OwnerService>();
            services.AddScoped<IOwnerValidatorService, OwnerValidatorService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetTypeValidatorService, PetTypeValidatorService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IAuthenticationService>(new
                AuthenticationService(secretBytes));
            services.AddControllers();
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    })
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               using (var scope = app.ApplicationServices.CreateScope()) 
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
                    var authenticationService = scope.ServiceProvider.GetService<IAuthenticationService>();
                    DbInitializer.DbSeed(ctx, authenticationService);

                }

            }
            app.UseCors();
            app.UseRouting();
            // Use authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            init(serviceProvider);
        }
        private void init(IServiceProvider serviceProvider)
        {
            IPetRepository petRepository = (IPetRepository)serviceProvider.GetService(typeof(IPetRepository));
            IPetTypeRepository petTypeRepository = (IPetTypeRepository)serviceProvider.GetService(typeof(IPetTypeRepository));
            IOwnerRepository ownerRepository = (IOwnerRepository)serviceProvider.GetService(typeof(IOwnerRepository));
            //petTypeRepository.Init();
            //ownerRepository.Init();
            /// petRepository.Init();

        }
    }
}
