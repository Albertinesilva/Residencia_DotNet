// See https://aka.ms/new-console-template for more information

using System;

namespace P001
{
  class Program
  {
    static void Main(string[] args)
    {

      LimparTela();
      Console.WriteLine("\n\t======================================================================================");
      Console.WriteLine("\tTIPOS DE DADOS DO C#\n");

      sbyte valor = 42;
      Console.WriteLine("\tRepresenta números inteiros de 8 bits. (sbyte) = " + valor);

      byte valor2 = 200;
      Console.WriteLine("\tRepresenta números inteiros de 8 bits sem sinal. (byte) = " + valor2);

      short valor3 = -15000;
      Console.WriteLine("\tRepresenta números inteiros de 16 bits. (short) = " + valor3);

      ushort valor4 = 30000;
      Console.WriteLine("\tRepresenta números inteiros de 16 bits sem sinal. (ushort) = " + valor4);

      int valor5 = 1000000;
      Console.WriteLine("\tRepresenta números inteiros de 32 bits. (int) = " + valor5);

      uint valor6 = 4000000000;
      Console.WriteLine("\tRepresenta números inteiros de 32 bits sem sinal. (uint) = " + valor6);

      long valor7 = 123456789012345;
      Console.WriteLine("\tRepresenta números inteiros de 64 bits. (long) = " + valor7);

      ulong valor8 = 18000000000000000000;
      Console.WriteLine("\tRepresenta números inteiros de 64 bits sem sinal. (ulong) = " + valor8);
      Console.WriteLine("\t======================================================================================");

      // Pausa a execução do programa até que uma tecla seja pressionada
      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();

      // Limpa a tela
      LimparTela();

      Console.WriteLine("\t================================================================================================");
      Console.WriteLine("\tCONVERSÃO DE TIPOS DE DADOS DO C#");

      double valorDouble = 10.75;
      int valorInteiro = (int)valorDouble;
      Console.WriteLine("\n\tdouble valorDouble = 10.75;\n\tint valorInteiro = (int)valorDouble;\n\tEm C#, você pode converter uma variável do tipo double para int utilizando um tipo de cast. (int) = " + valorInteiro);
      Console.WriteLine("\n\tNeste exemplo, valorDouble é uma variável do tipo double com a parte fracionária representando .75. \n\tAo converter para int usando (int)valorDouble, a parte decimal será truncada, resultando em 10 como valor inteiro");
      Console.WriteLine("\n\tA função Math.Round é usada para arredondar um número para o inteiro mais próximo ou para um número especificado de casas decimais. \n\tO método Math.Round é estático, portanto, você não precisa criar uma instância de Math para usá-lo. \n\tO método Math.Round tem várias sobrecargas. \n\tAqui, usamos o método Math.Round (double, int) para arredondar o valorDouble para o inteiro mais próximo. \n\tO valor de retorno é do tipo double, portanto, precisamos converter para int usando (int). \n\t(int)Math.Round(valorDouble) = " + (int)Math.Round(valorDouble));
      Console.WriteLine("\t================================================================================================");

      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();

      LimparTela();
      Console.WriteLine("\t=====================================================");
      Console.WriteLine("\tOPERADORES ARITMÉTICOS DO C#");

      int x = 10;
      int y = 3;

      Console.WriteLine("\n\tint x = 10;\n\tint y = 3;\n\n\tSOMA:\n\tx + y = " + (x + y) + " ou pode ser escrito como x += y = " + (x += y));
      Console.WriteLine("\n\tSUBTRAÇÃO:\n\tx - y = " + (x - y) + " ou pode ser escrito como x -= y = " + (x -= y));
      Console.WriteLine("\n\tMULTIPLICAÇÃO:\n\tx * y = " + (x * y) + " ou pode ser escrito como x *= y = " + (x *= y));
      Console.WriteLine("\n\tDIVISÃO:\n\tx / y = " + (x / y) + " ou pode ser escrito como x /= y = " + (x /= y));
      Console.WriteLine("\n\tRESTO DA DIVISÃO:\n\tx % y = " + (x % y) + " ou pode ser escrito como x %= y = " + (x %= y));
      Console.WriteLine("\t=====================================================");

      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();
      LimparTela();

      Console.WriteLine("\t==========================================");
      Console.WriteLine("\tOPERADORES DE COMPARAÇÃO DO C#");

      Console.WriteLine("\n\tx = " + x + "\n\ty = " + y + "\n\n\tOperador de igualdade (==):");
      Console.WriteLine("\tx == y = " + (x == y));

      Console.WriteLine("\n\tOperador de desigualdade (!=):");
      Console.WriteLine("\tx != y = " + (x != y));

      Console.WriteLine("\n\tOperador maior que (>):");
      Console.WriteLine("\tx > y = " + (x > y));

      Console.WriteLine("\n\tOperador menor que (<):");
      Console.WriteLine("\tx < y = " + (x < y));

      Console.WriteLine("\n\tOperador maior ou igual que (>=):");
      Console.WriteLine("\tx >= y = " + (x >= y));

      Console.WriteLine("\n\tOperador menor ou igual que (<=):");
      Console.WriteLine("\tx <= y = " + (x <= y));
      Console.WriteLine("\t========================================");

      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();
      LimparTela();

      Console.WriteLine("\t===========================================================================");
      Console.WriteLine("\tOPERADORES DE IGUALDADE DO C#");

      string str1 = "Hello";
      string str2 = "World";

      Console.WriteLine("\n\tstring str1 = \"Hello\";\n\tstring str2 = \"World\";\n\n\tOperador de igualdade (==):");
      Console.WriteLine("\tstr1 == str2 = " + (str1 == str2) + " ou pode ser escrito como str1.Equals(str2) = " + str1.Equals(str2));

      Console.WriteLine("\n\tOperador de desigualdade (!=):");
      Console.WriteLine("\tstr1 != str2 = " + (str1 != str2) + " ou pode ser escrito como !str1.Equals(str2) = " + !str1.Equals(str2));
      Console.WriteLine("\t===========================================================================");

      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();
      LimparTela();

      Console.WriteLine("\t==================================");
      Console.WriteLine("\tOPERADORES LÓGICOS DO C#");

      bool condicao1 = true;
      bool condicao2 = false;

      Console.WriteLine("\n\tbool a = true;\n\tbool b = false;\n\n\tOperador AND (&&):");
      Console.WriteLine("\ta && b = " + (condicao1 && condicao2));

      Console.WriteLine("\n\tOperador OR (||):");
      Console.WriteLine("\ta || b = " + (condicao1 || condicao2));

      Console.WriteLine("\n\tOperador NOT (!):");
      Console.WriteLine("\t!a = " + (!condicao1));

      Console.WriteLine("\n\tOperador XOR (^):");
      Console.WriteLine("\ta ^ b = " + (condicao1 ^ condicao2));

      Console.WriteLine("\n\tOperador de negação lógica (!):");
      Console.WriteLine("\t!(a && b) = " + !(condicao1 && condicao2));

      Console.WriteLine("\n\tOperador de negação lógica (!):");
      Console.WriteLine("\t!(a || b) = " + !(condicao1 || condicao2));

      Console.WriteLine("\n\tOperador de negação lógica (!):");
      Console.WriteLine("\t!(a ^ b) = " + !(condicao1 ^ condicao2));
      Console.WriteLine("\t==================================");

      Console.Write("\n\tPressione qualquer tecla para continuar...");
      Console.ReadKey();
      LimparTela();

      Console.WriteLine("\t===========================================");
      Console.WriteLine("\tDESAFIO DE MISTURA DE OPERADORES DO C#");

      int num1 = 7;
      int num2 = 3;
      int num3 = 10;

      Console.WriteLine("\n\tint num1 = 7;\n\tint num2 = 3;\n\tint num3 = 10;\n\n\tnum1 > num2 && num3 == (num1 + num2) = " + (num1 > num2 && num3 == (num1 + num2)));
      Console.WriteLine("\t===========================================\n\n");

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
  }
}