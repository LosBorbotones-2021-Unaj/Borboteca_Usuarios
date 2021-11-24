﻿using Borboteca_Usuarios.AccesData.Command;
using Borboteca_Usuarios.AccesData.Queries;
using Borboteca_Usuarios.Application.Utilities;
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
        public UsuarioVistaDTO GetUsuarioById(int id);
        public ResponseDTO<Usuarios> MostrarUsuarios();
        public ResponseDTO<UsuarioVistaDTO> AgregarUsuario(UsuarioDTO usuarioDTO);
        
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

        public ResponseDTO<UsuarioVistaDTO> AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            var response = new ResponseDTO<UsuarioVistaDTO>();
            try
            {
                Usuarios usuario = new Usuarios
                {
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Email = usuarioDTO.Email,
                    Contraseña = Encrypt.GetSHA256(usuarioDTO.Contraseña),
                    Rollid = 1,

                };
                _repository.Add<Usuarios>(usuario);
                UsuarioVistaDTO usuarioVistaDTO = new UsuarioVistaDTO
                {
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Email = usuarioDTO.Email
                };
                response.Data.Add(usuarioVistaDTO);
                return response;
            }
            catch (Exception e)
            {
                response.Response.Add(e.Message);
                return response;
            }
           
        }

        public ResponseDTO<Usuarios> MostrarUsuarios()
        {
            var response = new ResponseDTO<Usuarios>();
            try
            {
                response.Data = _query.GetAll();
                return response;
            }
            catch (Exception e)
            {
                response.Response.Add(e.Message);
                return response;
                
            }
            
        }
        public UsuarioVistaDTO GetUsuarioById(int id)
        {
            return _query.GetUsuarioById(id);
        }

        
    }
}
