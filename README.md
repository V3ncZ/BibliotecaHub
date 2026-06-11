# 📚 BibliotecaHub

Um sistema de gerenciamento de biblioteca via console desenvolvido em **C# (.NET)**. O projeto evoluiu de um script simples para uma aplicação estruturada, focada em boas práticas, implementando persistência de dados local e consumo de serviços web de forma assíncrona.

---

## ✨ Funcionalidades

* **Gestão de Acervo:** Cadastrar, listar e realizar buscas avançadas de livros por título.
* **Controle de Empréstimos:** Lógica de negócio para emprestar e devolver obras, alterando dinamicamente o status de disponibilidade.
* **Persistência de Dados (Local):** Salvamento e carregamento automático do estado da biblioteca através de manipulação de arquivos locais (`livros.json`).
* **Integração com API Externa:** Consulta ao acervo mundial da **Open Library API** para buscar dados reais de livros publicados, utilizando requisições HTTP.

## 🏗️ Arquitetura e Padrões Aplicados

O projeto foi estruturado para respeitar a separação de responsabilidades, facilitando a manutenção e futuras expansões:

* **Models / DTOs:** Entidades de domínio (como `Livro`) e Data Transfer Objects (como `ResultadoApi` e `LivroApi`) devidamente mapeados para a desserialização segura com `[JsonPropertyName]`.
* **Repository Pattern:** Isolamento da lógica de acesso e gravação de dados (`LivroRepository`), retirando a responsabilidade de manipulação física do menu principal.
* **Programação Assíncrona:** Implementação fluida de `async/await` com a classe `HttpClient`, garantindo que o sistema (Console) não trave enquanto aguarda a resposta do servidor externo.
* **Consultas com LINQ:** Uso de métodos como `Where`, `FirstOrDefault` e `Take` para filtragem de dados em memória de maneira limpa e performática.

## 🚀 Tecnologias e Bibliotecas Utilizadas

* **C# / .NET** (Console Application)
* **System.Text.Json** (Serialização e Desserialização de dados)
* **System.Net.Http** (Comunicação com a Web / Carteiro HTTP)
* **System.Linq** (Manipulação de coleções)
* **System.IO** (Leitura e escrita de arquivos físicos)
* **API Externa:** [Open Library Search API](https://openlibrary.org/dev/docs/api/search)

## 🛠️ Como Executar o Projeto

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório:
   ```bash
   git clone [https://github.com/V3ncZ/BibliotecaHub.git](https://github.com/V3ncZ/BibliotecaHub.git)
