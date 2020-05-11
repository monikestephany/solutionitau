using FluentValidation;
using itau.cliente.api.core.Contracts.Repositories;
using itau.cliente.api.core.Contracts.Services;
using itau.cliente.api.core.Entities;
using itau.cliente.api.core.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IValidator<Cliente> validator;
        public ClienteService(IClienteRepository clienteRepository, IValidator<Cliente> validator)
        {
            this.clienteRepository = clienteRepository;
            this.validator = validator;
        }

        public Cliente Create(Cliente cliente)
        {
            validator.Validate(cliente);
            return clienteRepository.Create(cliente);
        }

        public void Delete(string id)
        {
            var cliente = clienteRepository.GetId(id);
             clienteRepository.Remove(cliente);
        }

        public List<Cliente> GetAll()
        {
            return clienteRepository.Get();
        }

        public Cliente GetCPF(string cpf)
        {
            return clienteRepository.GetCPF(cpf);
        }

        public Cliente Update(string id,Cliente cliente)
        {
            var clienteOriginal = clienteRepository.GetId(id);
            clienteOriginal.Update(cliente);
            validator.Validate(clienteOriginal);
            return clienteRepository.Update(id, clienteOriginal);
        }
    }
}
