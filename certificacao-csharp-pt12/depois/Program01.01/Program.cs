using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Program01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Filme filme = new Filme(diretor: "James Cameron", titulo: "Titanic", duracaoMinutos: 194);
            string json = JsonConvert.SerializeObject(filme);
            Console.WriteLine("JSON: ");
            Console.WriteLine(json);

            Filme filme2 = JsonConvert.DeserializeObject<Filme>(json);
            Console.WriteLine("Dados do objeto Filme: ");
            Console.WriteLine(filme2);
            Console.WriteLine();

            List<Filme> album = new List<Filme>();

            string[] titulos = new[] { "Titanic", "Britannic", "Magnific", "Mecanic" };

            foreach (string titulo in titulos)
            {
                Filme filme3 = new Filme(diretor: "James Cameron", titulo: titulo, duracaoMinutos: 194);
                album.Add(filme3);
            }

            string arrayJson = JsonConvert.SerializeObject(album);
            Console.WriteLine("string JSON: ");
            Console.WriteLine(arrayJson);
            Console.WriteLine();

            List<FilmeSimples> filmesSimples = JsonConvert.DeserializeObject<List<FilmeSimples>>(arrayJson);

            Console.WriteLine("Dados do objeto FilmeSimples: ");
            foreach (FilmeSimples filmeSimples in filmesSimples)
            {
                Console.WriteLine(filmeSimples);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    class Filme
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public int DuracaoMinutos { get; set; }

        public override string ToString()
        {
            return Diretor + " - " + Titulo + " - " + DuracaoMinutos.ToString() + " minutos";
        }

        public Filme(string diretor, string titulo, int duracaoMinutos)
        {
            Diretor = diretor;
            Titulo = titulo;
            DuracaoMinutos = duracaoMinutos;
        }
    }

    class FilmeSimples
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }

        public override string ToString()
        {
            return Diretor + " - " + Titulo;
        }

        public FilmeSimples(string diretor, string titulo)
        {
            Diretor = diretor;
            Titulo = titulo;
        }
    }
}
