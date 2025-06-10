using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Saude
{
    public class SaudeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public SaudeModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public List<projeto_Idosos.Models.Saude> Registros { get; set; } = new();
        public static Dictionary<string, List<projeto_Idosos.Models.Saude>> DadosSaudePorUsuario = new();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return;

            if (DadosSaudePorUsuario.TryGetValue(user.Id, out var dados))
                Registros = dados;
        }
    }
}
