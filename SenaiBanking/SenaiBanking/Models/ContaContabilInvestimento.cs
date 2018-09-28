using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class ContaContabilInvestimento : IContaContabil
    {
        public List<Investimento> Investimentos { get; set; }

        public double CalcularSaldo()
        {
            double saldo = 0;
            foreach (Investimento investimento in Investimentos)
            {
                saldo += investimento.Valor;
            }
            return saldo;
        }
    }
}