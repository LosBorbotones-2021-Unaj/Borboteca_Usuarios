using Borboteca_Usuarios.API.Models;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.API.Services
{
    public interface ILoginService
    {
        ResponseDTO<Token> Authenticate(LoginModel usuario);

        Usuarios GetById(int id);
    }
}
