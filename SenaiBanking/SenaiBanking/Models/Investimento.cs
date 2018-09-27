using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Investimento
    {
        public DateTime DataInvestimento { get; set; } // Data em que o investimento foi feito
        public double Valor { get; set; } // Valor investido
        public double Rendimento { get; set; } // Porcentagem de rendimento ao ano. Pode variar(Posfix) e ser indexado em outro valor
        public string Liquidez { get; set; } // Indica se a retirada é possível diariamente, ou apenas no vencimento
    }
}