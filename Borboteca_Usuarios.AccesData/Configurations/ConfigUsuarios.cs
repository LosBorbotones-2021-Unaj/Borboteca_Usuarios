using Borboteca_Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.AccesData.Configurations
{
   public class ConfigUsuarios
    {
        public ConfigUsuarios(EntityTypeBuilder<Usuarios> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Apellido).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Contraseña).HasMaxLength(256).IsRequired().IsRequired();
        }
    }
}
