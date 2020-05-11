using itau.conta.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.ext.api.core.Contracts
{
    public interface IRabbitService
    {
        bool AddQueue(Conta conta);
    }
}
