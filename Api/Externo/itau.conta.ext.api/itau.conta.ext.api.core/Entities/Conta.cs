using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.ext.api.core.Entities
{
    public class Conta
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; private set; }
        public string DigitoAgencia { get; private set; }
        public string DigitoConta { get; private set; }
        public int Senha { get; private set; }
    }
  
}
