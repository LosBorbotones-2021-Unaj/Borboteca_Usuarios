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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/Favorito")]
    public class FavoritoController : Controller
    {
        private readonly IServiceFavorito _Service;

        public FavoritoController(IServiceFavorito service)
        {
            _Service = service;
        }
        [HttpGet]
        public IActionResult GetFavoritosPorIdPerson(int id)
        {
            var response = new ResponseDTO<List<FavoritoDTO>>();
            response = _Service.GetFavoritosPorIdPerson(id);

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
            try
            {
                return new JsonResult(_Service.AgregarFavorito(favoritoDto)) { StatusCode = 201 }; 
            }
            catch (Exception e)
            {

                return BadRequest(new {e.Message });
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
