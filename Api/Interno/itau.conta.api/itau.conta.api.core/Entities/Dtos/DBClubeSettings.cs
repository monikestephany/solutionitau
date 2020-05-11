using itau.conta.api.core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Entities.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string ContaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
