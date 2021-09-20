using Borboteca_Usuarios.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Controllers
{
    public class RollController : Controller
    {
        private readonly IServiceRoll _service;

        public RollController(IServiceRoll service)
        {
            _service = service;
        }

       [HttpGet("{id}")]
        public IActionResult GetRollById(int id)
        {
            try
            {
                return new JsonResult(_service.GetRollById(id)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }
    }
}
