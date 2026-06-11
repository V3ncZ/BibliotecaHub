using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaHub.Model
{
    public class LivroApi
    {
        [JsonPropertyName("title")]
        public string Titulo { get; set; }
        [JsonPropertyName("author_name")]
        public List<string> Autores { get; set; }
        [JsonPropertyName("first_publish_year")]
        public int AnoPublicacao { get; set; }
        [JsonPropertyName("series_name")]
        public string SeriePertencente { get; set; }

        public LivroApi()
        {
            
        }

        public override string ToString()
        {
            return $"Titulo: {Titulo}\nAnoPublicação: {AnoPublicacao}\nSeriePertencente: {SeriePertencente}";
        }
    }
}
