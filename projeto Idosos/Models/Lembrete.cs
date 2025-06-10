namespace projeto_Idosos.Models
{
    public class Lembrete
    {
        public int Id { get; set; }

        public string NomeRemedio { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

}
