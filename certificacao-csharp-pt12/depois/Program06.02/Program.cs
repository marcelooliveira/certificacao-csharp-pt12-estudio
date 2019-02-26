using System;
using System.IO;
using System.Security.Cryptography;

namespace Program06._02
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagemSecreta = "Dados secretos que precisam ser protegidos";

            // array de bytes para manter a mensagem criptografada
            byte[] textoCifrado;

            // matriz de bytes para manter a chave usada para criptografia
            byte[] chave;

            // matriz de bytes para manter o vetor de inicialização que foi usado para criptografia
            byte[] vetorInicializacao;

            // Cria uma instância de Aes
            // Isso cria uma chave aleatória e um vetor de inicialização
            using (Aes aes = Aes.Create())
            {
                // copia a chave e o vetor de inicialização
                chave = aes.Key;
                vetorInicializacao = aes.IV;

                // cria um criptografador para criptografar alguns dados
                ICryptoTransform encriptador = aes.CreateEncryptor();

                // Cria um novo fluxo de memória para receber os
                // dados criptografados.
                using (MemoryStream fluxoMemoria = new MemoryStream())
                {
                    // crie um CryptoStream, diga ao stream para gravar
                    // e o encriptador para usar. Também defina o modo
                    using (CryptoStream fluxoEncriptado = new CryptoStream(fluxoMemoria,
                        encriptador, CryptoStreamMode.Write))
                    {
                        // cria um gravador de fluxo a partir do cryptostream
                        using (StreamWriter escritor = new StreamWriter(fluxoEncriptado))
                        {
                            // Escreva a mensagem secreta para o fluxo.
                            escritor.Write(mensagemSecreta);
                        }
                        // obtém a mensagem criptografada do fluxo
                        textoCifrado = fluxoMemoria.ToArray();
                    }
                }
            }

            // Exibe nossos dados
            Console.WriteLine("Texto a ser encriptado: {0}", mensagemSecreta);
            ExibirBytes("Chave: ", chave);
            ExibirBytes("Vetor de inicialização: ", vetorInicializacao);
            ExibirBytes("Encriptada: ", textoCifrado);

            // Agora faça a descriptografia
            string textoDecifrado;

            using (Aes aes = Aes.Create())
            {
                // Configure as instâncias aes com a chave e
                // vetor de inicialização a ser usado para a descriptografia
                aes.Key = chave;
                aes.IV = vetorInicializacao;

                // Cria um decodificador de aes
                ICryptoTransform decodificador = aes.CreateDecryptor();

                using (MemoryStream fluxoMemoria = new MemoryStream(textoCifrado))
                {
                    using (CryptoStream fluxoCripto =
                        new CryptoStream(fluxoMemoria, decodificador, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(fluxoCripto))
                        {
                            // Leia os bytes descriptografados do fluxo de decriptografia
                            // e coloque-os em uma string.
                            textoDecifrado = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            Console.WriteLine("Texto decifrado: {0}", textoDecifrado);

            Console.ReadLine();
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