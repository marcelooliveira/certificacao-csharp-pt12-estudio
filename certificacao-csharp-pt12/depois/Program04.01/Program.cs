using System;
using System.Text.RegularExpressions;

namespace Program04
{
    class Program
    {   
        static void Main(string[] args)
        {
            string entrada = "CSharp Java Python Ruby Swift Scala ObjectiveC";

            string padraoComparacao = " ";
            string padraoSubstituicao = ",";

            string substituido = Regex.Replace(entrada, padraoComparacao, padraoSubstituicao);

            Console.WriteLine(substituido);
            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            string entrada = "CSharp    Java Python   Ruby  Swift   Scala       ObjectiveC";

            string padraoComparacao = " +";
            string padraoSubstituicao = ",";

            string substituido = Regex.Replace(entrada, padraoComparacao, padraoSubstituicao);

            Console.WriteLine(substituido);
            Console.ReadKey();
        }

        static void Main3(string[] args)
        {
            string entrada = "2:O Exterminador do Futuro:1984:107";

            string padraoRegex = ".+:.+:.+:.+";

            if (Regex.IsMatch(entrada, padraoRegex))
            {
                Console.WriteLine("Registro de filme VÁLIDO");
            }
            else
            {
                Console.WriteLine("Registro de filme INVÁLIDO");
            }
            Console.ReadKey();
        }

        static void Main4(string[] args)
        {
            string entrada = "2:O Exterminador do Futuro:1984:107";

            string padraoRegex = @"[0-9]+:.+:[0-9]+:[0-9]+$";

            if (Regex.IsMatch(entrada, padraoRegex))
            {
                Console.WriteLine("Registro de filme VÁLIDO");
            }
            else
            {
                Console.WriteLine("Registro de filme INVÁLIDO");
            }
            Console.ReadKey();
        }

        static void Main5(string[] args)
        {
            string entrada = "2:O Exterminador do Futuro:1984:107";
            
            string padraoRegex = @"^[0-9]+:([a-z]|[A-Z]| )+:[0-9]+:[0-9]+$";

            if (Regex.IsMatch(entrada, padraoRegex))
            {
                Console.WriteLine("Registro de filme VÁLIDO");
            }
            else
            {
                Console.WriteLine("Registro de filme INVÁLIDO");
            }
            Console.ReadKey();
        }
    }
}