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
        public int  Libro { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
