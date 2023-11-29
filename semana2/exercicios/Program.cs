using System;
using System.Collections.Generic;
using System.Linq;
namespace exercicios
{
  class Program

  {
    static void Main(string[] args)
    {
      LimparTela();

       string cpf = "123.456.789-09";

        if (IsValidCPF(cpf))
        {
            Console.WriteLine("CPF válido.");
        }
        else
        {
            Console.WriteLine("CPF inválido.");
        }

        // Verificar se os dígitos calculados correspondem aos dígitos informados no CPF
        return cpfDigits[9] == firstDigit && cpfDigits[10] == secondDigit;

      /*Exercício 1: Tuplas
      Crie uma função que recebe um nome e uma idade como parâmetros e retorna uma tupla contendo o nome e a idade. Em 
      seguida, chame a função com diferentes valores e exiba os resultados.*/

      // Chamando a função com diferentes valores
      var pessoa1 = CriarTupla("Alice", 25);
      var pessoa2 = CriarTupla("Bob", 30);

      // Exibindo os resultados
      ExibirDadosDaPessoa(pessoa1);
      ExibirDadosDaPessoa(pessoa2);
      //========================================================================================================================

      /*Exercício 2: Expressões Lambda
      Defina uma expressão lambda que recebe dois números como parâmetros e retorna a soma dos quadrados desses números. Em seguida, chame a 
      expressão lambda com alguns valores diferentes e exiba os resultados.
      */

      // Chamando a expressão lambda com diferentes valores
      double resultado1 = CalcularSomaDosQuadrados(2, 3);
      double resultado2 = CalcularSomaDosQuadrados(4, 5);

      // Exibindo os resultados
      Console.WriteLine($"\n\tResultado 1: {resultado1}");
      Console.WriteLine($"\tResultado 2: {resultado2}");
      //========================================================================================================================

      /*Exercício 3: LINQ com Lista
      Crie uma lista de objetos simples, por exemplo, representando pessoas com propriedades como "Nome" e "Idade". Em seguida, use LINQ para 
      filtrar a lista e obter todas as pessoas com idade superior a 30.*/

      // Criando uma lista de pessoas
      List<Pessoa> listaDePessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Alice", Idade = 25 },
            new Pessoa { Nome = "Bob", Idade = 35 },
            new Pessoa { Nome = "Charlie", Idade = 28 },
            new Pessoa { Nome = "Diana", Idade = 40 }
        };

      // Usando LINQ para filtrar pessoas com idade superior a 30
      var pessoasComMaisDe30Anos = listaDePessoas.Where(pessoa => pessoa.Idade > 30).ToList();

      // Exibindo os resultados
      Console.WriteLine("\n\tPessoas com idade superior a 30:");
      foreach (var pessoa in pessoasComMaisDe30Anos)
      {
        Console.WriteLine($"\tNome: {pessoa.Nome}\n\tIdade: {pessoa.Idade}");
      }
      //========================================================================================================================

      /*Exercício 4: LINQ com Array
      Crie um array de números inteiros. Use LINQ para selecionar apenas os números pares e ordene-os de forma decrescente.
      */

      // Criando um array de números inteiros
      int[] numeros = { 5, 10, 3, 8, 7, 2, 15, 4, 6 };

      // Usando LINQ para selecionar apenas os números pares e ordená-los de forma decrescente
      var numerosParesOrdenados = numeros
          .Where(numero => numero % 2 == 0) // Seleciona apenas números pares
          .OrderByDescending(numero => numero) // Ordena de forma decrescente
          .ToArray(); // Converte para um array

      // Exibindo os resultados
      Console.WriteLine("\n\tNúmeros pares ordenados de forma decrescente:");
      Console.Write("\t");

      foreach (var numero in numerosParesOrdenados)
      {
        Console.Write(numero + " ");
      }

      /*Exercício 5: Combinação de Tuplas, Expressões Lambda e LINQ
      Crie uma lista de tuplas, onde cada tupla contém o nome de uma pessoa e a sua altura em centímetros. Utilize uma expressão 
      lambda e LINQ para calcular a altura média das pessoas na lista.*/

      // Criando uma lista de tuplas (nome, altura)
      List<(string Nome, double Altura)> listDePessoas = new List<(string, double)>
        {
            ("Alice", 165),
            ("Bob", 180),
            ("Charlie", 175),
            ("Diana", 160)
        };

      // Usando LINQ e expressão lambda para calcular a altura média
      double alturaMedia = listDePessoas.Select(pessoa => pessoa.Altura).Average();

      // Exibindo o resultado
      Console.WriteLine($"\n\n\tAltura média das pessoas: {alturaMedia} cm");


      /*Crie um programa que solicita ao usuário que insira um número. Utilize um bloco try-catch para lidar com a possível exceção 
      gerada se o usuário inserir algo que não seja um número. No bloco catch, exiba uma mensagem amigável informando ao usuário que um 
      número válido deve ser inserido.*/

      Console.Write("\n\tDigite um número: ");

      try
      {
        int numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\tVocê inseriu o número: {numero}");
      }
      catch (FormatException)
      {
        // Captura a exceção FormatException (ocorrida quando o usuário insere algo que não é um número)
        Console.WriteLine("\tPor favor, insira um número válido.");
      }

