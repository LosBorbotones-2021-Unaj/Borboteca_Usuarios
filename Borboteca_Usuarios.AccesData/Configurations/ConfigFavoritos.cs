using Borboteca_Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.AccesData.Configurations
{
    class ConfigFavoritos
    {
        public ConfigFavoritos(EntityTypeBuilder<Favoritos> BuilderFavorito)
        {
            BuilderFavorito.HasKey(x => x.Id);
            
        }
    }
}
