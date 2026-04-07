using System;
using System.Collections.Generic; // necessario para usar List
using System.Linq;

namespace Biblioteca // agrupa as classes do projeto
{
    public class Leitor // classe publica acessivel por qualquer outra classe
    {                                                                       // Henrique Agostinetto e Nicole Pedroso
        private string _nome;
        private byte _idade;
        private string _cpf;

        public static List<string> CpfsCadastrados = new List<string>();

        public string Nome // guarda o nome do leitor
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Nome inválido");

                _nome = value.Trim();
            }
        }

        public byte Idade // guarda a idade, byte vai de 0 a 255
        {
            get => _idade;
            set
            {
                if (value < 0)
                    throw new Exception("Idade inválida");

                _idade = value;
            }
        }

        public string Cpf // guarda o cpf do leitor
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("CPF inválido");

                string cpfTratado = value.Trim();

                if (CpfsCadastrados.Any(c => c == cpfTratado))
                    throw new Exception("CPF já cadastrado");

                if (_cpf != null)
                    CpfsCadastrados.Remove(_cpf);

                _cpf = cpfTratado;
                CpfsCadastrados.Add(cpfTratado);
            }
        }

        public List<Livro> Livros { get; private set; } // lista de livros que o leitor possui

        public Leitor(string nome, byte idade, string cpf) // construtor chamado ao criar um novo Leitor
        {
            Nome = nome;                // salva o nome
            Idade = idade;              // salva a idade
            Cpf = cpf;                  // salva o cpf
            Livros = new List<Livro>(); // inicia a lista vazia
        }

        public void AdicionarLivro(Livro livro) // recebe um livro e adiciona na lista
        {
            Livros.Add(livro); // insere o livro no final da lista
        }

        public void DoarLivro(Livro livro, Leitor destino) // remove o livro deste leitor e passa pro destino
        {
            Livros.Remove(livro);      // remove o livro da lista atual
            destino.Livros.Add(livro); // adiciona o livro na lista do destino
        }

        // REMOVIDO Console daqui para respeitar o PDF
        public string ObterResumo() // retorna dados do leitor sem interação com console
        {
            return $"{Nome} - {Cpf}";
        }
    }
}