namespace projeto_Idosos.Services
{
    public class CuidadorService
    {
        public bool PodeAcessarAreaRestrita(bool autenticado, string perfil)
        {
            // Regra: só cuidadores logados podem acessar recursos restritos
            return autenticado && perfil == "Cuidador";
        }

        public string SugerirConteudo(string tema)
        {
            // Exemplo de sugestão simples por tema
            return tema switch
            {
                "estresse" => "10 Técnicas para Reduzir o Estresse no Cuidado",
                "rotina" => "Como Criar uma Rotina Eficiente para o Idoso",
                _ => "Conteúdo geral para cuidadores"
            };
        }
    }
}
