using projeto_Idosos.Models;

namespace projeto_Idosos.Services
{
    public class TempoService
    {
        public bool TarefaSobrepoe(Tarefa nova, List<Tarefa> existentes)
        {
            // Regra: não permitir sobreposição de tarefas
            return existentes.Any(t => t.Data == nova.Data);
        }

        public bool PausaEntreTarefasSuficiente(DateTime anterior, DateTime proxima)
        {
            // Regra: deve haver pelo menos 15 minutos entre tarefas
            return (proxima - anterior).TotalMinutes >= 15;
        }
    }
}
