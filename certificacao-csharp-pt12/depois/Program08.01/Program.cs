using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace Program08._01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Converte a string de entrada em bytes, e vice-versa
            ASCIIEncoding converter = new ASCIIEncoding();

            // Obtém um provider de criptografia a partir do store de certificados
            X509Store store = new X509Store("meuStoreDeCertificado", StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            X509Certificate2 certificate = store.Certificates[0];

            RSACryptoServiceProvider encryptProvider = certificate.PrivateKey as RSACryptoServiceProvider;

            string mensagemASerAssinada = "Mensagem a ser assinada";
            Console.WriteLine("Mensagem: {0}", mensagemASerAssinada);

            byte[] mensagemASerAssinadaBytes = converter.GetBytes(mensagemASerAssinada);
            ExibirBytes("Mensagem a ser assinada em, bytes: ", mensagemASerAssinadaBytes);

            //Você precisa calcular um hash para essa mensagem
            //- isso entrará na assinatura e será usado para verificar a mensagem
            
            //Crie uma implementação do agoritmo hashing que vamos usar
            HashAlgorithm hasher = new SHA1Managed();
            // Utiliza o hasher para "hashear" a mensagem
            byte[] hash = hasher.ComputeHash(mensagemASerAssinadaBytes);
            ExibirBytes("Hash para a mensagem: ", hash);

            // Assina o hash para criar a assinatura
            byte[] assinatura = encryptProvider.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
            ExibirBytes("Assinatura: ", mensagemASerAssinadaBytes);

            //Podemos enviar a assinatura junto com a mensagem para autenticá-la
            //Criar um decodificador que use a chave pública
            RSACryptoServiceProvider decryptProvider = certificate.PublicKey.Key as RSACryptoServiceProvider;

            // Agora use a assinatura para executar uma validação bem-sucedida da mensagem
            bool validSignature = decryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), assinatura);
            Console.WriteLine("Assinatura correta validada: {0}", validSignature);

            // Altera um byte da assinatura
            assinatura[0] = 23;
            // Agora tente usar a assinatura incorreta para validar a mensagem
            bool invalidSignature = decryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), assinatura);
            Console.WriteLine("Assinatura incorreta validada: {0}", invalidSignature);

            Console.ReadKey();
        }

        static void ExibirBytes(string titulo, byte[] bytes)
        {
            Console.Write(titulo);
            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }
            Console.WriteLine();
        }
    }
}
