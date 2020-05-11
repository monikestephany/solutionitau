using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Entities.Enum
{
    public static class ClienteEnum
    {
        public enum TipoContato
        {
            Celular,
            Telefone_Residencial,
            Telefone_Cormercial
        }
        public enum TipoEndereco
        {
            Residencial,
            Trabalho
        }
    }
}
