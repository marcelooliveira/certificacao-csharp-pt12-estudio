using System;
using System.Security.Cryptography;

namespace Program07._03
{
    class Program
    {
        static void Main(string[] args)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "Chave de nível de máquina";

            // Especifica que a chave deve ser armazenada no nível da máquina
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

            // Cria um provider do serviço de criptografia
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);

            Console.WriteLine(rsa.ToXmlString(includePrivateParameters: false));

            // Garante que as chaves estão sendo persistidas
            rsa.PersistKeyInCsp = true;

            // Limpa o provider para garantir que ele salve a chave
            rsa.Clear();

            Console.ReadKey();
        }
    }
}
