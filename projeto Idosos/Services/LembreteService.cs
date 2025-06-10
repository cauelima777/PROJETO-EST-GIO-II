using projeto_Idosos.Models;

namespace projeto_Idosos.Services
{
    public class LembreteService
    {
        public bool PodeCriarLembrete(Lembrete lembrete)
        {
            // Regra: nome e hora são obrigatórios
            return !string.IsNullOrWhiteSpace(lembrete.NomeRemedio)
                && !string.IsNullOrWhiteSpace(lembrete.Hora);
        }

        public bool EhHorarioValido(string horaTexto)
        {
            // Regra: hora deve ser futura
            if (TimeSpan.TryParse(horaTexto, out var hora))
            {
                var agora = DateTime.Now.TimeOfDay;
                return hora > agora;
            }
            return false;
        }

        public bool ConflitoDeHorario(string novaHora, List<Lembrete> lembretes)
        {
            // Regra: não permitir lembretes no mesmo horário
            return lembretes.Any(l => l.Hora == novaHora);
        }
    }
}
