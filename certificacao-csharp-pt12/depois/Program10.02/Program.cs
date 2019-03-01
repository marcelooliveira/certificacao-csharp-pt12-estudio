using System;
using System.Security.Cryptography;
using System.Text;

namespace Program10._02
{
    class Program
    {
        static byte[] CalcularHash(string origem)
        {
            // Isso irá converter a nossa string de entrada em bytes e vice-versa
            ASCIIEncoding conversor = new ASCIIEncoding();

            byte[] bytesOrigem = conversor.GetBytes(origem);

            HashAlgorithm hasher = SHA256.Create();

            byte[] hash = hasher.ComputeHash(bytesOrigem);

            return hash;
        }

        static void ExibirHash(string origem)
        {
            Console.Write("Hash para {0} é: ", origem);

            byte[] hash = CalcularHash(origem);

            foreach (byte b in hash)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ExibirHash("Olá, mundo!");
            ExibirHash("Mundo, olá");
            ExibirHash("Olá, mundo, olá!");

            Console.ReadKey();
        }
    }
}
