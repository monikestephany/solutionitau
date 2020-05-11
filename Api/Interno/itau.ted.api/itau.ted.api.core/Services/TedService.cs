using FluentValidation;
using itau.ted.api.core.Contracts.Repositories;
using itau.ted.api.core.Contracts.Services;
using itau.ted.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Services
{
    public class TedService : ITedService
    {
        private readonly ITedRepository repository;
        private readonly IValidator<Ted> validator;
        public TedService(ITedRepository repository, IValidator<Ted> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public Ted Create(Ted cliente)
        {
            cliente.CalcularTarifa();
            validator.Validate(cliente);
            return repository.Create(cliente);
        }
        public void Delete(string id)
        {
            var cliente = repository.GetId(id);
            repository.Remove(cliente);
        }
        public List<Ted> GetAll()
        {
            return repository.Get();
        }
    }
}
