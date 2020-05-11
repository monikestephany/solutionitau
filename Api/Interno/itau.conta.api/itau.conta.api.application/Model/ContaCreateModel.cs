﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.conta.api.application.Model
{
    public class ContaCreateModel
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
