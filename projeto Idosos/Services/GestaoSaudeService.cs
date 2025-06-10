namespace projeto_Idosos.Services
{
    public class GestaoSaudeService
    {
        public bool ValidaDataRegistro(DateTime data)
        {
            // Regra: não permitir registro de dados de saúde no futuro
            return data <= DateTime.Now;
        }

        public bool UsuarioPodeEditar(string usuarioAtual, string donoRegistro)
        {
            // Regra: apenas o cuidador responsável pode editar os dados
            return usuarioAtual == donoRegistro;
        }
    }
}