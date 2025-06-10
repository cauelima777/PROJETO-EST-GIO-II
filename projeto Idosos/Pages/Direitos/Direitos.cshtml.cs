using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Direitos
{
    public class DireitosModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DireitosModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public List<Direito> Direitos { get; set; } = new();
        public HashSet<int> DireitosLidosIds { get; set; } = new();

        // Simula��es em mem�ria
        public static List<Direito> TodosOsDireitos = new()
        {
            new() { Id = 1, Titulo = "Atendimento preferencial", Descricao = "Os idosos t�m direito ao atendimento priorit�rio em reparti��es p�blicas e privadas." },
            new() { Id = 2, Titulo = "Transporte gratuito", Descricao = "Idosos a partir de 65 anos t�m direito � gratuidade nos transportes p�blicos urbanos." },
            new() { Id = 3, Titulo = "Sa�de", Descricao = "Prioridade no atendimento m�dico e fornecimento de medicamentos." },
        };

        public static Dictionary<string, List<DireitoLido>> DireitosLidosPorUsuario = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            Direitos = TodosOsDireitos;

            if (DireitosLidosPorUsuario.TryGetValue(user.Id, out var lidos))
                DireitosLidosIds = lidos.Select(d => d.DireitoId).ToHashSet();

            return Page();
        }

        public async Task<IActionResult> OnPostMarcarComoLidoAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (!DireitosLidosPorUsuario.ContainsKey(user.Id))
                DireitosLidosPorUsuario[user.Id] = new List<DireitoLido>();

            if (!DireitosLidosPorUsuario[user.Id].Any(d => d.DireitoId == id))
            {
                DireitosLidosPorUsuario[user.Id].Add(new DireitoLido
                {
                    UsuarioId = user.Id,
                    DireitoId = id,
                    DataLeitura = DateTime.Now
                });
            }

            return RedirectToPage();
        }
    }
}
