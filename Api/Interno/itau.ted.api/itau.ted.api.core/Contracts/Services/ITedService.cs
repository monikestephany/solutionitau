using itau.ted.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Contracts.Services
{
   public interface ITedService
    {
        List<Ted> GetAll();
        Ted Create(Ted cliente);
        void Delete(string id);
    }
}
