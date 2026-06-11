using BibliotecaHub.Model;
using BibliotecaHub.Repositories;
using BibliotecaHub.Service;
using System.Text.Json;

LivroRepository repository = new();
LivroService service = new();
LivroApiExternaService apiService = new();

Menu();

int opcao = int.Parse(Console.ReadLine());

while (opcao != 0)
{
    switch (opcao)
    {
        case 1:
            service.CadastrarLivro();
            break;
        case 2:
            service.ListarLivros();
            break;
        case 3:
            service.DevolverLivro();
            break;
        case 4:
            service.BuscarLivro();
            break;
        case 5:
            service.ListarLivrosDisponiveis();
            break;
        case 6:
            service.ListarLivrosEmprestados();
            break;
        case 7:
            service.EmprestarLivro();
            break;
        case 8:
            await apiService.ConsumirApiExterna();
            break;
        case 0:
            repository.GerarArquivoJson();
            Console.WriteLine("Saindo...");
            Thread.Sleep(2000);
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Menu();
    opcao = int.TryParse(Console.ReadLine(), out int resultado) ? resultado : 0;
}

void Menu()
{

    Console.Clear();
    Console.WriteLine("====Biblioteca HubFree====");
    Console.WriteLine("1. Cadastrar Livro\n2. Listar Livros\n3. Devolver Livros\n4. Buscar Livro por Nome\n5. Listar Livros Disponiveis\n6. Listar Livros Emprestados\n7. Emprestar Livro\n8. Consultar API Externa\n0. Sair");
}