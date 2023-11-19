using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P002
{
    public class Tarefa
    {
        private static int proximoId = 1;
        private int id;
        private string titulo;
        private string descricao;
        private DateTime dataCriacao, dataVencimento;
        private bool concluida;
        private List<Tarefa> tarefas;

        public Tarefa()
        {
            this.titulo = "";
            this.descricao = "";
            this.concluida = false;
            tarefas = new List<Tarefa>();
        }
        public Tarefa(string titulo, string descricao, DateTime dataVencimento)
        {
            this.id = proximoId++;
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataCriacao = DateTime.Now;
            this.dataVencimento = dataVencimento;
            tarefas = new List<Tarefa>();
        }

        public string getTitulo()
        {
            return this.titulo;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public int getId()
        {
            return this.id;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public DateTime getDataCriacao()
        {
            return this.dataCriacao;
        }

        public void setDataCriacao(DateTime dataCriacao)
        {
            this.dataCriacao = dataCriacao;
        }

        public DateTime getDataVencimento()
        {
            return this.dataVencimento;
        }

        public void setDataVencimento(DateTime dataVencimento)
        {
            this.dataVencimento = dataVencimento;
        }

        public bool getConcluida()
        {
            return this.concluida;
        }

        public void setConcluida(bool concluida)
        {
            this.concluida = concluida;
        }

        public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }

        public void SetTarefas(List<Tarefa> novaListaDeTarefas)
        {
            tarefas = novaListaDeTarefas;
        }

        public void adicionar()
        {
            Console.WriteLine("\n\t========== CADASTRAR TAREFA ==========");
            Console.Write("\n\tInforme o Título: ");
            string? titulo = Console.ReadLine();
            titulo = convertePrimeiraLetraParaMaiuscula(titulo);

            Console.Write("\n\tInforme a Descrição: ");
            string? descricao = Console.ReadLine();
            descricao = convertePrimeiraLetraParaMaiuscula(descricao);

            Console.Write("\n\tInforme a Data de Vencimento (no formato dd/MM/yyyy): ");
            DateTime dataVencimento = LerDataDoUsuario();

            Tarefa tarefa = new Tarefa(titulo, descricao, dataVencimento);

            tarefas.Add(tarefa);
            buscaPorId(tarefa.getId());
            Console.Write("\tTarefa cadastrada com sucesso, pressione Enter para continuar... ");
            Console.ReadLine();
        }

        public void listar()
        {
            int opcao = 0;

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
            else
            {
                Console.Write("\n\tDeseja listar as tarefas concluídas ou não concluídas?\n\n\t[1] - TAREFAS CONCLUÍDAS\n\t[2] - TAREFAS PENDENTES\n\t[3] - LISTAR TODAS AS TAREFAS\n\t[0] - VOLTAR\n\tENTRADA -> ");
                opcao = Int32.Parse(Console.ReadLine());
                LimparTela();

                if (opcao == 0)
                {
                    return;
                }
                else
                {
                    if (opcao != 1 && opcao != 2 && opcao != 3)
                    {
                        Console.WriteLine("\n\tOpção inválida, pressione Enter para continuar... ");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        if (opcao == 1)
                        {
                            // Verificar se há pelo menos uma tarefa concluída na lista
                            bool temTarefaConcluida = tarefas.Any(tarefa => tarefa.getConcluida());
                            int i = 1;

                            if (!temTarefaConcluida)
                            {
                                Console.WriteLine("\n\tOps, nenhuma tarefa concluída!");
                                Console.Write("\n\tPressione Enter para continuar... ");
                                Console.ReadLine();
                                return;
                            }

                            Console.WriteLine("\n\t======= LISTAR TAREFAS CONCLUÍDAS =======");

                            foreach (Tarefa tarefa in tarefas)
                            {
                                if (tarefa.getConcluida())
                                {
                                    Console.WriteLine("\tTarefa: " + (i++) + "º");
                                    Console.WriteLine("\tID: " + tarefa.getId());
                                    Console.WriteLine("\tTítulo: " + tarefa.getTitulo());
                                    Console.WriteLine("\tDescrição: " + tarefa.getDescricao());
                                    Console.WriteLine("\tData de Criação: " + tarefa.getDataCriacao());
                                    Console.WriteLine("\tData de Vencimento: " + tarefa.dataVencimento.ToString("dd/MM/yyyy"));
                                    Console.WriteLine("\tConcluída: Sim");
                                    Console.WriteLine("\t=======================================");
                                }
                            }
                            Console.Write("\tPressione Enter para continuar... ");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (opcao == 2)
                            {
                                bool temTarefaConcluida = tarefas.Any(tarefa => !tarefa.getConcluida());
                                int i = 1;

                                if (!temTarefaConcluida)
                                {
                                    Console.WriteLine("\n\tOps, nenhuma tarefa não concluída!");
                                    Console.Write("\n\tPressione Enter para continuar... ");
                                    Console.ReadLine();
                                    return;
                                }

                                Console.WriteLine("\n\t======= LISTAR TAREFAS PENDENTES =======");

                                foreach (Tarefa tarefa in tarefas)
                                {
                                    if (!tarefa.getConcluida())
                                    {
                                        Console.WriteLine("\tTarefa: " + (i++) + "º");
                                        Console.WriteLine("\tID: " + tarefa.getId());
                                        Console.WriteLine("\tTítulo: " + tarefa.getTitulo());
                                        Console.WriteLine("\tDescrição: " + tarefa.getDescricao());
                                        Console.WriteLine("\tData de Criação: " + tarefa.getDataCriacao());
                                        Console.WriteLine("\tData de Vencimento: " + tarefa.getDataVencimento().ToString("dd/MM/yyyy"));
                                        Console.WriteLine("\tConcluída: Não");
                                        Console.WriteLine("\t========================================");
                                    }
                                }
                                Console.Write("\tPressione Enter para continuar... ");
                                Console.ReadLine();

                            }
                            else
                            {
                                if (opcao == 3)
                                {
                                    int i = 1;

                                    Console.WriteLine("\n\t======= LISTAR TODAS AS TAREFAS =======");

                                    foreach (Tarefa tarefa in tarefas)
                                    {
                                        Console.WriteLine("\tTarefa: " + (i++) + "º");
                                        Console.WriteLine("\tID: " + tarefa.getId());
                                        Console.WriteLine("\tTítulo: " + tarefa.getTitulo());
                                        Console.WriteLine("\tDescrição: " + tarefa.getDescricao());
                                        Console.WriteLine("\tData de Criação: " + tarefa.getDataCriacao());
                                        Console.WriteLine("\tData de Vencimento: " + tarefa.getDataVencimento().ToString("dd/MM/yyyy"));
                                        Console.WriteLine("\tConcluída: " + tarefa.getConcluida());
                                        Console.WriteLine("\t=======================================");
                                    }
                                    Console.Write("\tPressione Enter para continuar... ");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void editar()
        {

            Console.WriteLine("\n\t========== EDITAR TAREFA ==========");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                return;
            }

            Console.Write("\n\tInforme o ID da tarefa que deseja editar: ");
            int id = Int32.Parse(Console.ReadLine());

            Tarefa tarefa = tarefas.Find(t => t.getId() == id);

            if (tarefa != null)
            {
                Console.Write("\n\tInforme o novo Título: ");
                string? titulo = Console.ReadLine();
                
                titulo = convertePrimeiraLetraParaMaiuscula(titulo);

                Console.Write("\n\tInforme a nova Descrição: ");
                string? descricao = Console.ReadLine();

                descricao = convertePrimeiraLetraParaMaiuscula(descricao);

                Console.Write("\n\tInforme a Data de Vencimento (no formato dd/MM/yyyy): ");
                DateTime dataVencimento = LerDataDoUsuario();

                tarefa.setDataVencimento(dataVencimento);
                tarefa.setTitulo(titulo);
                tarefa.setDescricao(descricao);

                buscaPorId(tarefa.getId());
                Console.WriteLine("\tTarefa editada com sucesso!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa encontrada com o ID informado!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
        }

        public void excluir()
        {

            Console.WriteLine("\n\t========== EXCLUIR TAREFA ==========");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                return;
            }

            Console.Write("\n\tInforme o ID da tarefa que deseja excluir: ");
            int id = Int32.Parse(Console.ReadLine());

            Tarefa tarefa = tarefas.Find(t => t.getId() == id);

            if (tarefa != null)
            {
                buscaPorId(id);
                Console.Write("\tPressione Enter para continuar com a exclusão... ");
                Console.ReadLine();
                LimparTela();

                tarefas.Remove(tarefa);
                if (tarefas.Count == 0)
                {
                    Console.WriteLine("\tTarefa excluída com sucesso!");
                    Console.Write("\n\tPressione Enter para continuar... ");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\tTarefa excluída com sucesso!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                LimparTela();
                listar();
            }
            else
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa encontrada com o ID informado!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
        }

        public void marcarTarefaComoConcluida()
        {

            Console.WriteLine("\n\t========== MARCAR TAREFA COMO CONCLUÍDA ==========");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                return;
            }

            Console.Write("\n\tInforme o ID da tarefa que deseja marcar como concluída: ");
            int id = Int32.Parse(Console.ReadLine());

            Tarefa tarefa = tarefas.Find(t => t.getId() == id);

            if (tarefa != null)
            {
                tarefa.setConcluida(true);
                buscaPorId(tarefa.getId());
                Console.WriteLine("\tTarefa marcada como concluída com sucesso!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa encontrada com o ID informado!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
        }

        public void pesquisar()
        {

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n\t========== PESQUISAR TAREFA ==========");

            Console.Write("\n\tInforme o id da tarefa que deseja pesquisar: ");
            int id = Int32.Parse(Console.ReadLine());

            Tarefa tarefa = tarefas.Find(t => t.getId() == id);

            if (tarefa != null)
            {
                LimparTela();
                Console.WriteLine("\n\t========== TAREFA ENCONTRADA ==========");
                Console.WriteLine("\tID: " + tarefa.getId());
                Console.WriteLine("\tTítulo: " + tarefa.getTitulo());
                Console.WriteLine("\tDescrição: " + tarefa.getDescricao());
                Console.WriteLine("\tData de Criação: " + tarefa.getDataCriacao());
                Console.WriteLine("\tData de Vencimento: " + tarefa.dataVencimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tConcluída: " + tarefa.getConcluida());
                Console.WriteLine("\t=======================================");
                Console.Write("\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
            else
            {
                LimparTela();
                Console.WriteLine("\n\tOps, nenhuma tarefa encontrada com o Título informado!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
            }
        }

        public void estatisticas()
        {
            int numeroDeTarefasConcluidas = 0;
            int numeroDeTarefasNaoConcluidas = 0;
            int i = 1;

            Console.WriteLine("\n\t========== ESTATÍSTICAS BASEADA EM DATA E TAREFA CONCLUÍDA ==========");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("\n\tOps, nenhuma tarefa cadastrada!");
                Console.Write("\n\tPressione Enter para continuar... ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n\t========== TAREFAS ATRASADAS ==========");
            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa.getConcluida())
                {
                    numeroDeTarefasConcluidas++;
                }
                else
                {
                    numeroDeTarefasNaoConcluidas++;
                }

                if (tarefa.getDataCriacao() < DateTime.Now)
                {
                    Console.WriteLine("\tTarefa: " + (i++) + "º");
                    Console.WriteLine("\tID: " + tarefa.getId());
                    Console.WriteLine("\tTítulo: " + tarefa.getTitulo());
                    Console.WriteLine("\tDescrição: " + tarefa.getDescricao());
                    Console.WriteLine("\tData de Criação: " + tarefa.getDataCriacao());
                    Console.WriteLine("\tData de Vencimento: " + tarefa.getDataVencimento().ToString("dd/MM/yyyy"));
                    Console.WriteLine("\tConcluída: " + tarefa.getConcluida());
                    Console.WriteLine("\t=======================================");
                }

            }

            Console.WriteLine("\n\tNúmero de tarefas concluídas: " + numeroDeTarefasConcluidas);
            Console.WriteLine("\tNúmero de tarefas não concluídas: " + numeroDeTarefasNaoConcluidas);
            Console.Write("\n\tPressione Enter para continuar... ");
            Console.ReadLine();
        }

        public void buscaPorId(int id)
        {

            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].getId() == id)
                {
                    LimparTela();
                    Console.WriteLine("\n\t=============== TAREFA =================");
                    Console.WriteLine("\tID: " + tarefas[i].getId());
                    Console.WriteLine("\tTítulo: " + tarefas[i].getTitulo());
                    Console.WriteLine("\tDescrição: " + tarefas[i].getDescricao());
                    Console.WriteLine("\tData de Criação: " + tarefas[i].getDataCriacao());
                    Console.WriteLine("\tData de Vencimento: " + tarefas[i].getDataVencimento().ToString("dd/MM/yyyy"));
                    Console.WriteLine("\tConcluída: " + tarefas[i].getConcluida());
                    Console.WriteLine("\t========================================");
                    return;
                }
            }

        }

        static void LimparTela()
        {
            // Limpar a tela no Windows ou Linux
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.Clear(); // Windows
            }
            else
            {
                Console.Write("\u001b[2J\u001b[1;1H"); // Linux
            }
        }

        static DateTime LerDataDoUsuario()
        {
            DateTime data;

            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.Write("\tFormato de data inválido. Tente novamente (dd/mm/aaaa): ");
            }

            return data;
        }

        static String convertePrimeiraLetraParaMaiuscula(string palavra)
        {
            string palavraComMaiuscula = "";
            bool converteu = true;

            do
            {
                // Verifica se a string não está vazia
                if (!string.IsNullOrEmpty(palavra))
                {
                    // Converte a primeira letra para maiúscula
                    palavraComMaiuscula = char.ToUpper(palavra[0]) + palavra.Substring(1);
                    converteu = false;
                }
                else
                {
                    Console.WriteLine("\n\tA string está vazia.");
                    Console.Write("\tPressione Enter para continuar... ");
                    Console.ReadLine();
                    LimparTela();

                    Console.Write("\n\tInforme o Título: ");
                    palavra = Console.ReadLine();
                }
            } while (converteu);

            return palavraComMaiuscula;
        }

    }
}