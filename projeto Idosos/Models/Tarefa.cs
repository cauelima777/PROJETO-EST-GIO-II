using System;
using System.ComponentModel.DataAnnotations;

namespace projeto_Idosos.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
