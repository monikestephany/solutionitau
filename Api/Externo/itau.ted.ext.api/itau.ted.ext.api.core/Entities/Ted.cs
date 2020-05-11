using System;
using System.Collections.Generic;
using System.Text;
using static itau.ted.ext.api.core.Entities.Enum.TedEnum;

namespace itau.ted.ext.api.core.Entities
{
    public class Ted
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public decimal Tarifa { get; private set; }
        public Remetente Remetente { get; set; }
        public Destinatario Destinatario { get; set; }
        public MeioTranferencia Meio { get; set; }
    }
  
}
