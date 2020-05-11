using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Contracts.Dtos
{
    public interface IDBClubeSettings
    {
        string ContaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
