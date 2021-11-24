using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Services
{
    public interface IServiceFavorito
    {
        ResponseDTO<List<FavoritoDTO>> GetFavoritosPorIdPerson(int id);
     
        object AgregarFavorito(FavoritoDTO favoritoDto);
        bool DeleteFavorito(FavoritoDTO favorito);
        public bool ExisteFavorito(FavoritoDTO favorito);
    }
    public class ServiceFavorito : IServiceFavorito
    {
        private readonly IGenericsRepository _repository;
       private readonly IFavoritoQuery _query;

        public ServiceFavorito(IGenericsRepository repository, IFavoritoQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public object AgregarFavorito(FavoritoDTO favoritoDto)
        {
            if (!ExisteFavorito(favoritoDto))
            {
                Favoritos favoritos = new Favoritos()
                {
                    Libroid = favoritoDto.Libro,
                    Usuariosid = favoritoDto.idUsuario
                };
                _repository.Add<Favoritos>(favoritos);
                return favoritoDto;
            }
            else
            {
                DeleteFavorito(favoritoDto);
                return favoritoDto;
            }
            

        }

        public bool DeleteFavorito(FavoritoDTO favorito)
        {
            try
            {
                _query.deleteFavorito(favorito);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExisteFavorito(FavoritoDTO favorito)
        {
            FavoritoDTO Favorito = _query.existefavorito(favorito);
            if (Favorito != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ResponseDTO<List<FavoritoDTO>> GetFavoritosPorIdPerson(int id)
        {
            var response = new ResponseDTO<List<FavoritoDTO>>();

            try
            {
                response.Data.Add(_query.GetFavoritosPorIdPerson(id));
                return response;
            }
            catch (Exception e)
            {
                response.Response.Add(e.Message);
                return response;
                
            }
        }
    }
}
