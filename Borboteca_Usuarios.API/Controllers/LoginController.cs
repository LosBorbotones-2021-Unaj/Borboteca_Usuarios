using Borboteca_Usuarios.API.Models;
using Borboteca_Usuarios.API.Services;
using Borboteca_Usuarios.Application.Utilities;
using Borboteca_Usuarios.Domain.DTO;
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

        [HttpPost]
        public IActionResult login([FromBody] LoginModel model)
        {
            var userEncrypt = new LoginModel
            {
                Email = model.Email,
                Password = Encrypt.GetSHA256(model.Password)
            };
            var response = new ResponseDTO<Token>();
            response = loginService.Authenticate(userEncrypt);

            if (response.Response.Any())
            {
                return new JsonResult(response.Response) { StatusCode = 404 };
            }
            else
            {
                return new JsonResult(response.Data) { StatusCode = 200 };
            }
           
        }
    }
}
