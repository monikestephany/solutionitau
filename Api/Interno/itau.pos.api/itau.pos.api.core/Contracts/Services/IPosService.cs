using itau.pos.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Contracts.Services
{
   public interface IPosService
    {
        List<Pos> GetAll();
        Pos Create(Pos cliente);
        void Delete(string id);
    }
}
