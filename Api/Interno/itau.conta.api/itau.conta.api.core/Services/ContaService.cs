using FluentValidation;
using itau.conta.api.core.Contracts.Repositories;
using itau.conta.api.core.Contracts.Services;
using itau.conta.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository repository;
        private readonly IValidator<Conta> validator;
        public ContaService(IContaRepository repository, IValidator<Conta> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public Conta Create(Conta cliente)
        {
            var lastAg = repository.GetLastAgencia() == null ? "1" : repository.GetLastAgencia().NumeroAgencia;
            var lastCo = repository.GetLastConta() == null ? "1" : repository.GetLastConta().NumeroConta;
            cliente.GerarNovaAgencia(int.Parse(lastAg));
            cliente.GerarNovaConta(int.Parse(lastCo));
            cliente.GerarSenha();
            validator.Validate(cliente);
            return repository.Create(cliente);
        }
        public void Delete(string id)
        {
            var cliente = repository.GetId(id);
            repository.Remove(cliente);
        }
        public List<Conta> GetAll()
        {
            return repository.Get();
        }
        public Conta Update(string id, Conta cliente)
        {     
            var original = repository.GetId(id);
            original.Update(cliente);
            validator.Validate(original);
            return repository.Update(id, original);
        }
        public Conta UpdateSenha(string id, int senha)
        {
            var original = repository.GetId(id);
            original.UpdateSenha(senha);
            validator.Validate(original);
            return repository.Update(id, original);
        }
    }
}

