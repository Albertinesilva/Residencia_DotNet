using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recursos
{
    public class Paciente : Pessoa
    {
        public string Sexo { get; set; }
        public string Sintomas { get; set; }

        public Paciente(string nome, string cpf, string dataNascimento, sexo = "Não informado", string sintomas = "Não informado") : base(nome, cpf, dataNascimento)
        {
            if (sexo != "Não informado" && !IsSexo(sexo))
            {
                throw new ArgumentException("Inválida inserção de sexo (Insira (masculino) ou (feminino))");
            }

            this.Sexo = sexo;
            this.Sintomas = sintomas;
        }

        private bool IsSexo(string sexo)
        {
            return sexo == "masculino" || sexo == "feminino";
        }
    }
}