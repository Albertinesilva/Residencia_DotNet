using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace recursos
{
    public class ListPaciente
    {
        public List<Paciente> Pacientes { get; set; }

        public ListPaciente()
        {
            Pacientes = new List<Paciente>();
        }

        public void AddPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void RemovePaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        public void RemovePaciente(string cpf)
        {
            Pacientes.RemoveAll(paciente => paciente.Cpf == cpf);
        }

        public List<Paciente> GetPacientes()
        {
            return Pacientes;
        }

        public void Cadastrar()
        {
            Console.Write("\n\tDigite o nome do paciente: ");
            string nome = Console.ReadLine()!;
            nome = Paciente.ConvertePrimeiraLetraParaMaiuscula(nome);

            string cpf;
            do
            {
                Console.Write("\n\tDigite o CPF do paciente: ");
                cpf = Console.ReadLine()!;

                if (!Paciente.IsValidCPF(cpf) || !Paciente.IsCpfUnico(cpf, Pacientes))
                {
                    Console.WriteLine("\n\tOps, CPF inválido ou já existe no cadastro. Por favor, digite um CPF válido.");
                    App.Pause();
                }

            } while (!Paciente.IsValidCPF(cpf) || !Paciente.IsCpfUnico(cpf, Pacientes));

            DateTime dataNascimento = Paciente.ObterDataDeNascimento();

            string sexo = Paciente.ObterSexoValido("\n\tDigite o sexo do paciente: ");
            sexo = Paciente.ConvertePrimeiraLetraParaMaiuscula(sexo);

            Console.Write("\n\tDigite os sintomas do paciente: ");
            string sintomas = Console.ReadLine()!;  

            AddPaciente(new Paciente(nome, dataNascimento, cpf, sexo, sintomas));

        }

        public void Listar()
        {
            Console.WriteLine("\n\t=== Lista de Pacientes ===");
            foreach (Paciente paciente in Pacientes)
            {
                Console.WriteLine("\tNome: " + paciente.Nome);
                Console.WriteLine("\tCPF: " + paciente.Cpf);
                Console.WriteLine("\tData de Nascimento: " + paciente.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + paciente.Idade);
                Console.WriteLine("\tSexo: " + paciente.Sexo);
                Console.WriteLine("\tSintomas: " + paciente.Sintomas);
                Console.WriteLine("\t==========================\n");
            }
        }
    }
}