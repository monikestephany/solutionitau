using itau.pos.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.ext.api.core.Contracts
{
    public interface IRabbitService
    {
        bool AddQueue(Pos pos);
    }
}
