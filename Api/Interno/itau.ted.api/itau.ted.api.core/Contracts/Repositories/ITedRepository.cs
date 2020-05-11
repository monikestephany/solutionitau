using itau.ted.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Contracts.Repositories
{
    public interface ITedRepository
    {
        Ted Create(Ted clube);
        List<Ted> Get();
        Ted GetId(string id);
        void Remove(Ted clubeIn);
        Ted Update(string id, Ted clubeIn);
    }
}
