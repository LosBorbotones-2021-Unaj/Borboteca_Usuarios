using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Domain.Queries
{
    public interface IFavoritoQuery
    {
        public List<Favoritos> GetFavoritosPorIdPerson(int id);
        Usuarios GetUsuarioPorId(int idUsuario);
    }
}
