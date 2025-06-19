using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pam.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        
        [JsonIgnore]
        public ICollection<Sugestao> Sugestoes { get; set; } = new List<Sugestao>();
    }
}
