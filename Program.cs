using System;

namespace Biblioteca // agrupa as classes do projeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BibliotecaService service = new BibliotecaService();

            try
            {
                service.Menu(); // inicia o sistema
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}