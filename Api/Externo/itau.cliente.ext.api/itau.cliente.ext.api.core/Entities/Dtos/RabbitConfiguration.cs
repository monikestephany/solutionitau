using itau.cliente.ext.api.core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Entities.Dtos
{
    public class RabbitConfiguration : IRabbitConfiguration
    {
        public string Queue { get; set; }
        public string RoutingKey { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
