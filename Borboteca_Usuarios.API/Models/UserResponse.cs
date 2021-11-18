using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Models
{
    public class UserResponse
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }


        public UserResponse(UsuarioVistaDTO usuario, string token) 
        {
            Id = usuario.id;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
            Token = token;
        }
    }
}
