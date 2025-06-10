using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Lembretes
{
    public class LembreteModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public LembreteModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public Lembrete NovoLembrete { get; set; }

        // Lembretes por usuário logado (em memória)
        public static Dictionary<string, List<Lembrete>> LembretesPorUsuario = new();

        public List<Lembrete> ListaLembretes { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            ListaLembretes = LembretesPorUsuario.ContainsKey(user.Id)
                ? LembretesPorUsuario[user.Id]
                : new List<Lembrete>();

            return Page();
        }

        public string Titulo { get; set; } = "Lembretes de Medicação";
        public string Descricao { get; set; } = "Notificações para administração correta dos remédios.";

        public List<Lembrete> LembretesUsuario => ListaLembretes;

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (!ModelState.IsValid)
                return await OnGetAsync();

            if (!LembretesPorUsuario.ContainsKey(user.Id))
                LembretesPorUsuario[user.Id] = new List<Lembrete>();

            LembretesPorUsuario[user.Id].Add(NovoLembrete);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostExcluirAsync(string hora)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (LembretesPorUsuario.ContainsKey(user.Id))
            {
                var lembrete = LembretesPorUsuario[user.Id]
                    .FirstOrDefault(l => l.Hora == hora); // usa o horário como identificador depois que tiver acesso ao BD trocar por ID

                if (lembrete != null)
                    LembretesPorUsuario[user.Id].Remove(lembrete);
            }

            return RedirectToPage();
        }

    }
}
