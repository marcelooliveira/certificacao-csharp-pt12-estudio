using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Program08._01
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagemOriginal = "Dados secretos que precisam ser protegidos";
            string mensagemDecodificada = "";

            //TAREFA: ALICE PRECISA ENVIAR UMA MENSAGEM SECRETA PARA BOB.
            //IMPLEMENTE O CÓDIGO NECESSÁRIO UTILIZANDO A CLASSE PESSOA ABAIXO.

            Pessoa alice = new Pessoa("Alice");
            Pessoa bob = new Pessoa("Bob");

            string chavePublicaDoBob = bob.ChavePublica;
            var bytesCodificados = alice.CodificarMensagem(mensagemOriginal, chavePublicaDoBob);

            mensagemDecodificada = bob.DecodificarMensagem(bytesCodificados);

            Console.WriteLine("string decifrada: {0}", mensagemDecodificada);

            Console.ReadLine();
        }

        public class Pessoa
        {
            private readonly string nome;
            private readonly string chavePrivada;

            public string ChavePublica { get; }

            public Pessoa(string nome)
            {
                this.nome = nome;

                // Cria um novo RSA para criptografar os dados

                //TAREFA: ARMAZENAR CHAVES NO NÍVEL DE MÁQUINA, NÃO USUÁRIO DO WINDOWS
                CspParameters cspParameters = new CspParameters();
                cspParameters.KeyContainerName = "MeuContainer";
                cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
                RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider(cspParameters);

                // pega as chaves do criptografador
                ChavePublica = encriptadorRSA.ToXmlString(includePrivateParameters: false);
                chavePrivada = encriptadorRSA.ToXmlString(includePrivateParameters: true);

                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Dados do usuário: {0}", nome);
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Chave privada de {0}: {1}", nome, chavePrivada);
                Console.WriteLine("Chave pública de {0}: {1}", nome, ChavePublica);
                Console.WriteLine(new string('=', 100));
                Console.WriteLine();
            }


            public byte[] CodificarMensagem(string mensagemOriginal, string chavePublicaDestinatario)
            {
                byte[] bytesCifrados;

                //TAREFA : CRIPTOGRAFAR A MENSAGEM ABAIXO
                //USANDO O PADRÃO RSA (RIVEST-SHAMIR-ADLEMAN) ASSIMÉTRICO

                Console.WriteLine("Mensagem original: {0}", mensagemOriginal);
                Console.WriteLine();

                // RSA funciona em matrizes de bytes, não em cadeias de texto
                // Isso irá converter nossa string de entrada em bytes e de volta
                ASCIIEncoding conversor = new ASCIIEncoding();

                // Converte a mensagem original em uma array de bytes
                byte[] mensagemBytes = conversor.GetBytes(mensagemOriginal);

                ExibirBytes("Bytes da mensagem original: ", mensagemBytes);

                // Cria um novo RSA para criptografar os dados

                //TAREFA: ARMAZENAR A CHAVE PRIVADA COM SEGURANÇA
                CspParameters cspParameters = new CspParameters();
                cspParameters.KeyContainerName = "MeuContainer";
                RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider(cspParameters);

                // Agora diga ao encriptador para usar a chave pública para criptografar os dados
                encriptadorRSA.FromXmlString(chavePublicaDestinatario);

                // Use o criptografador para criptografar os dados. O parâmetro fOAEP
                // especifica como a saída é "preenchida" com bytes extras
                // Para compatibilidade máxima com sistemas de recebimento, defina como
                // false
                bytesCifrados = encriptadorRSA.Encrypt(mensagemBytes, fOAEP: false);

                ExibirBytes("Bytes encriptados: ", bytesCifrados);
                return bytesCifrados;
            }

            public string DecodificarMensagem(byte[] bytesCifrados)
            {
                //TAREFA : DESCRIPTOGRAFAR A MENSAGEM ABAIXO
                //USANDO O PADRÃO RSA (RIVEST-SHAMIR-ADLEMAN) ASSIMÉTRICO
                byte[] bytesDecifrados;

                // Cria um novo RSA para descriptografar os dados
                RSACryptoServiceProvider decifradorRSA = new RSACryptoServiceProvider();

                // Configura o decodificador a partir do XML na chave privada
                decifradorRSA.FromXmlString(chavePrivada);

                // Configurar o decryptor do XML na chave privada decifradorRSA.FromXmlString(chavePrivada);
                bytesDecifrados = decifradorRSA.Decrypt(bytesCifrados, fOAEP: false);

                ExibirBytes("Bytes decifrados: ", bytesDecifrados);

                ASCIIEncoding conversor2 = new ASCIIEncoding();
                return conversor2.GetString(bytesDecifrados);
            }

            void ExibirBytes(string titulo, byte[] bytes)
            {
                Console.Write(titulo);
                foreach (byte b in bytes)
                {
                    Console.Write("{0:X} ", b);
                }
                Console.WriteLine();
            }
        }


        static void Main2(string[] args)
        {
            //Mensagem a ser assinada
            string mensagemASerAssinada = "Mensagem a ser assinada";
            Console.WriteLine("Mensagem: {0}", mensagemASerAssinada);

            // Converte a string de entrada em bytes, e vice-versa
            ASCIIEncoding converter = new ASCIIEncoding();

            // Obtém um provider de criptografia a partir do store de certificados
            X509Store store = new X509Store("MeuStore", StoreLocation.CurrentUser);

            //Abre o store de certificado
            store.Open(OpenFlags.ReadOnly);

            //Obtém o primeiro certificado
            X509Certificate2 certificate = store.Certificates[0];

            //Obtém um encriptador a partir da chave privada chave privada
            RSA encriptadorRSA = certificate.GetRSAPrivateKey();

            byte[] mensagemASerAssinadaBytes = converter.GetBytes(mensagemASerAssinada);
            ExibirBytes("Mensagem a ser assinada, em bytes: ", mensagemASerAssinadaBytes);

            //Você precisa calcular um hash para essa mensagem
            //- isso entrará na assinatura e será usado para verificar a mensagem

            //Crie uma implementação do agoritmo hashing que vamos usar
            HashAlgorithm hasher = new SHA1Managed();

            // Utiliza o hasher para "hashear" a mensagem
            byte[] hash = hasher.ComputeHash(mensagemASerAssinadaBytes);
            ExibirBytes("Hash para a mensagem: ", hash);

            // Assina o hash para criar a assinatura
            byte[] assinatura = encriptadorRSA.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            ExibirBytes("Assinatura: ", mensagemASerAssinadaBytes);

            //Podemos enviar a assinatura junto com a mensagem para autenticá-la

            //Obtém um decodificador a partir da chave privada
            RSA decriptadorRSA = certificate.GetRSAPublicKey();

            // Agora use a assinatura para executar uma validação bem-sucedida da mensagem
            bool assinaturaValida = decriptadorRSA.VerifyHash(hash, assinatura, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            Console.WriteLine("Assinatura correta validada: {0}", assinaturaValida);

            // Altera um byte da assinatura
            assinatura[0] = 23;

            // Agora tente usar a assinatura incorreta para validar a mensagem
            bool assinaturaInvalida = decriptadorRSA.VerifyHash(hash, assinatura, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            Console.WriteLine("Assinatura incorreta validada: {0}", assinaturaInvalida);

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
