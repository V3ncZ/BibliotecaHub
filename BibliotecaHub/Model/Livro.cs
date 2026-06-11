using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaHub.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; }

        public Livro(int id, string titulo, string autor, int ano, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = disponivel;
        }

        override public string ToString()
        {
            return $"\nID: {Id} | Título: {Titulo} | Autor: {Autor} | Ano: {Ano} | Disponível: {(Disponivel ? "Sim" : "Não")}";
        }

    }

}
