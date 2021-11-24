using Borboteca_Usuarios.Domain.DTO;
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
        public List<FavoritoDTO> GetFavoritosPorIdPerson(int id);
        Usuarios GetUsuarioPorId(int idUsuario);
        Favoritos deleteFavorito(FavoritoDTO favorito);
        FavoritoDTO existefavorito(FavoritoDTO favorito);
    }
}
