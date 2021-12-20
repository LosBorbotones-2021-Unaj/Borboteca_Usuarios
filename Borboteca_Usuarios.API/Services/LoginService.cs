using Borboteca_Usuarios.API.Models;
using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Services
{
    public class LoginService : ILoginService
    {

        private readonly IConfiguration _config;
        private string JwtKey;
        private readonly IUsuarioService _service;
        //clase de prueba
        private readonly IUsuarioQuery userQuery;

        public LoginService(IConfiguration config, IUsuarioService service, IUsuarioQuery userQuery) 
        {
            this._config = config;
            this.JwtKey = _config.GetSection("JwtSettings:Secret").Value;
            this._service = service;
            this.userQuery = userQuery;
        }

        public ResponseDTO<Token> Authenticate(LoginModel model)
        {

            var response = new ResponseDTO<Token>();
            try
            {
                UsuarioVistaDTO user = userQuery.GetbypassEncrypt(model.Email, model.Password);

                if (user == null)
                {
                    return null;
                }

                Token token = new Token { 
                token= GenerateJwtToken(user)
                } ;

                response.Data.Add(token);
                return response;
            }
            catch (Exception e)
            {

                response.Response.Add(e.Message);
                return response;
            }

        }

        public Usuarios GetById(int id)
        {
            throw new NotImplementedException();
        }


        private string GenerateJwtToken(UsuarioVistaDTO usuario) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keys = Encoding.ASCII.GetBytes(JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id",  usuario.id.ToString()), new Claim("Rollid",usuario.Rollid.ToString()),new Claim("nombre", usuario.Nombre)}),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keys), SecurityAlgorithms.HmacSha256Signature),
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokens);


        }
    }
}
