using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;
using Borboteca_Usuarios.Domain.DTO;

namespace Borboteca_Usuarios.AccesData.Queries
{
    public class FavoritoQuery : IFavoritoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly ApplicationDbContext context;

        public FavoritoQuery(IDbConnection connection, Compiler sqlKataCompiler, ApplicationDbContext context)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            this.context = context;
        }

        public void deleteFavorito(FavoritoDTO favorito)
        {
            Favoritos fav = (from x in context.Favoritos where x.Usuariosid == favorito.idUsuario && x.Libroid == favorito.Libro select x).FirstOrDefault<Favoritos>();
            context.Remove<Favoritos>(fav);
        }

        public FavoritoDTO existefavorito(FavoritoDTO favorito)
        {
            FavoritoDTO fav = (from x in context.Favoritos where x.Usuariosid == favorito.idUsuario && x.Libroid == favorito.Libro select new FavoritoDTO { idUsuario = x.Usuariosid, Libro = x.Libroid }).FirstOrDefault<FavoritoDTO>();
            return fav;
        }

        public List<FavoritoDTO> GetFavoritosPorIdPerson(int id)
        {
            return (from x in context.Favoritos where x.Id == id select new FavoritoDTO { Libro = x.Libroid, idUsuario = x.Usuariosid }).ToList<FavoritoDTO>();
        }

        public Usuarios GetUsuarioPorId(int idUsuario)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("id", "=", idUsuario).FirstOrDefault<Usuarios>();
        }

       
    }
}
