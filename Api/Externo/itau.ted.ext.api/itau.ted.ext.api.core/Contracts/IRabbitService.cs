using itau.ted.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.ext.api.core.Contracts
{
    public interface IRabbitService
    {
        bool AddQueue(Ted ted);
    }
}
