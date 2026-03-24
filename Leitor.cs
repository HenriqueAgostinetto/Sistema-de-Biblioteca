using System.Collections.Generic;

namespace Biblioteca
{
    public class Leitor
    {                                                                       // Henrique Agostinetto e Nicole Pedroso
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public string Cpf { get; set; }
        public List<Livro> Livros { get; set; }

        public Leitor(string nome, byte idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public void DoarLivro(Livro livro, Leitor destino)
        {
            Livros.Remove(livro);
            destino.Livros.Add(livro);
        }

        public void Exibir()
        {
            System.Console.WriteLine($"\n{Nome} - {Cpf}");
            foreach (var livro in Livros)
            {
                System.Console.WriteLine($"Livro: {livro.Titulo}");
            }
        }
    }
}