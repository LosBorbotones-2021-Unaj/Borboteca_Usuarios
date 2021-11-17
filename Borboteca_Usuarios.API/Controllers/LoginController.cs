using Borboteca_Usuarios.API.Models;
using Borboteca_Usuarios.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginService loginService;

        public LoginController(ILoginService loginService) 
        {
            this.loginService = loginService;           
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] LoginModel model)
        {
            var response = loginService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message ="usuario o contraseña incorrectos"});
            }


            return Ok(response);
        }
    }
}
