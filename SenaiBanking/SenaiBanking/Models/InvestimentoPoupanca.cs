using System;

namespace SenaiBanking.Models
{
    public class InvestimentoPoupanca : InvestimentoIndexado
    {
        public double TaxaReferencial { get; set; }
        public DateTime Aniversario { get; set; }

        public InvestimentoPoupanca() : base()
        {
            // Tratar valor do rendimento da poupança de acordo com a Selic atual
            // 70% da Selic se ela estiver igual ou abaixo de 8,5%, caso contrário 0.5% ao mês
            // Adicionar a Taxa Referencial, independentemente de qual dos dois casos acima
            TipoInvestimento = "Poupança";
            Vencimento = DateTime.Now.AddYears(20);
            Indexador = 6.5; // Selic Atual
            Porcentagem = 70;
            TaxaReferencial = 0.6; // Dados de 2017
            if (Indexador > 8.5)
            {
                Rendimento = 0.5;
            }
            else
            {
                Rendimento = Indexador * (Porcentagem / 100);
            }

            Rendimento += TaxaReferencial;

            // Liquidez é diária/instantânea
            Liquidez = "Diária";
            Imposto = 0;
        }

        // Divisão da Renda gerada por mês
        public override void Render()
        {
            double aumento = Math.Round(Valor * ((Rendimento / 12) / 100), 2); // divide no mês
            Valor += aumento;
        }

    }
}