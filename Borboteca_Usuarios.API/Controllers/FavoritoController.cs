using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Domain.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Controllers
{
   /* [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]*/
    [ApiController]
    [Route("api/Favorito")]
    public class FavoritoController : Controller
    {
        private readonly IServiceFavorito _Service;

        public FavoritoController(IServiceFavorito service)
        {
            _Service = service;
        }
        [HttpGet("{Usuarioid}")]
        public IActionResult GetFavoritosPorIdPerson(int Usuarioid)
        {
            var response = new ResponseDTO<List<FavoritoDTO>>();
            response = _Service.GetFavoritosPorIdPerson(Usuarioid);

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
        public IActionResult AgregarFavoritoDto(FavoritoDTO favoritoDto)
        {
            var response = new ResponseDTO<FavoritoDTO>();
            response = _Service.AgregarFavorito(favoritoDto);
            if (response.Response.Any())
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 201 };
            }
           
        }
        [HttpDelete]
        public IActionResult DeleteFavorito(FavoritoDTO favorito)
        {
            if (_Service.DeleteFavorito(favorito))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
