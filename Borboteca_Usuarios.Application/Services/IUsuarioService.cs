using Borboteca_Usuarios.AccesData.Command;
using Borboteca_Usuarios.AccesData.Queries;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Services
{
    public interface IUsuarioService
    {
        public Usuarios GetUsuarioById(int id);
        public List<Usuarios> MostrarUsuarios();
        public void AgregarUsuario(UsuarioDTO usuarioDTO);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericsRepository _repository;
        private readonly IUsuarioQuery _query;

        public UsuarioService(IGenericsRepository repository, IUsuarioQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public void AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            Usuarios usuarios = new Usuarios
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Email = usuarioDTO.Email,
                Contraseña = usuarioDTO.Contraseña
            };
            _repository.Add<Usuarios>(usuarios);
        }

        public List<Usuarios> MostrarUsuarios()
        {
            return _query.GetAll();
        }
        public Usuarios GetUsuarioById(int id)
        {
            return _query.GetUsuarioById(id);
        }
    }
}
