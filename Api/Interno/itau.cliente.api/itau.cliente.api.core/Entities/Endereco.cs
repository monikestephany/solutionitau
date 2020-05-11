using System;
using System.Collections.Generic;
using System.Text;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.core.Entities
{
    public class Endereco
    {
        public string Logradouro { get;  set; }
        public int Numero { get;  set; }
        public string Complemento { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string CEP { get;  set; }
        public TipoEndereco TipoEndereco { get;  set; }
        public bool Principal { get;  set; }
    }
}
