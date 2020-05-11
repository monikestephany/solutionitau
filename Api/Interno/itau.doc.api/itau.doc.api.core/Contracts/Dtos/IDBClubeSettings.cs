using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Contracts.Dtos
{
    public interface IDBClubeSettings
    {
        string DocCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
