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



        //metodo de prueba
        public Usuarios GetById(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("id", "=", id).FirstOrDefault<Usuarios>();

        }

        public UsuarioVistaDTO GetbypassEncrypt(string email, string password)
        {
            return (from x in context.Usuarios 
                  
                           where x.Email == email && x.Contraseña == password
                           select new UsuarioVistaDTO { id = x.Id ,Nombre=x.Nombre,Apellido=x.Apellido,Email=x.Email ,Rollid = x.Rollid}).FirstOrDefault<UsuarioVistaDTO>();

          
        }

        public Usuarios GetUsuarioByEmail(string email)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            return db.Query("Usuarios").Where("email", "=", email).FirstOrDefault<Usuarios>();
        }
    }
}
