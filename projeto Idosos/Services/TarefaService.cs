using projeto_Idosos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projeto_Idosos.Services
{
    public class TarefaService
    {
        public bool PodeAgendar(DateTime novaData, List<Tarefa> tarefasExistentes)
        {
            // Verifica se já existe uma tarefa no mesmo horário
            return !tarefasExistentes.Any(t => t.Data == novaData);
        }
    }
}
