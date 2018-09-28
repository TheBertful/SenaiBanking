using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Investimento : Transacao
    {
        // Data em que o investimento foi feito herdado de Transacao
        public DateTime Vencimento { get; set; } // Data em que o investimento vence
        public double ValorInicial { get; set; } // Valor inicialmente aplicado
        // Valor que está aplicado atualmente (vamos trabalhar somente com retirada integral) herdado de Transacao
        public double Rendimento { get; set; } // Porcentagem de rendimento. Pode variar(Posfix) e ser indexado em outro valor, ser ao ano, semestral ou mensal
        public string Liquidez { get; set; } // Indica se a retirada é possível diariamente, ou apenas no vencimento
        public double Taxa { get; set; } // Taxa cobrada para cálculo do rendimento líquido X bruto, em % também
        public double Carencia { get; set; } // Período mínimo, em dias, para retirada do valor. Retirar antes incorre em mais taxas
        public double Imposto { get; set; } // Imposto incidido, em porcentagem
        public string TipoInvestimento { get; set; } // Prefixado ou Posfixado
        public ContaContabilInvestimento ContaContabil { get; set; } // Conta contábil a que pertence o Investimento

        // Método que atualiza o valor aplicado de acordo com a porcentagem de Rendimento
        public virtual void Render()
        {
            double aumento = Valor * Rendimento;
            Valor += aumento;
            // Enviar atualização para Conta Contábil de Investimentos
        }

        // Calcula o valor total do 'lucro' atual
        public double CalcularRendimentoBruto()
        {
            return Valor - ValorInicial;
        }

        // Calcula o valor em dinheiro descontado de acordo com as taxas de cobrança
        public virtual double CalcularTaxa()
        {
            return 0;
        }

        // Calcula o rendimento líquido, após incidência de taxas e impostos
        public double CalcularRendimentoLiquido()
        {
            return CalcularRendimentoBruto() - CalcularTaxa();
        }

        // Pós incidência de impostos
        public double CalcularRendimentoFinal()
        {
            return CalcularRendimentoLiquido() - CalcularImposto();
        }

        // Calcula os impostos incididos sobre a renda em dinheiro
         public virtual double CalcularImposto()
        {
            return CalcularRendimentoLiquido() * (Imposto / 100);
        }
    }
}