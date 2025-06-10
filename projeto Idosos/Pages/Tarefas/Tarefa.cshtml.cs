using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Tarefas
{
    public class TarefaModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        // Armazenamento em memória por usuário
        public static Dictionary<string, List<Tarefa>> TarefasPorUsuario = new();

        public TarefaModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public Tarefa NovaTarefa { get; set; }

        public List<Tarefa> ListaTarefas { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (TarefasPorUsuario.ContainsKey(user.Id))
                ListaTarefas = TarefasPorUsuario[user.Id];
            else
                ListaTarefas = new List<Tarefa>();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (!ModelState.IsValid)
            {
                return await OnGetAsync(); // Recarrega tarefas se erro no form
            }

            if (!TarefasPorUsuario.ContainsKey(user.Id))
                TarefasPorUsuario[user.Id] = new List<Tarefa>();

            TarefasPorUsuario[user.Id].Add(NovaTarefa);

            return RedirectToPage(); // Redireciona para limpar o form
        }
    }
}
