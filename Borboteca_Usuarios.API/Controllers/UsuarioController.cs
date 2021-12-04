using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Borboteca_Usuarios.Domain.Entities;

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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetResult()
        {
            var response = _service.MostrarUsuarios();
            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 404 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
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
      

        [HttpPost]
        public IActionResult guardarUsuario([FromBody] UsuarioDTO usuarioDto) {

            if (verificarSiExisteUsuario(usuarioDto.Email))
            {
                UsuarioExistente usuarioExistente = new UsuarioExistente();
                usuarioExistente.EmailExistente ="Existente";
                return new JsonResult(usuarioExistente) { StatusCode = 409 };
            }

            if (!ModelState.IsValid)
            {
                //return new JsonResult(ModelState) { StatusCode = 400 };
            }
            

            var response = new ResponseDTO<UsuarioVistaDTO>();
            response = _service.AgregarUsuario(usuarioDto);
            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 400 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }
           
        }

        private bool verificarSiExisteUsuario(String email) 
        {
            Usuarios usuario= _service.GetUsuarioByEmail(email);

            if (usuario==null)
            {
                return false;
            }

            return true;

        }

        private class UsuarioExistente { 

            public string EmailExistente { get; set; }

        }
    }
}
