﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Program06._03
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagemSecreta = "Dados secretos que precisam ser protegidos";

            Console.WriteLine("Mensagem secreta: {0}", mensagemSecreta);
            Console.WriteLine();

            // RSA funciona em matrizes de bytes, não em cadeias de texto
            // Isso irá converter nossa string de entrada em bytes e de volta
            ASCIIEncoding conversor = new ASCIIEncoding();

            // Convert the plain text into a byte array
            byte[] mensagemBytes = conversor.GetBytes(mensagemSecreta);

            ExibirBytes("Bytes da mensagem: ", mensagemBytes);

            byte[] bytesCifrados;
            byte[] bytesDecifrados;

            // Cria um novo RSA para criptografar os dados
            RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider();

            // pega as chaves do criptografador
            string chavePublica = encriptadorRSA.ToXmlString(includePrivateParameters: false);
            Console.WriteLine("Chave pública: {0}", chavePublica);
            string chavePrivada = encriptadorRSA.ToXmlString(includePrivateParameters: true);
            Console.WriteLine("Chave privada: {0}", chavePrivada);

            // Agora diga ao encyryptor para usar a chave pública para criptografar os dados
            encriptadorRSA.FromXmlString(chavePrivada);

            // Use o criptografador para criptografar os dados. O parâmetro fOAEP
            // especifica como a saída é "preenchida" com bytes extras
            // Para compatibilidade máxima com sistemas de recebimento, defina como
            // false
            bytesCifrados = encriptadorRSA.Encrypt(mensagemBytes, fOAEP: false);

            ExibirBytes("Bytes encriptados: ", bytesCifrados);

            // Agora faça a decodificação - use a chave privada para isso
            // Enviamos a alguém nossa chave pública e eles
            // usam isso para criptografar dados que eles estão enviando para nós

            // Cria um novo RSA para descriptografar os dados
            RSACryptoServiceProvider decifradorRSA = new RSACryptoServiceProvider();

            // Configure the decryptor from the XML in the private key
            decifradorRSA.FromXmlString(chavePrivada);

            // Configurar o decryptor do XML na chave privada decifradorRSA.FromXmlString(chavePrivada);
            bytesDecifrados = decifradorRSA.Decrypt(bytesCifrados, fOAEP: false);
            
            ExibirBytes("Bytes decifrados: ", bytesDecifrados);
            Console.WriteLine("string decifrada: {0}", conversor.GetString(bytesDecifrados));

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





