namespace projeto_Idosos.Services
{
    public class ExerciciosService
    {
        public bool PodeAgendarNovaAtividade(DateTime nova, List<DateTime> jaAgendadas)
        {
            // Regra: não permitir atividades em horários muito próximos (menos de 30min)
            return !jaAgendadas.Any(a => Math.Abs((a - nova).TotalMinutes) < 30);
        }

        public bool EstaInativoHaDias(DateTime ultimaAtividade)
        {
            // Regra: alerta se inativo há mais de 3 dias
            return (DateTime.Now - ultimaAtividade).TotalDays > 3;
        }
    }
}
