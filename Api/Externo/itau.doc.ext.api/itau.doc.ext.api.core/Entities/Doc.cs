using System;
using System.Collections.Generic;
using System.Text;
using static itau.doc.ext.api.core.Entities.Enum.DocEnum;

namespace itau.doc.ext.api.core.Entities
{
    public class Doc
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public decimal Tarifa { get; private set; }
        public Remetente Remetente { get; set; }
        public Destinatario Destinatario { get; set; }
        public MeioTranferencia Meio { get; set; }
    }
  
}
