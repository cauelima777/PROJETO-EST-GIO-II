using System;

namespace projeto_Idosos.Models
{
    public class DireitoLido
    {
        public string UsuarioId { get; set; } = string.Empty;

        public int DireitoId { get; set; }

        public DateTime DataLeitura { get; set; } = DateTime.Now;
    }
}
