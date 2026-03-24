using System;
using System.Collections.Generic;
using System.Linq;
                                        // Henrique Agostinetto e Nicole Pedroso
namespace Biblioteca
{
    public class BibliotecaService
    {
        private List<Leitor> leitores = new List<Leitor>();

        public void Menu()
        {
            int op;

            do
            {
                Console.WriteLine("\n1 - Cadastrar Leitor");
                Console.WriteLine("2 - Listar Leitores");
                Console.WriteLine("3 - Adicionar Livro");
                Console.WriteLine("4 - Remover Livro");
                Console.WriteLine("5 - Doar Livro");
                Console.WriteLine("6 - Buscar Leitor");
                Console.WriteLine("7 - Remover Leitor");
                Console.WriteLine("0 - Sair");

                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: Cadastrar(); break;
                    case 2: Listar(); break;
                    case 3: AddLivro(); break;
                    case 4: RemoverLivro(); break;
                    case 5: Doar(); break;
                    case 6: Buscar(); break;
                    case 7: RemoverLeitor(); break;
                }

            } while (op != 0);
        }

        private void Cadastrar()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            byte idade = byte.Parse(Console.ReadLine());

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            if (leitores.Any(x => x.Cpf == cpf))
            {
                Console.WriteLine("CPF já cadastrado");
                return;
            }

            leitores.Add(new Leitor(nome, idade, cpf));
        }

        private Leitor BuscarCpf()
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            return leitores.FirstOrDefault(x => x.Cpf == cpf);
        }

        private void Buscar()
        {
            var l = BuscarCpf();
            if (l != null)
                Console.WriteLine($"{l.Nome} - {l.Cpf}");
        }

        private void Listar()
        {
            foreach (var l in leitores)
            {
                l.Exibir();
            }
        }

        private void AddLivro()
        {
            var l = BuscarCpf();
            if (l == null) return;

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            l.AdicionarLivro(new Livro(titulo));
        }

        private void RemoverLivro()
        {
            var l = BuscarCpf();
            if (l == null) return;

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            var livro = l.Livros.FirstOrDefault(x => x.Titulo == titulo);
            if (livro != null)
                l.Livros.Remove(livro);
        }

        private void Doar()
        {
            Console.WriteLine("Doador:");
            var doador = BuscarCpf();
            if (doador == null) return;

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            var livro = doador.Livros.FirstOrDefault(x => x.Titulo == titulo);
            if (livro == null) return;

            Console.WriteLine("Destino:");
            var destino = BuscarCpf();
            if (destino == null) return;

            doador.DoarLivro(livro, destino);
        }

        private void RemoverLeitor()
        {
            var l = BuscarCpf();
            if (l != null)
                leitores.Remove(l);
        }
    }
}