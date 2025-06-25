using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projeto_Idosos.Data;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Saude
{
    public class SaudeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SaudeModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<projeto_Idosos.Models.Saude> Registros { get; set; } = new();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return;

            Registros = await _context.Saude
                .Where(s => s.UsuarioId == user.Id)
                .OrderByDescending(s => s.Data)
                .ToListAsync();
        }
    }
}
