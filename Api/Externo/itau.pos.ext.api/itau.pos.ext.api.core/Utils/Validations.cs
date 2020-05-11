using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static itau.pos.ext.api.core.Entities.Enum.PosEnum;

namespace itau.pos.ext.api.core.Utils
{
    public static class Validations
    {
        public static bool ValidarCartao(string numeroCartao, Bandeira bandeira)
        {
            string nrCartao = numeroCartao.Replace("-", "");
            switch (bandeira)
            {
                case Bandeira.VISA:
                    if (Regex.IsMatch(nrCartao, "^(4)"))
                        return nrCartao.Length == 13 || nrCartao.Length == 16;
                    break;
                case Bandeira.MASTERCARD:
                    if (Regex.IsMatch(nrCartao, "^(51|52|53|54|55)"))
                        return nrCartao.Length == 16;
                    break;
                case Bandeira.AMEX:
                    if (Regex.IsMatch(nrCartao, "^(34|37)"))
                        return nrCartao.Length == 15;
                    break;
                case Bandeira.DINERS:
                    if (Regex.IsMatch(nrCartao, "^(300|301|302|303|304|305|36|38)"))
                        return nrCartao.Length == 14;
                    break;
            }
            return false;
        }
        public static bool ValidateCPF(string vrCPF)
        {
            if (string.IsNullOrEmpty(vrCPF))
                return false;

            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;

        }
    }
}
