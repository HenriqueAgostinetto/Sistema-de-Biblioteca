using System;                       // necessario para usar Console
using System.Collections.Generic;   // necessario para usar List
using System.Linq;                  // necessario para usar Any e FirstOrDefault
                                    // Henrique Agostinetto e Nicole Pedroso

namespace Biblioteca // agrupa as classes do projeto
{
    public class BibliotecaService // classe que concentra toda a logica do sistema
    {
        private List<Leitor> leitores = new List<Leitor>(); // lista privada que guarda todos os leitores

        public void Menu() // exibe o menu e controla as opcoes
        {
            int op; // variavel que guarda a opcao digitada

            do // executa pelo menos uma vez antes de checar a condicao
            {
                Console.WriteLine("\n1 - Cadastrar Leitor");
                Console.WriteLine("2 - Listar Leitores");
                Console.WriteLine("3 - Adicionar Livro");
                Console.WriteLine("4 - Remover Livro");
                Console.WriteLine("5 - Doar Livro");
                Console.WriteLine("6 - Buscar Leitor");
                Console.WriteLine("7 - Remover Leitor");
                Console.WriteLine("0 - Sair");

                op = int.Parse(Console.ReadLine()); // le o texto digitado e converte pra inteiro

                switch (op) // direciona para o metodo correto conforme a opcao
                {
                    case 1: Cadastrar(); break;
                    case 2: Listar(); break;
                    case 3: AddLivro(); break;
                    case 4: RemoverLivro(); break;
                    case 5: Doar(); break;
                    case 6: Buscar(); break;
                    case 7: RemoverLeitor(); break;
                }

            } while (op != 0); // repete ate o usuario digitar 0
        }

        private void Cadastrar() // cadastra um novo leitor na lista
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine(); // le o nome

                Console.Write("Idade: ");
                byte idade = byte.Parse(Console.ReadLine()); // le e converte pra byte

                Console.Write("CPF: ");
                string cpf = Console.ReadLine(); // le o cpf

                // REMOVIDO: validação de CPF aqui (deve estar na classe Leitor)

                leitores.Add(new Leitor(nome, idade, cpf)); // cria o leitor e adiciona na lista
                Console.WriteLine("Leitor cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Leitor BuscarCpf() // busca e retorna um leitor pelo cpf, retorna null se nao achar
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine(); // le o cpf
            return leitores.FirstOrDefault(x => x.Cpf == cpf); // retorna o primeiro leitor com esse cpf ou null
        }

        private void Buscar() // exibe os dados de um leitor pelo cpf
        {
            var l = BuscarCpf(); // busca o leitor
            if (l != null)       // so exibe se encontrou
                Console.WriteLine($"{l.Nome} - {l.Cpf}");
        }

        private void Listar() // exibe todos os leitores cadastrados
        {
            foreach (var l in leitores) // percorre a lista
            {
                // EVITADO chamar método interno (Exibir) caso tenha Console lá
                Console.WriteLine($"{l.Nome} - {l.Cpf} - {l.Idade}");
            }
        }

        private void AddLivro() // adiciona um livro a um leitor
        {
            var l = BuscarCpf();    // busca o leitor
            if (l == null) return;  // sai se nao encontrou

            try
            {
                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                Console.Write("Titulo: ");
                string titulo = Console.ReadLine(); // le o titulo

                Console.Write("Escritor: ");
                string escritor = Console.ReadLine();

                Console.Write("Editora: ");
                string editora = Console.ReadLine();

                Console.Write("Ano: ");
                int ano = int.Parse(Console.ReadLine());

                Console.Write("Paginas: ");
                int paginas = int.Parse(Console.ReadLine());

                l.AdicionarLivro(new Livro(isbn, titulo, escritor, editora, ano, paginas));
                Console.WriteLine("Livro adicionado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RemoverLivro() // remove um livro de um leitor
        {
            var l = BuscarCpf();    // busca o leitor
            if (l == null) return;  // sai se nao encontrou

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine(); // le o titulo

            var livro = l.Livros.FirstOrDefault(x => x.Titulo == titulo); // busca o livro na lista do leitor
            if (livro != null)
                l.Livros.Remove(livro); // remove o livro da lista
        }

        private void Doar() // transfere um livro de um leitor para outro
        {
            Console.WriteLine("Doador:");
            var doador = BuscarCpf();   // busca o leitor que vai doar
            if (doador == null) return; // sai se nao encontrou

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine(); // le o titulo do livro

            var livro = doador.Livros.FirstOrDefault(x => x.Titulo == titulo); // busca o livro na lista do doador
            if (livro == null) return; // sai se o livro nao existe

            Console.WriteLine("Destino:");
            var destino = BuscarCpf();   // busca o leitor que vai receber
            if (destino == null) return; // sai se nao encontrou

            doador.DoarLivro(livro, destino); // faz a transferencia do livro
        }

        private void RemoverLeitor() // remove um leitor da lista
        {
            var l = BuscarCpf();    // busca o leitor
            if (l != null)
                leitores.Remove(l); // remove o leitor da lista
        }
    }
}