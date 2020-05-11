using itau.pos.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Contracts.Repositories
{
    public interface IPosRepository
    {
        Pos Create(Pos clube);
        List<Pos> Get();
        Pos GetId(string id);
        void Remove(Pos clubeIn);
        Pos Update(string id, Pos clubeIn);
    }
}
