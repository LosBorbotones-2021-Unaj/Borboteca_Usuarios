﻿using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }


        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetResult()
        {
            try
            {
                return new JsonResult(_service.MostrarUsuarios()) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }

        }
        
        [HttpGet]
        [Route("FindById")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                return new JsonResult(_service.GetUsuarioById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }
        [HttpGet]
        [Route("getUsuario")]
        public IActionResult GetUsuarioByPassAndName(string email ,string contraseña)
        {
            var response = new ResponseDTO<UsuarioLocalStorageDTO>();
            response = _service.GetUsuarioByPassAndName(email, contraseña);
            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 404 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }
           
        }

        [HttpPost]
        public IActionResult guardarUsuario(UsuarioDTO usuarioDto) {
            var response = new ResponseDTO<UsuarioDTO>();

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }
            
            //   return new JsonResult(_service.AgregarUsuario(usuarioDto)) { StatusCode = 201};
           
        }
    }
}
