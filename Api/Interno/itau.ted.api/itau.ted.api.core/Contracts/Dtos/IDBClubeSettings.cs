using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Contracts.Dtos
{
    public interface IDBClubeSettings
    {
        string TedCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
