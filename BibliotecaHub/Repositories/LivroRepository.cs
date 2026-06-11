using BibliotecaHub.Model;
using System.Text.Json;


namespace BibliotecaHub.Repositories
{
    public class LivroRepository
    {

        public List<Livro> livros = new();

        public LivroRepository()
        {
            LerArquivoJson();

            if(livros.Count > 0)
            {
                Livro livroPadrao = new Livro(1, "O Senhor dos Anéis", "J.R.R. Tolkien", 1954, false);
                livros.Add(livroPadrao);
            }
        }

        public void GerarArquivoJson()
        {
            string jsonString = JsonSerializer.Serialize(livros);
            File.WriteAllText("livros.json", jsonString);
        }
        public void LerArquivoJson()
        {
            if (File.Exists("livros.json"))
            {
                string jsonString = File.ReadAllText("livros.json");

                var livrosSalvos = JsonSerializer.Deserialize<List<Livro>>(jsonString);
                if (livrosSalvos != null)
                {
                    livros = livrosSalvos;
                }
            }
        }
    }
}
