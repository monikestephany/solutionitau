using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.core.Utils
{
    public static class ContaUtils
    {
        public static string GerarSenhas()
        {
            StringBuilder listaResultado = new StringBuilder();
            Random randNum = new Random();

            for (int i = 0; i <= 5; i++)
                listaResultado.Append(randNum.Next(0,9));

            return listaResultado.ToString();
        }
    }
}
