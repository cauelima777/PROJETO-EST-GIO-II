using Microsoft.AspNetCore.Mvc.RazorPages;
using projeto_Idosos.Models;

namespace projeto_Idosos.Pages.Exercicios
{
    public class ExerciciosModel : PageModel
    {
        public List<Exercicio> Exercicios { get; set; } = new()
        {
            new() { Id = 1, Nome = "Caminhada leve", Descricao = "Andar pelo quintal ou calçada por 15 minutos.", DuracaoMinutos = 15, Categoria = "Cardio" },
            new() { Id = 2, Nome = "Alongamento de braços", Descricao = "Esticar os braços por 30 segundos de cada lado.", DuracaoMinutos = 5, Categoria = "Alongamento" },
            new() { Id = 3, Nome = "Equilíbrio com cadeira", Descricao = "Ficar em pé atrás da cadeira e levantar um pé por vez.", DuracaoMinutos = 10, Categoria = "Equilíbrio" }
        };
    }
}
