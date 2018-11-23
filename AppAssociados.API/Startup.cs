using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAssociados.Repositories;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AppAssociados.API
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
            services.AddDbContext<DataContext>(x =>
               x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAssociadoRepository, AssociadoRepository>();
            services.AddScoped<IEstadoCivilRepository, EstadoCivilRepository>();
            services.AddScoped<IParentescoRepository, ParentescoRepository>();
            services.AddScoped<IDependenteRepository, DependenteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
