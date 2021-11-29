using Borboteca_Usuarios.AccesData;
using Borboteca_Usuarios.AccesData.Command;
using Borboteca_Usuarios.AccesData.Queries;
using Borboteca_Usuarios.API.Services;
using Borboteca_Usuarios.API.Validator;
using Borboteca_Usuarios.Application.Sengrid;
using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

            services.AddMvc().AddFluentValidation();

            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(connectionString));
            services.AddTransient<Compiler, SqlServerCompiler>(); // injeccion de dependencia a las querys concretas
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();
            services.AddTransient<IUsuarioService, UsuarioService>();    
            services.AddTransient<IFavoritoQuery, FavoritoQuery>();
            services.AddTransient<IServiceFavorito, ServiceFavorito>();
            services.AddTransient<IMailService, SendGridEmailService>();
            services.AddTransient<IValidator<UsuarioDTO>, UsuarioValidator>();

            services.AddScoped<ILoginService, LoginService>();
            ////////////////////////////////////////////////////////////////////////////
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings:Secret").Value);
            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            /////////////////////////////////////////////////////////////////////////////

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

            app.UseAuthentication();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
