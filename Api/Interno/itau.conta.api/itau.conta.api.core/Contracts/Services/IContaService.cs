using itau.conta.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Contracts.Services
{
   public interface IContaService
    {
        List<Conta> GetAll();
        Conta Create(Conta cliente);
        Conta Update(string id, Conta cliente);
        Conta UpdateSenha(string id, int senha);
        void Delete(string id);
    }
}
