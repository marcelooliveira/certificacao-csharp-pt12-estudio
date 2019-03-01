using System;
using System.Security.Cryptography;

namespace Program07._02
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeContainer = "MeuContainer";

            CspParameters csp = new CspParameters();
            csp.KeyContainerName = nomeContainer;
            // Cria um novo objeto RSA para encriptar os dados
            RSACryptoServiceProvider rsaStore = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Chaves armazenadas: {0}", rsaStore.ToXmlString(includePrivateParameters: false));

            rsaStore.PersistKeyInCsp = false;
            rsaStore.Clear();

            RSACryptoServiceProvider rsaLoad = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Chaves carregadas: {0}", rsaLoad.ToXmlString(includePrivateParameters: false));
            Console.ReadKey();
        }
    }
}
