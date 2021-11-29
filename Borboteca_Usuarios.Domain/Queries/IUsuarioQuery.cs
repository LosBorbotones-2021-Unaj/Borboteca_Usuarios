using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Domain.Queries
{
    public interface IUsuarioQuery
    {
        public UsuarioVistaDTO GetUsuarioById(int id);
        public List<Usuarios> GetAll();
     
        public Usuarios GetById(int id);
        public UsuarioVistaDTO GetbypassEncrypt(string email, string password);

        public Usuarios GetUsuarioByEmail(string email);
    }
}
