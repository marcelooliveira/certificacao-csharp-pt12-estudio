using System;

namespace Program03
{
    class Program
    {
        static void Main(string[] args)
        {
            Filme filme = new Filme(diretor: "James Cameron", titulo: "Titanic", duracaoMinutos: 194);

            ImprimeFilme(new Filme(filme));

            Console.WriteLine(filme.Diretor);
            Console.ReadKey();
        }

        static void ImprimeFilme(Filme filme)
        {
            filme.Diretor = "Fulano de tal";
        }
    }

    public class Filme
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

        public Filme(Filme outro)
        {
            Diretor = outro.Diretor;
            Titulo = outro.Titulo;
            DuracaoMinutos = outro.DuracaoMinutos;
        }
    }
}