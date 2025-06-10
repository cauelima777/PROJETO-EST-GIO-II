using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;
using projeto_Idosos.Pages.Educacao;
using projeto_Idosos.Services;
using projeto_Idosos.Pages.Lembretes;

namespace projeto_Idosos.Pages.Principal
{
    public class DashboardModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string NomeUsuario { get; set; } = "";
        public Lembrete? ProximoLembrete { get; set; }
        public List<Tarefa> UltimasTarefas { get; set; } = new();
        public double ProgressoLeitura { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            NomeUsuario = user?.Email ?? "usuário";

            if (LembreteModel.LembretesPorUsuario.ContainsKey(user.Id))
            {
                var todos = LembreteModel.LembretesPorUsuario[user.Id];
                ProximoLembrete = todos
                    .Where(l => TimeSpan.TryParse(l.Hora, out _))
                    .OrderBy(l => TimeSpan.Parse(l.Hora))
                    .FirstOrDefault();
            }
            else
            {
                ProximoLembrete = null;
            }

            UltimasTarefas = new List<Tarefa>
            {
                new() { Titulo = "Consulta médica", Descricao = "Retorno com o cardiologista", Data = DateTime.Now.AddDays(-1) },
                new() { Titulo = "Caminhada", Descricao = "15 minutos no quintal", Data = DateTime.Now.AddDays(-2) }
            };

            var educacaoService = new EducacaoService();
            var totalDireitos = educacaoService.SugerirDireitos("Idoso").Count;
            var lidos = DireitosModel.DireitosPorUsuario.ContainsKey(user.Id)
                ? DireitosModel.DireitosPorUsuario[user.Id].Count
                : 0;

            ProgressoLeitura = totalDireitos == 0 ? 0 : (lidos / (double)totalDireitos) * 100;
        }
    }
}
