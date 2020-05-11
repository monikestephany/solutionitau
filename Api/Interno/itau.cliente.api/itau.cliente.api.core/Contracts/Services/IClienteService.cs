using itau.cliente.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Contracts.Services
{
    public interface IClienteService
    {
        List<Cliente> GetAll();
        Cliente GetCPF(string cpf);
        Cliente Create(Cliente cliente);
        Cliente Update(string id,Cliente cliente);
        void Delete(string id);
    }
}
