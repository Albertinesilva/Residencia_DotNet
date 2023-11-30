using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recursos
{
    public class Medico : Pessoa
    {
        public string CRM { get; set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
            : base(nome, dataNascimento, cpf, idade: 0)
        {
            if (!ValidarCRM(crm))
            {
                throw new ArgumentException("CRM inválido");
            }
            CRM = crm;
        }

        private bool ValidarCRM(string crm)
        {
            foreach (char c in crm)
            {

                if (!char.IsDigit(c))
                {
                    return false;
                }

            }

            return true;
        }

    }
}