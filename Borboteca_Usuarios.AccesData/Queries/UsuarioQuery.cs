using Borboteca_Usuarios.AccesData.Command;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using Cqrs.Repositories.Queries;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Execution;


namespace Borboteca_Usuarios.AccesData.Queries
{
    
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public UsuarioQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<Usuarios> GetAll()
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Usuarios");
            var result = query.Get<Usuarios>();
            return result.ToList();
        }

        public Usuarios GetUsuarioById(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("id","=",id).FirstOrDefault<Usuarios>();

        }
    }
}
