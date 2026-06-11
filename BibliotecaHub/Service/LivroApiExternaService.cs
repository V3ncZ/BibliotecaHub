using BibliotecaHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibliotecaHub.Service
{
    public class LivroApiExternaService
    {
        public async Task ConsumirApiExterna()
        {
            Console.Clear();
            using HttpClient client = new HttpClient();
            Console.WriteLine("Digite o nome do Livro que deseja procurar: ");
            string livro = Console.ReadLine().ToLower().Replace(" ", "+");

            try
            {
                // URL criada com a variavel do livro que busco
                var URL = $"https://openlibrary.org/search.json?q={livro}";
                // Realizando a busca no servidor da url
                string conteudo = await client.GetStringAsync(URL);

                var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<ResultadoApi>(conteudo, opcoes);

                // Trazendo apenas os 5 primeiros resultados
                var primeirosResultados = resultado.docs.Take(5);

                Console.Clear();

                foreach (var livroEncontrado in primeirosResultados)
                {
                    Console.WriteLine(livroEncontrado.ToString());

                    if (livroEncontrado.Autores != null && livroEncontrado.Autores.Any())
                    {
                        Console.WriteLine($"Autor(es): {string.Join(", ", livroEncontrado.Autores)}");
                    }
                    Console.WriteLine(new string('-', 20));
                }

                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                Console.ReadKey();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro na requisição: {e.Message}");
            }

        }
    }
}
