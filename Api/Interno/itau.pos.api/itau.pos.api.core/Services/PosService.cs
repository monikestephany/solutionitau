using FluentValidation;
using itau.pos.api.core.Contracts.Repositories;
using itau.pos.api.core.Contracts.Services;
using itau.pos.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Services
{
    public class PosService : IPosService
    {
        private readonly IPosRepository repository;
        private readonly IValidator<Pos> validator;
        public PosService(IPosRepository repository, IValidator<Pos> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public Pos Create(Pos cliente)
        {
            validator.Validate(cliente);
            return repository.Create(cliente);
        }

        public void Delete(string id)
        {
            var cliente = repository.GetId(id);
            repository.Remove(cliente);
        }

        public List<Pos> GetAll()
        {
            return repository.Get();
        }

    }
}
