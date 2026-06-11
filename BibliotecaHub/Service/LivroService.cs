using BibliotecaHub.Model;
using BibliotecaHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaHub.Service
{
    public class LivroService
    {

        LivroRepository repository = new();

        public void EmprestarLivro()
        {
            Console.WriteLine("Informe o livro deseja emprestar: ");
            var livroProcurado = repository.livros.FirstOrDefault(l => l.Titulo == Console.ReadLine());
            if (livroProcurado == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }

            if (livroProcurado.Disponivel == true)
            {
                Console.WriteLine($"o livro {livroProcurado} foi adicionado a sua biblioteca por 10 dias!");
                livroProcurado.Disponivel = false;
            }
            else
            {
                Console.WriteLine("Este livro não está disponível para empréstimo.");
            }
        }
        public void ListarLivrosEmprestados()
        {
            Console.Clear();
            foreach (var livro in repository.livros.Where(l => l.Disponivel == false))
            {
                Console.WriteLine(livro.ToString());
            }

            Thread.Sleep(2000);
            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void ListarLivrosDisponiveis()
        {
            Console.Clear();
            foreach (var livro in repository.livros.Where(l => l.Disponivel == true))
            {
                Console.WriteLine(livro.ToString());
            }

            Thread.Sleep(2000);
            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void BuscarLivro()
        {
            Console.Clear();
            Console.WriteLine("Digite o livro que deseja encontrar: ");
            string livroProcurado = Console.ReadLine().ToLower();

            // Busca por titulo criando uma lista de livros encontrados, limitando a 10 resultados e ignorando letras maiusculas
            var livroEncontrado = repository.livros.Where(l => l.Titulo.ToLower().Contains(livroProcurado)).Take(10);

            // Verifica se encontrou algum livro e exibe os resultados
            if (livroEncontrado.Any())
            {
                foreach (var livro in livroEncontrado)
                {
                    Console.WriteLine(livro.ToString());
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }

        }
        public void DevolverLivro()
        {
            Console.Clear();
            Console.WriteLine("Informe o ID do livro que você deseja devolver: ");
            int id = int.TryParse(Console.ReadLine(), out int resultado) ? resultado : 0;

            var livroProcurado = repository.livros.FirstOrDefault(l => l.Id == id);

            if (livroProcurado == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }

            if (livroProcurado.Disponivel != false)
                Console.WriteLine("Este livro não está emprestado.");

            livroProcurado.Disponivel = true;

            Console.WriteLine("\nLivro devolvido com sucesso!");

            Thread.Sleep(2000);

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void ListarLivros()
        {
            Console.Clear();
            foreach (var livro in repository.livros)
            {
                Console.WriteLine(livro.ToString());
                Console.WriteLine("");
            }

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("====Cadastrar Livro====");
            Console.WriteLine("\nInforme o titulo do livro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Informe o autor do livro: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Informe o ano de publicação do livro: ");
            int ano = int.TryParse(Console.ReadLine(), out int resultado) ? resultado : 0;

            Livro livro = new Livro(repository.livros.Count + 1, titulo, autor, ano, true);

            repository.livros.Add(livro);

            Console.WriteLine("\nLivro cadastrado com sucesso!");

            Thread.Sleep(2000);

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
