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
using Borboteca_Usuarios.Domain.DTO;

namespace Borboteca_Usuarios.AccesData.Queries
{
    public class RollQuery : IRollQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public RollQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public RollDTO GetRollById(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Roll").Where("id", "=", id).FirstOrDefault<RollDTO>();
        }
    }
}
