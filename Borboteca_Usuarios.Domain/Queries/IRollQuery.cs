using Borboteca_Usuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Domain.Queries
{
    public interface IRollQuery
    {
        public Roll GetRollById(int id);
    }
}
