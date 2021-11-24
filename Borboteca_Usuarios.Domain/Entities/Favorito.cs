using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Domain.Entities
{
    public class Favoritos
    {
        public int Id { get; set; }
        public Guid  Libroid { get; set; }
        public int Usuariosid { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
