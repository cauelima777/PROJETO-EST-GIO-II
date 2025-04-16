using Microsoft.AspNetCore.Mvc.RazorPages;

public class lembreteModel : PageModel
{
    public string LembreteTitulo { get; set; } = "Lembretes de Medicação";
    public string LembreteDescricao { get; set; } = "Notificações para administração correta dos remédios.";

    public List<Lembrete> Lembretes { get; set; } = new List<Lembrete>
    {
        new Lembrete { NomeRemedio = "Paracetamol", Hora = "08:00", Descricao = "Tomar após o café da manhã." },
        new Lembrete { NomeRemedio = "Amoxicilina", Hora = "12:00", Descricao = "Tomar antes do almoço." },
        new Lembrete { NomeRemedio = "Dipirona", Hora = "18:00", Descricao = "Tomar em caso de dor ou febre." }
    };

    public void OnGet()
    {
    }

    public class Lembrete
    {
        public string NomeRemedio { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
    }
}
