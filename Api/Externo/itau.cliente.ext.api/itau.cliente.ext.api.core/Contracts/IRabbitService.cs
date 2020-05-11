using itau.cliente.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Contracts
{
    public interface IRabbitService
    {
        bool AddQueue(Cliente cliente);
    }
}
