using Borboteca_Usuarios.AccesData;
using Borboteca_Usuarios.AccesData.Command;
using Borboteca_Usuarios.AccesData.Queries;
using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Borboteca_Usuarios.API", Version = "v1" });
            });
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(connectionString));
            services.AddTransient<Compiler, SqlServerCompiler>(); // injeccion de dependencia a las querys concretas
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IRollQuery, RollQuery>();
            services.AddTransient<IServiceRoll, ServiceRoll>();
            services.AddTransient<IFavoritoQuery, FavoritoQuery>();
            services.AddTransient<IServiceFavorito, ServiceFavorito>();
            

            services.AddCors(options =>
            {
                options.AddPolicy("AnyAllow", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Borboteca_Usuarios.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AnyAllow");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
