using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Services;

namespace projeto_Idosos.Pages.Educacao
{
    public class DireitosModel : PageModel
    {
        private readonly EducacaoService _educacaoService;
        private readonly UserManager<IdentityUser> _userManager;

        // Simula uma lista de direitos lidos por usuário (em memória)
        public static Dictionary<string, List<string>> DireitosPorUsuario = new();

        public DireitosModel(UserManager<IdentityUser> userManager)
        {
            _educacaoService = new EducacaoService();
            _userManager = userManager;
        }

        public string PerfilUsuario { get; set; }
        public List<DireitoItem> Direitos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            PerfilUsuario = "Idoso"; // ou buscar do banco, se tiver papel

            MontarDireitos(user.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostMarcarComoLidoAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (!DireitosPorUsuario.ContainsKey(user.Id))
                DireitosPorUsuario[user.Id] = new List<string>();

            if (!DireitosPorUsuario[user.Id].Contains(id))
                DireitosPorUsuario[user.Id].Add(id);

            return RedirectToPage();
        }

        private void MontarDireitos(string userId)
        {
            var sugestoes = _educacaoService.SugerirDireitos("Idoso"); // pode ser dinâmico

            var idsLidos = DireitosPorUsuario.ContainsKey(userId)
                ? DireitosPorUsuario[userId]
                : new List<string>();

            Direitos = sugestoes.Select(descricao =>
            {
                var id = GerarId(descricao);
                return new DireitoItem
                {
                    Id = id,
                    Descricao = descricao,
                    JaLido = idsLidos.Contains(id)
                };
            }).ToList();
        }

        private string GerarId(string descricao)
        {
            return descricao.ToLower()
                .Replace(" ", "")
                .Replace("ç", "c")
                .Replace("ã", "a")
                .Replace("á", "a");
        }

        public class DireitoItem
        {
            public string Id { get; set; }
            public string Descricao { get; set; }
            public bool JaLido { get; set; }
        }
    }
}