      /*Escreva uma função que recebe dois números como parâmetros e realiza uma divisão. No entanto, utilize um bloco try-catch para 
      lidar com a exceção de divisão por zero. Se uma divisão por zero for detectada, exiba uma mensagem indicando que a divisão por zero
      não é permitida.*/

      try
      {
        double resultado = RealizarDivisao(10, 0);
        Console.WriteLine($"\tResultado da divisão: {resultado}");
      }
      catch (DivideByZeroException)
      {
        Console.WriteLine("\tDivisão por zero não é permitida.");
      }

      /*Modifique o exercício 2 para incluir um bloco finally. No bloco finally, exiba uma mensagem indicando que o bloco finally 
      foi alcançado, independentemente de ocorrer uma exceção ou não.*/
      try
      {
        // Chamando a expressão lambda com diferentes valores
        double result1 = CalcularSomaDosQuadrados(2, 3);
        double result2 = CalcularSomaDosQuadrados(4, 5);

        // Exibindo os resultados
        Console.WriteLine($"\n\tResultado 1: {result1}");
        Console.WriteLine($"\tResultado 2: {result2}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"\tOcorreu uma exceção: {ex.Message}");
      }
      finally
      {
        Console.WriteLine("\tBloco finally foi alcançado.");
      }

      /*Crie uma função que simule uma operação que requer um número positivo como entrada. Se a função receber um número negativo, 
      lance uma exceção personalizada indicando que números negativos não são permitidos. Utilize um bloco try-catch para lidar com 
      essa exceção e exiba uma mensagem apropriada.*/
      try
      {
        // Chamando a função com diferentes valores
        RealizarOperacao(5);   // Isso deve ser bem-sucedido
        RealizarOperacao(-2);  // Isso deve gerar uma exceção
      }
      catch (NumeroNegativoException ex)
      {
        Console.WriteLine($"\tErro: {ex.Message}");
      }

      /*Escreva um programa que lê um arquivo de texto a partir de um caminho fornecido pelo usuário. Utilize um bloco try-catch para lidar 
      com exceções que possam ocorrer, como FileNotFoundException ou IOException. Exiba mensagens específicas para cada tipo de exceção 
      capturada.*/

      Console.Write("\n\tInforme o caminho do arquivo de texto: ");
      string caminhoArquivo = Console.ReadLine()!;

      try
      {
        // Tenta ler o conteúdo do arquivo
        string conteudo = LerArquivo(caminhoArquivo);
        Console.WriteLine($"\n\tConteúdo do arquivo:\n{conteudo}");
      }
      catch (FileNotFoundException)
      {
        Console.WriteLine($"\n\tErro: O arquivo não foi encontrado no caminho '{caminhoArquivo}'.");
      }
      catch (IOException ex)
      {
        Console.WriteLine($"\n\tErro de I/O: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"\n\tErro inesperado: {ex.Message}");
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
    }

    static (string Nome, int Idade) CriarTupla(string nome, int idade)
    {
      // Criando e retornando a tupla
      return (nome, idade);
    }

    static void ExibirDadosDaPessoa((string Nome, int Idade) pessoa)
    {
      // Exibindo os dados da pessoa
      Console.WriteLine($"\n\tNome: {pessoa.Nome}\n\tIdade: {pessoa.Idade}");
    }

    static Func<double, double, double> SomaDosQuadrados = (num1, num2) => (num1 * num1) + (num2 * num2);

    static double CalcularSomaDosQuadrados(double numero1, double numero2)
    {
      // Chama a expressão lambda
      return SomaDosQuadrados(numero1, numero2);
    }

    static void RealizarOperacao(int numero)
    {
      try
      {
        if (numero < 0)
        {
          // Lança uma exceção personalizada se o número for negativo
          throw new NumeroNegativoException("\n\tNúmeros negativos não são permitidos.");
        }

        // Continua com a operação se o número for positivo
        Console.WriteLine($"\tOperação realizada com sucesso para o número {numero}");
      }
      catch (NumeroNegativoException ex)
      {
        // Captura e trata a exceção personalizada
        throw ex; // Você pode optar por relançar a exceção ou tratar de outra forma
      }
    }

    static double RealizarDivisao(double numerador, double denominador)
    {
      if (denominador == 0)
      {
        throw new DivideByZeroException("Divisão por zero não é permitida.");
      }

      // Realiza a divisão
      return numerador / denominador;
    }

    static double CalcularSomaDosQuadrados2(double numero1, double numero2)
    {
      try
      {
        // Chama a expressão lambda
        return SomaDosQuadrados(numero1, numero2);
      }
      catch (Exception ex)
      {
        // Captura exceção e re-lança
        throw new Exception("Ocorreu uma exceção durante o cálculo.", ex);
      }
      finally
      {
        Console.WriteLine("Bloco finally interno foi alcançado.");
      }
    }

    static string LerArquivo(string caminho)
    {
      // Tenta ler o conteúdo do arquivo e retorna uma string
      return File.ReadAllText(caminho);
    }

    public static void LimparTela()
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
    public static void Pause()
    {
      Console.Write("\n\tPressione Enter para continuar...");
      Console.ReadLine();
    }

  }
}