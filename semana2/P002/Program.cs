using System;
using System.Globalization;

namespace P002
{
  class Program
  {
    static void Main(string[] args)
    {
      Tarefa tarefa = new Tarefa();
      tarefaCrud(tarefa);
    }

    public static int menupPrincipal()
    {
      int opcao = -1;
      do
      {
        LimparTela();
        dataHoraAtual();
        Console.WriteLine("\t===== MENU PRINCIPAL =====");
        Console.WriteLine("\t[1] - ADICIONAR TAREFA");
        Console.WriteLine("\t[2] - LISTAR TAREFAS");
        Console.WriteLine("\t[3] - EDITAR TAREFA");
        Console.WriteLine("\t[4] - REMOVER TAREFA");
        Console.WriteLine("\t[5] - PESQUISAR TAREFA");
        Console.WriteLine("\t[6] - CONCLUIR TAREFA");
        Console.WriteLine("\t[7] - ESTATÍSTICAS COM DATA E TAREFA CONCLUÍDA");
        Console.WriteLine("\t[0] - SAIR");
        Console.Write("\tENTRADA -> ");
        string userInput = Console.ReadLine();

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

    public static void tarefaCrud(Tarefa tarefa)
    {
      int opcao = 0;
      do
      {
        opcao = menupPrincipal();
        switch (opcao)
        {
          case 1:
            LimparTela();
            tarefa.adicionar();
            break;

          case 2:
            LimparTela();
            tarefa.listar();
            break;

          case 3:
            LimparTela();
            tarefa.editar();
            break;

          case 4:
            LimparTela();
            tarefa.excluir();
            break;

          case 5:
            LimparTela();
            tarefa.pesquisar();
            break;

          case 6:
            LimparTela();
            tarefa.marcarTarefaComoConcluida();
            break;

          case 7:
            LimparTela();
            tarefa.estatisticas();
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

    static void dataHoraAtual()
    {

      var data = DateTime.Now;
      var formatada = string.Format("\n\t{0:f}", data);
      Console.WriteLine(formatada);
      Console.WriteLine("\tFalta " + (365 - data.DayOfYear) + " dias para o fim do ano.\n");
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
    
    static void Pause()
    {
      Console.Write("\n\tPressione Enter para continuar...");
      Console.ReadLine();
    }
  }

}
