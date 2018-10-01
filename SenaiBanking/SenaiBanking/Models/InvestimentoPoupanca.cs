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
            Porcentagem = 70;
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
        }
    }
}