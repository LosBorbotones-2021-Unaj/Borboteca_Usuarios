﻿using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.Entities;
using Borboteca_Usuarios.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Services
{
    public interface IServiceFavorito
    {
        List<Favoritos> GetFavoritosPorIdPerson(int id);
    }
    public class ServiceFavorito : IServiceFavorito
    {
        private readonly IGenericsRepository _repository;
       private readonly IFavoritoQuery _query;

        public ServiceFavorito(IGenericsRepository repository, IFavoritoQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public List<Favoritos> GetFavoritosPorIdPerson(int id)
        {
            return _query.GetFavoritosPorIdPerson(id);
        }
    }
}
