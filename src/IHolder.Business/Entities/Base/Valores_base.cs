namespace IHolder.Business.Entities.Base
{
    public abstract class Valores_base : Entidade_base
    {
        protected Valores_base(decimal percentual_objetivo, decimal valor_atual)
        {
            Percentual_objetivo = percentual_objetivo;
            Valor_atual = valor_atual;
        }

        public decimal Percentual_objetivo { get; private set; }
        public decimal Percentual_atual { get; private set; }
        public decimal Percentual_diferenca { get; private set; }
        public decimal Valor_atual { get; private set; }
        public decimal Valor_diferenca { get; private set; }

        public void AtualizarPercentualObjetivo(decimal percentual_objetivo)
        {
            Percentual_objetivo = percentual_objetivo;
        }
        public void AtualizarValorAtual(decimal valor_atual)
        {
            Valor_atual = valor_atual;
        }


        public void AtualizarPercentualAtual (decimal valor_investido_total)
        {
            Percentual_atual = (Valor_atual / valor_investido_total) * 100;
        }

        public void AtualizarPercentualDiferenca()
        {
            Percentual_diferenca = Percentual_objetivo - Percentual_atual;
        }

        public void AtualizarValorDiferenca()
        {
            Valor_diferenca = (Valor_atual / Percentual_atual) * Percentual_diferenca;
        }

        public void OrquestrarAtualizacaoDeValoresEPercentuais(decimal valor_total_por_tipo_investimento, decimal total_geral)
        {
            AtualizarValorAtual(valor_total_por_tipo_investimento);
            AtualizarPercentualAtual(total_geral);
            AtualizarPercentualDiferenca();
            AtualizarValorDiferenca();
        }


    }
}
