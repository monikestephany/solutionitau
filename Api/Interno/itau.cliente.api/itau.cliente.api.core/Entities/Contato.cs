using System;
using System.Collections.Generic;
using System.Text;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.core.Entities
{
    public class Contato
    {
        public int Numero { get;  set; }
        public int DDD { get;  set; }
        public TipoContato Tipo { get;  set; }
    }
}
