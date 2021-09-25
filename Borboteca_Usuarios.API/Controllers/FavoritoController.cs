using Borboteca_Usuarios.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Controllers
{
    [ApiController]
    [Route("api/Favorito")]
    public class FavoritoController : Controller
    {
        private readonly IServiceFavorito _Service;

        public FavoritoController(IServiceFavorito service)
        {
            _Service = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetFavoritosPorIdPerson(int id)
        {
            try
            {
                return new JsonResult(_Service.GetFavoritosPorIdPerson(id)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(new { error = "No se devuelve nada" + e.Message });
            }
        }
    }
}
