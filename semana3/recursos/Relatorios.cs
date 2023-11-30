using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recursos
{
    public class Relatorios
    {
        ListPaciente pacientes;

        public Relatorios(ListPaciente pacientes)
        {
            this.pacientes = pacientes;
        }

        public void MenuRelatorios()
        {

            do
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== RELATÓRIOS ==========");
                Console.WriteLine("\t[1] - PACIENTE COM IDADE ENTRE DOIS VALORES");
                Console.WriteLine("\t[2] - PACIENTE DO SEXO INFORMADO");
                Console.WriteLine("\t[3] - PACIENTE EM ORDEM ALFABÉTICA");
                Console.WriteLine("\t[4] - PACIENTE CUJO SINTOMA CONTENHA TEXTO");
                Console.WriteLine("\t[5] - PACIENTE ANIVERSARIANTE DO MÊS");
                Console.WriteLine("\t[0] - MENU PRINCIPAL");
                Console.Write("\tENTRADA -> ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            RelatorioPacienteIdadeEntreDoisValores();
                            break;

                        case 2:
                            RelatorioPacienteDoSexoInformado();
                            break;

                        case 3:
                            RelatorioPacienteEmOrdemAlfabetica();
                            break;

                        case 4:
                            RelatorioPacienteCujoSintomaContenhaTexto();
                            break;

                        case 5:
                            RelatorioPacienteAniversarioMes();
                            break;

                        case 0:
                            Console.WriteLine("\n\tOps, retornando ao menu prncipal!...");
                            App.Pause();
                            return;

                        default:
                            Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\tPor favor, insira um valor numérico válido.");
                }

            } while (true);
        }

        public void RelatorioPacienteIdadeEntreDoisValores()
        {
            Console.WriteLine("\n\t========== RELATÓRIO DE PACIENTES COM IDADE ENTRE DOIS VALORES ==========");
            Console.Write("\n\tDigite o valor mínimo: ");
            int valorMinimo = int.Parse(Console.ReadLine()!);

            Console.Write("\n\tDigite o valor máximo: ");
            int valorMaximo = int.Parse(Console.ReadLine()!);

            var pacientesFiltrados = pacientes.GetPacientes().Where(paciente => paciente.Idade >= valorMinimo && paciente.Idade <= valorMaximo);

            if (pacientesFiltrados.Any())
            {
                Console.WriteLine("\n\tPACIENTES ENCONTRADOS:");
                foreach (var paciente in pacientesFiltrados)
                {
                    Console.WriteLine($"\n\tNome: {paciente.Nome}");
                    Console.WriteLine($"\tIdade: {paciente.Idade}");
                    Console.WriteLine($"\tCPF: {paciente.Cpf}");
                    Console.WriteLine($"\tSexo: {paciente.Sexo}");
                    Console.WriteLine($"\tSintomas: {paciente.Sintomas}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }

        public void RelatorioPacienteDoSexoInformado()
        {
            if (pacientes.GetPacientes() == null)
            {
                Console.WriteLine("\n\tLista de pacientes não fornecida. Retornando ao menu.");
                App.Pause();
                return;
            }

            Console.WriteLine("\n\t========== RELATÓRIO DE PACIENTES DO SEXO INFORMADO ==========");
            Console.Write("\n\tDigite o sexo: ");
            string sexo = Console.ReadLine()!;

            var pacientesFiltrados = pacientes.GetPacientes().Where(paciente => paciente.Sexo == sexo);

            if (pacientesFiltrados.Any())
            {
                Console.WriteLine("\n\tPACIENTES ENCONTRADOS:");
                foreach (var paciente in pacientesFiltrados)
                {
                    Console.WriteLine($"\n\tNome: {paciente.Nome}");
                    Console.WriteLine($"\tIdade: {paciente.Idade}");
                    Console.WriteLine($"\tCPF: {paciente.Cpf}");
                    Console.WriteLine($"\tSexo: {paciente.Sexo}");
                    Console.WriteLine($"\tSintomas: {paciente.Sintomas}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }
        public void RelatorioPacienteEmOrdemAlfabetica()
        {
            Console.WriteLine("\n\t========== RELATÓRIO DE PACIENTES EM ORDEM ALFABÉTICA ==========");


            var pacientesOrdenados = pacientes.GetPacientes().OrderBy(paciente => paciente.Nome);

            if (pacientesOrdenados.Count() > 0)
            {
                Console.WriteLine("\n\tPACIENTES ENCONTRADOS:");
                foreach (var paciente in pacientesOrdenados)
                {
                    Console.WriteLine($"\n\tNome: {paciente.Nome}");
                    Console.WriteLine($"\tIdade: {paciente.Idade}");
                    Console.WriteLine($"\tCPF: {paciente.Cpf}");
                    Console.WriteLine($"\tSexo: {paciente.Sexo}");
                    Console.WriteLine($"\tSintomas: {paciente.Sintomas}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }

        public void RelatorioPacienteCujoSintomaContenhaTexto()
        {
            Console.WriteLine("\n\t========== RELATÓRIO DE PACIENTES CUJO SINTOMA CONTENHA TEXTO ==========");
            Console.Write("\n\tDigite o texto: ");
            string texto = Console.ReadLine()!;

            var pacientesFiltrados = pacientes.GetPacientes().Where(paciente => paciente.Sintomas.Contains(texto));

            if (pacientesFiltrados.Count() > 0)
            {
                Console.WriteLine("\n\tPACIENTES ENCONTRADOS:");
                foreach (var paciente in pacientesFiltrados)
                {
                    Console.WriteLine($"\n\tNome: {paciente.Nome}");
                    Console.WriteLine($"\tIdade: {paciente.Idade}");
                    Console.WriteLine($"\tCPF: {paciente.Cpf}");
                    Console.WriteLine($"\tSexo: {paciente.Sexo}");
                    Console.WriteLine($"\tSintomas: {paciente.Sintomas}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }

        public  void RelatorioPacienteAniversarioMes()
        {
            Console.WriteLine("\n\t========== RELATÓRIO DE PACIENTES ANIVERSARIANTES DO MÊS ==========");

            var pacientesFiltrados = pacientes.GetPacientes().Where(paciente => paciente.DataNascimento.Month == DateTime.Now.Month);

            if (pacientesFiltrados.Count() > 0)
            {
                Console.WriteLine("\n\tPACIENTES ENCONTRADOS:");
                foreach (var paciente in pacientesFiltrados)
                {
                    Console.WriteLine($"\n\tNome: {paciente.Nome}");
                    Console.WriteLine($"\tIdade: {paciente.Idade}");
                    Console.WriteLine($"\tCPF: {paciente.Cpf}");
                    Console.WriteLine($"\tSexo: {paciente.Sexo}");
                    Console.WriteLine($"\tSintomas: {paciente.Sintomas}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }
    }
}