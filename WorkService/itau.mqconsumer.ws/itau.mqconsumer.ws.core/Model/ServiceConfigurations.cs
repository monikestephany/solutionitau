using System;
using System.Collections.Generic;
using System.Text;

namespace itau.mqconsumer.ws.core.Model
{
    public class ServiceConfigurations
    {
        public RabbitMq RabbitMq { get; set; }
        public int Intervalo { get; set; }
        public string APIRest { get; set; }
    }
    public class RabbitMq
    {
        public string Queue { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
