namespace Biblioteca // agrupa as classes do projeto
{
    public class Livro // classe publica acessivel por qualquer outra classe
    {
        private string _isbn;
        private string _titulo;
        private string _subtitulo;
        private string _escritor;
        private string _editora;
        private string _genero;
        private string _tipoCapa;
        private int _numeroPaginas;
        private int _anoPublicacao;

        // Propriedade ISBN (imutável após criação)
        public string Isbn
        {
            get => _isbn;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("ISBN inválido");

                _isbn = value.Trim();
            }
        }

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Título inválido");

                _titulo = value.Trim();
            }
        }

        public string Subtitulo
        {
            get => _subtitulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Subtítulo inválido");

                _subtitulo = value.Trim();
            }
        }

        public string Escritor
        {
            get => _escritor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Escritor inválido");

                _escritor = value.Trim();
            }
        }

        public string Editora
        {
            get => _editora;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Editora inválida");

                _editora = value.Trim();
            }
        }

        public string Genero
        {
            get => _genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Gênero inválido");

                _genero = value.Trim();
            }
        }

        public string TipoCapa
        {
            get => _tipoCapa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Tipo de capa inválido");

                _tipoCapa = value.Trim();
            }
        }

        public int NumeroPaginas
        {
            get => _numeroPaginas;
            set
            {
                if (value < 0)
                    throw new Exception("Número de páginas não pode ser negativo");

                _numeroPaginas = value;
            }
        }

        public int AnoPublicacao
        {
            get => _anoPublicacao;
            set
            {
                int anoAtual = DateTime.Now.Year;

                if (value < 1970 || value > anoAtual)
                    throw new Exception("Ano inválido");

                _anoPublicacao = value;
            }
        }

        // construtor chamado ao criar um novo Livro
        public Livro(string isbn, string titulo, string escritor, string editora, int ano, int paginas) // Henrique Agostinetto e Nicole Pedroso
        {
            Isbn = isbn;
            Titulo = titulo;
            Escritor = escritor;
            Editora = editora;
            AnoPublicacao = ano;
            NumeroPaginas = paginas;
        }
    }
}