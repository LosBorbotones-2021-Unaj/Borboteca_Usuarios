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
    
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly ApplicationDbContext context;

        public UsuarioQuery(IDbConnection connection, Compiler sqlKataCompiler, ApplicationDbContext context)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            this.context = context;
        }

        public List<Usuarios> GetAll()
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Usuarios");
            var result = query.Get<Usuarios>();
            return result.ToList();
        }

        public UsuarioVistaDTO GetUsuarioById(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("id","=",id).FirstOrDefault<UsuarioVistaDTO>();

        }

        public ResponseDTO<UsuarioLocalStorageDTO> GetUsuarioByPassAndName(string nombre, string contraseña)
        {
            var response = new ResponseDTO<UsuarioLocalStorageDTO>();
            var usuario = (from x in context.Usuarios
                           where x.Email == nombre && x.Contraseña == contraseña
                           select new UsuarioLocalStorageDTO { id = x.Id }).FirstOrDefault<UsuarioLocalStorageDTO>();

            if (object.ReferenceEquals(null, usuario))
            {
                response.Response.Add("No existe el usuario");
                return response;
            }
            else
            {
                response.Data.Add(usuario);
                return response;

            }
          

        }
    }
}
