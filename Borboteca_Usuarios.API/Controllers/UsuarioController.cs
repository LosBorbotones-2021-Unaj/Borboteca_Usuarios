using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        public IActionResult guardarUsuario(UsuarioDTO usuarioDto) {
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
    }
}
