using FluentValidation;
using itau.doc.api.core.Contracts.Repositories;
using itau.doc.api.core.Contracts.Services;
using itau.doc.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Services
{
    public class DocService : IDocService
    {
        private readonly IDocRepository repository;
        private readonly IValidator<Doc> validator;
        public DocService(IDocRepository repository, IValidator<Doc> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public Doc Create(Doc cliente)
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

        public List<Doc> GetAll()
        {
            return repository.Get();
        }
    }
}
