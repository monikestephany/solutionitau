using System;
using System.Collections.Generic;
using System.Text;

namespace itau.mqconsumer.ws.core.Model
{
    public class Log
    {
        public string Horario { get; set; }
        public string Host { get; set; }
        public string Status { get; set; }
        public object Exception { get; set; }
    }
}
