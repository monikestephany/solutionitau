using itau.ted.api.core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.core.Entities.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string TedCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
