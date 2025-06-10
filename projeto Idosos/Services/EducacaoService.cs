namespace projeto_Idosos.Services
{
    public class EducacaoService
    {
        // Regra: garantir que o conteúdo seja acessível ao perfil (idoso ou cuidador)
        public bool PodeAcessarConteudo(string perfil, string publicoAlvo)
        {
            // Se o conteúdo for "Ambos", todos podem ver. Senão, só o público-alvo.
            return publicoAlvo == "Ambos" || publicoAlvo == perfil;
        }

        // Regra: registrar o conteúdo como lido
        public bool ConteudoJaFoiLido(List<string> idsConteudosLidos, string idConteudoAtual)
        {
            return idsConteudosLidos.Contains(idConteudoAtual);
        }

        // Regra: sugerir temas de direitos com base no perfil
        public List<string> SugerirDireitos(string perfil)
        {
            if (perfil == "Idoso")
            {
                return new List<string>
                {
                    "Transporte público gratuito",
                    "Atendimento prioritário em repartições públicas e bancos",
                    "Acompanhamento médico gratuito pelo SUS",
                    "Isenção de IPTU em alguns municípios",
                    "Direito à integridade física e moral"
                };
            }
            else if (perfil == "Cuidador")
            {
                return new List<string>
                {
                    "Direito de acompanhar o idoso em atendimentos",
                    "Como acionar o Ministério Público em caso de negligência",
                    "Benefícios do INSS para cuidadores informais",
                    "Como agir em caso de violação de direitos do idoso"
                };
            }

            return new List<string>();
        }
    }
}
