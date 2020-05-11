using itau.cliente.api.core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.core.Entities.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string ClienteCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
