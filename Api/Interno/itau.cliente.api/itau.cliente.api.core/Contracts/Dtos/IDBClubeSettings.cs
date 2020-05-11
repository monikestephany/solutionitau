using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Contracts.Dtos
{
    public interface IDBClubeSettings
    {
        string ClienteCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
