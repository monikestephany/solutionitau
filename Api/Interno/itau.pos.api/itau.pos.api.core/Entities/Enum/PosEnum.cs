using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.core.Entities.Enum
{
    public static class PosEnum
    {
        public enum TipoTransacao
        { 
            Debito = 1,
            Credito = 2
        }
        public enum Bandeira 
        {
            VISA = 1,
            MASTERCARD = 2,
            AMEX = 3,
            DINERS = 4
        }
    }
}
