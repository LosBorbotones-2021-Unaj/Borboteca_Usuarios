using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.DTO;
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
        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                return new JsonResult(_service.GetUsuarioById(id)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }

        [HttpPost]
        public IActionResult guardarUsuario(UsuarioDTO usuarioDto) {
            try
            {
               return new JsonResult(_service.AgregarUsuario(usuarioDto)) { StatusCode = 201};
            }
            catch (Exception e) {
                return BadRequest(new { error = "no se crea nada" + e.Message });
            }
        }
    }
}
