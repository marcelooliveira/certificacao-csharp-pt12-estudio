using System;

namespace Program10._01
{
    class Program
    {

        static void ExibirChecksum(object origem)
        {
            Console.WriteLine("Hash para {0} é: {1:X}", origem, origem.GetHashCode());
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
