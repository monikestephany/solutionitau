using itau.pos.api.core.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Entities.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string PosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
