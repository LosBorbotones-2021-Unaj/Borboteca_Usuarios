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

namespace Borboteca_Usuarios.AccesData.Queries
{
    public class FavoritoQuery : IFavoritoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public FavoritoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<Favoritos> GetFavoritosPorIdPerson(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            var query= db.Query("Favoritos").Where("UsuariosId", "=", id).Select();
            return query.Get<Favoritos>().ToList();
        }

        public Usuarios GetUsuarioPorId(int idUsuario)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("id", "=", idUsuario).FirstOrDefault<Usuarios>();
        }

        //public Usuarios GetUsuarioPorId(int idUsuario)
        //{
        //    var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);

        //    Usuarios usuario= db.Query("Usuarios").Where("id", "=", idUsuario).FirstOrDefault<Usuarios>();
        //    Roll roll = db.Query("Roll").Where("id", "=", usuario.Roll).FirstOrDefault<Roll>();
        //    Usuarios NewUser = new Usuarios
        //    {
        //        Nombre = usuario.Nombre,
        //        Apellido = usuario.Apellido,
        //        Email = usuario.Email,
        //        Roll = roll,
        //        Contraseña = usuario.Contraseña
        //    };
        //    return NewUser;
        //}
    }
}
