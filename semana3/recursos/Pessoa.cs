using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recursos
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }


        public string CPF
        {
            get { return cpf; }
            set
            {
                if (ValidarCPF(value))
                {
                    cpf = value;
                }
                else
                {
                    throw new ArgumentException("CPF inválido");
                }
            }
        }

        public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            if (!ValidarCPF(cpf))
            {
                throw new ArgumentException("CPF inválido");
            }
            else
            {
                CPF = cpf;
            }

        }

        static bool IsValidCPF(string cpf)
        {
            // Remover caracteres não numéricos
            string numbersOnly = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificar se o CPF possui 11 dígitos
            if (numbersOnly.Length != 11)
            {
                return false;
            }

            // Calcular os dígitos verificadores
            int[] cpfDigits = numbersOnly.Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += cpfDigits[i] * (10 - i);
            }

            int firstDigit = 11 - (sum % 11);
            if (firstDigit > 9)
            {
                firstDigit = 0;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += cpfDigits[i] * (11 - i);
            }

            int secondDigit = 11 - (sum % 11);
            if (secondDigit > 9)
            {
                secondDigit = 0;
            }

            // Verifica se os dígitos calculados correspondem aos dígitos informados no CPF
            return cpfDigits[9] == firstDigit && cpfDigits[10] == secondDigit;
        }
    }
}
}