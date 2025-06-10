using System.ComponentModel.DataAnnotations;

namespace projeto_Idosos.Models
{
    public class Direito
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;
    }
}
