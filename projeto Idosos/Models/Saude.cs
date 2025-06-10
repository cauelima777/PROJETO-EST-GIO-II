using System;
using System.ComponentModel.DataAnnotations;

namespace projeto_Idosos.Models
{
    public class Saude
    {
        public int Id { get; set; }

        [Required]
        public string UsuarioId { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty; // Ex: Consulta, Exame

        [Required]
        public string Descricao { get; set; } = string.Empty;

        public DateTime Data { get; set; } = DateTime.Now;

        public string? Observacoes { get; set; }
    }
}
