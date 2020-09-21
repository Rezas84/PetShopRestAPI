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
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Core.DomainServices.Services;

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
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetValidatorService, PetValidatorService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerservice, OwnerService>();
            services.AddScoped<IOwnerValidatorService, OwnerValidatorService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetTypeValidatorService, PetTypeValidatorService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            init(serviceProvider);
        }
        private void init (IServiceProvider serviceProvider)
        {
            IPetRepository petRepository = (IPetRepository)serviceProvider.GetService(typeof(IPetRepository));
            IPetTypeRepository petTypeRepository = (IPetTypeRepository)serviceProvider.GetService(typeof(IPetTypeRepository));
            IOwnerRepository ownerRepository = (IOwnerRepository)serviceProvider.GetService(typeof(IOwnerRepository));
            petTypeRepository.Init();
            ownerRepository.Init();
            petRepository.Init();

        }
    }
}
