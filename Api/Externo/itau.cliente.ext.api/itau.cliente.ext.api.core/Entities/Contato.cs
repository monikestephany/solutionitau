using System;
using System.Collections.Generic;
using System.Text;
using static itau.cliente.ext.api.core.Entities.Enum.ClienteEnum;

namespace itau.cliente.ext.api.core.Entities
{
    public class Contato
    {
        public int Numero { get; set; }
        public int DDD { get; set; }
        public TipoContato Tipo { get; set; }
    }
}
