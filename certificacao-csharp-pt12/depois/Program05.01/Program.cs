using System;

namespace Program05._01
{
    class Program
    {
        static void Main(string[] args)
        {
            const string numero = "123";
            int resultado;

            if (int.TryParse(numero, out resultado))
                Console.WriteLine("Este é um número VÁLIDO");
            else
                Console.WriteLine("Este é um número INVÁLIDO");

            Console.WriteLine(resultado);

            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            string stringValor = "99";

            int intValor = Convert.ToInt32(stringValor);
            Console.WriteLine("intValor: {0}", intValor);


            // intValue = int.Parse(null);
            bool b = int.TryParse(null, out intValor);
            intValor = Convert.ToInt32("boom");

            stringValor = "True";
            bool boolValor = Convert.ToBoolean(null);
            Console.WriteLine("boolValor: {0}", boolValor);

            Console.ReadKey();

        }
    }
}
