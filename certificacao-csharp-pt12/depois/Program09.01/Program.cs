using System;

namespace Program09._01
{
    class Program
    {
        static int CalcularChecksum(string origem)
        {
            int total = 0;
            foreach (char ch in origem)
                total = total + (int)ch;
            return total;
        }

        static void ExibirChecksum(string origem)
        {
            Console.WriteLine("Checksum para {0} é {1}",
                origem, CalcularChecksum(origem));
        }

        static void Main(string[] args)
        {
            ExibirChecksum("Olá, mundo!");
            ExibirChecksum("Mundo, olá");
            ExibirChecksum("Olá, mundo, olá!");

            Console.ReadKey();
        }
    }
}
