// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;

namespace exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            LimparTela();
            Console.WriteLine("\n\t========== EXERCICIO 1 ==========");
            for (int i = 0; i < 30; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("\tDivisiveis por 3, entre 0 e 30: " + i);
                }
            }
            Console.WriteLine("\t==================================");
            Pause();

            LimparTela();
            Console.WriteLine("\n\t========== EXERCICIO 1 ==========");
            for (int i = 0; i < 30; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine("\tDivisiveis por 4, entre 0 e 30: " + i);
                }
            }
            Console.WriteLine("\t==================================");
            Pause();

            LimparTela();
            Console.WriteLine("\n\t========== EXERCICIO 2 ==========");

            int limite = 100;
            int a = 0, b = 1, c = 0;

            Console.WriteLine("\n\tSequência de Fibonacci até {0}:", limite);

            while (c  < (limite + 50))
            {
                Console.Write("\t" + c + " ");

                c = a + b;
                a = b;
                b = c;
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

        static void Pause()
        {
            Console.Write("\n\tPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
