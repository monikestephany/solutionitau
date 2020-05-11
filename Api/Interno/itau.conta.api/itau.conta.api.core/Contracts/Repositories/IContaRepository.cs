using itau.conta.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Contracts.Repositories
{
    public interface IContaRepository
    {
        Conta Create(Conta clube);
        List<Conta> Get();
        Conta GetId(string id);
        Conta GetLastAgencia();
        Conta GetLastConta();
        void Remove(Conta clubeIn);
        Conta Update(string id, Conta clubeIn);
    }
}
