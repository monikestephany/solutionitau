using itau.cliente.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Contracts.Repositories
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente clube);
        List<Cliente> Get();
        Cliente GetId(string id);
        Cliente GetCPF(string cpf);
        bool CPFExists(string cpf);
        void Remove(Cliente clubeIn);
        Cliente Update(string id, Cliente clubeIn);
    }
}
