using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAssociados.Repositories;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(i =>
                                    i.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,     
                                        ValidateAudience = true,  
                                        ValidateLifetime = false,
                                        ValidateIssuerSigningKey = true,
                                        ValidAudience = "AppLoginAssociados",
                                        ValidIssuer = "AppLoginAssociados",
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenLoginTeste123"))
                                    }
                    );
            services.AddMvc();
            services.AddDbContext<DataContext>(x =>
               x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAssociadoRepository, AssociadoRepository>();
            services.AddScoped<IEstadoCivilRepository, EstadoCivilRepository>();
            services.AddScoped<IParentescoRepository, ParentescoRepository>();
            services.AddScoped<IDependenteRepository, DependenteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
