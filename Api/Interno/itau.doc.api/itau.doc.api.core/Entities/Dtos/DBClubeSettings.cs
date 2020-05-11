using itau.doc.api.core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Entities.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string DocCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
