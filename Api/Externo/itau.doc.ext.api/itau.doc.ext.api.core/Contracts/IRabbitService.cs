using itau.doc.ext.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.ext.api.core.Contracts
{
    public interface IRabbitService
    {
        bool AddQueue(Doc doc);
    }
}
