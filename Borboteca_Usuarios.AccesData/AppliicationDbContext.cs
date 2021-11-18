using Borboteca_Usuarios.AccesData.Configurations;
using Borboteca_Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.AccesData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new ConfigFavoritos(modelBuilder.Entity<Favoritos>());
            new ConfigRoll(modelBuilder.Entity<Roll>());
            new ConfigUsuarios(modelBuilder.Entity<Usuarios>());
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roll>(entity =>
            {
                entity.ToTable("Roll");
                entity.HasData(new Roll
                {
                    Id = 1,
                    Descripcion = "user"
                });
                entity.HasData(new Roll
                {
                    Id=2,
                    Descripcion="admin"
                });
            });
           
        }
       

        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roll> Roll { get; set; }
       

    }
}
