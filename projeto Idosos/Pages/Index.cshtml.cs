using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace projeto_Idosos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                // Redireciona para o dashboard correto de usuários logados
                return RedirectToPage("/Principal/Dashboard", new { area = "Identity" });
            }

            return Page(); // Mostra a landing page para visitantes
        }
    }
}
