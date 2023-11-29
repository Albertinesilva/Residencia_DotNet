using System;
using System.Collections.Generic;
using System.IO;

namespace P003
{
    public static class App
    {
        public static int ObterOpcaoMenuPrincipal()
        {
            int opcao = -1;
            do
            {
                LimparTela();
                DataHoraAtual();
                Console.WriteLine("\t===== CONTROLE DE ESTOQUE =====");
                Console.WriteLine("\t[1] - CADASTRAR");
                Console.WriteLine("\t[2] - LISTAR");
                Console.WriteLine("\t[3] - EDITAR");
                Console.WriteLine("\t[4] - REMOVER");
                Console.WriteLine("\t[5] - PESQUISAR");
                Console.WriteLine("\t[6] - ATUALIZAR ESTOQUE");
                Console.WriteLine("\t[7] - RELATÓRIOS");
                Console.WriteLine("\t[0] - SAIR");
                Console.Write("\tENTRADA -> ");
                string userInput = Console.ReadLine()!;


                if (!string.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out opcao))
                {
                    // A conversão foi bem-sucedida
                    if (opcao < 0 || opcao > 7)
                    {
                        Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                        Pause();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                    Pause();
                }

            } while (opcao > 7 || opcao < 0);

            return opcao;
        }
        public static void MenuEstoque(EstoqueService estoqueService)
        {
            estoqueService.CarregarArquivo();

            int opcao = 0;
            do
            {
                opcao = ObterOpcaoMenuPrincipal();
                switch (opcao)
                {
                    case 1:
                        LimparTela();
                        estoqueService.Cadastrar();
                        estoqueService.SalvarArquivo();
                        break;

                    case 2:
                        LimparTela();
                        estoqueService.Listar();
                        Pause();
                        break;

                    case 3:
                        LimparTela();
                        estoqueService.Editar();
                        estoqueService.SalvarArquivo();
                        Pause();
                        break;

                    case 4:
                        LimparTela();
                        estoqueService.Excluir();
                        estoqueService.SalvarArquivo();
                        break;

                    case 5:
                        LimparTela();
                        estoqueService.Pesquisar();
                        break;

                    case 6:
                        LimparTela();
                        estoqueService.AtualizarEstoque();
                        estoqueService.SalvarArquivo();
                        break;

                    case 7:
                        LimparTela();
                        estoqueService.GerarRelatorio();
                        break;

                    case 0:
                        Console.WriteLine("\n\tSaindo...");
                        break;

                    default:
                        Console.WriteLine("\n\tOpção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
        public static void DataHoraAtual()
        {

            var data = DateTime.Now;
            var formatada = string.Format("\n\t{0:f}", data);
            Console.WriteLine(formatada);
            Console.WriteLine("\tFalta " + (365 - data.DayOfYear) + " dias para o fim do ano.\n");
        }
        public static void LimparTela()
        {
            Console.Clear(); // Windows

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Console.Write("\u001b[2J\u001b[1;1H"); // Linux
            }
        }
        public static void Pause()
        {
            Console.Write("\n\tPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}