using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Services
{
    public interface IServiceRoll
    {
        public RollDTO GetRollById(int id);

    }
    public class ServiceRoll : IServiceRoll
    {
        private readonly IGenericsRepository _repository;
        private readonly IRollQuery _query;

        public ServiceRoll(IGenericsRepository repository, IRollQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public RollDTO GetRollById(int id)
        {
            return _query.GetRollById(id);
        }
    }
}
