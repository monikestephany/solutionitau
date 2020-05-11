using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace itau.conta.api.core.Utils
{
    public static class Validations
    {
        public static bool VerificarMaioridade(DateTime DataNascimento)
        {
            int AnoBase = DateTime.Today.Year - 18;
            if (DataNascimento.Year < AnoBase)
            {
                return true;
            }
            if (AnoBase == DataNascimento.Year)
            {
                if (DataNascimento.Month < DateTime.Now.Month)
                {
                    return true;
                }
                if (DataNascimento.Month == DateTime.Now.Month)
                {
                    if (DataNascimento.Day <= DateTime.Now.Day)
                    {
                        return true;
                    }
                }
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
        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            //define a expressão regulara para validar o email
            string texto_Validar = enderecoEmail;
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

            // testa o email com a expressão
            if (expressaoRegex.IsMatch(texto_Validar))
            {
                // o email é valido
                return true;
            }
            else
            {
                // o email é inválido
                return false;
            }
        }
    }
}
