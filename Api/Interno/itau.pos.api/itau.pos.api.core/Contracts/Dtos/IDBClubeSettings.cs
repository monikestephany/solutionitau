using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Contracts.Dtos
{
    public interface IDBClubeSettings
    {
        string PosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
