using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Services.Impl
{
    class AuthService :IAuthService
    {


        public bool validateLogin(string user, string password) 
        {
            return true;
        }

        public string GenerateToken(DateTime date, Usuarios user, TimeSpan validDate ) 
        {
            var expire = date.Add(validDate);
            return null;
        }
    }
}
