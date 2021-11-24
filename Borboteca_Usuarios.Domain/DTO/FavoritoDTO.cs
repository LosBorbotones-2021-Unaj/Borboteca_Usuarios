using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Domain.DTO
{
  public class FavoritoDTO

    {
        public Guid  Libro { get; set; }
        public int  idUsuario { get; set; }
    }
}
