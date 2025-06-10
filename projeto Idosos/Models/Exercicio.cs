using System;
using System.ComponentModel.DataAnnotations;

namespace projeto_Idosos.Models
{
    public class Exercicio
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public int DuracaoMinutos { get; set; } // Ex: 15, 30...

        public string? Categoria { get; set; } // Ex: Alongamento, Caminhada, Equilíbrio
    }
}
