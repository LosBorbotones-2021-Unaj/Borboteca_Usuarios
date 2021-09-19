using Borboteca_Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.AccesData.Configurations
{
    class ConfigRoll
    {
        public ConfigRoll(EntityTypeBuilder<Roll> BuilderRoll)
        {
            BuilderRoll.HasKey(x => x.Id);
            BuilderRoll.Property(x => x.Descripcion).HasMaxLength(200);
        }
    }
}
