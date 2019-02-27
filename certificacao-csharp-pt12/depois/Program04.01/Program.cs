using System;
using System.Text.RegularExpressions;

namespace Program04
{
    class Program
    {   
        static void Main1(string[] args)
        {
            //Tarefa: separar nomes das linguagens por vírgulas
            string entrada = "CSharp Java Python Ruby Swift Scala ObjectiveC";

            string substituido = entrada.Replace(" ", ",");

            //string padraoComparacao = " ";
            //string padraoSubstituicao = ",";
            //string substituido = Regex.Replace(entrada, padraoComparacao, padraoSubstituicao);

            Console.WriteLine(substituido);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //Tarefa: separar nomes das linguagens por vírgulas
            string entrada = "CSharp    Java Python   Ruby  Swift   Scala       ObjectiveC";

            string padraoComparacao = " +";
            string padraoSubstituicao = ",";

            string substituido = Regex.Replace(entrada, padraoComparacao, padraoSubstituicao);

            Console.WriteLine(substituido);
            Console.ReadKey();
        }

        static void Main3(string[] args)
        {
            //Formato do Registro
            //- campos separados por dois pontos: ":"
            //- Campo 1: Id do filme
            //- Campo 2: Título do filme
            //- Campo 3: Ano do filme
            //- Campo 4: Duração do filme em minutos

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
            //Formato do Registro
            //- campos separados por dois pontos: ":"
            //- Campo 1: Id do filme
            //- Campo 2: Título do filme
            //- Campo 3: Ano do filme
            //- Campo 4: Duração do filme em minutos
            //- Id, ano e duração são campos numéricos

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
            //Formato do Registro
            //- campos separados por dois pontos: ":"
            //- Campo 1: Id do filme
            //- Campo 2: Título do filme
            //- Campo 3: Ano do filme
            //- Campo 4: Duração do filme em minutos
            //- Id, ano e duração são campos numéricos
            //- Título do filme são letras ou espaços

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