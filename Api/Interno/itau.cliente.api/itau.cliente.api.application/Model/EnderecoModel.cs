﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static itau.cliente.api.core.Entities.Enum.Enum;

namespace itau.cliente.api.application.Model
{
    public class EnderecoModel
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public bool Principal { get; set; }
    }
}
