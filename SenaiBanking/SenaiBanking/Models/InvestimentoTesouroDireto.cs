using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace SenaiBanking.Models
{
    public class InvestimentoTesouroDireto : InvestimentoIndexado
    {
        // Taxa cobrada costuma ser serviço(da corretora ou banco, de 0 a 2%) + taxa de custódia da B3
        public InvestimentoTesouroDireto() : base()
        {
            TipoInvestimento = "Tesouro Direto";
            
            Porcentagem = 100;
            Random r = new Random();
            Vencimento = DateTime.Now.AddYears(r.Next(5,11));
            Indexador = r.NextDouble() * (6.5 - 6) + 6; // Selic atual pra exemplo
            Taxa = 0.3 + r.NextDouble() * 2;
            Rendimento = Math.Round(Indexador * (Porcentagem / 100), 2);
        }

        // Imposto de Renda
        public override double CalcularImposto()
        {
            double dias = DateTime.Now.Subtract(Data).TotalDays;
            if (dias < 180)
            {
                Imposto = 22.5;
            }
            else if (dias < 360)
            {
                Imposto = 20;
            }
            else if (dias < 720)
            {
                Imposto = 17.5;
            }
            else
            {
                Imposto = 15;
            }
            return base.CalcularImposto();
        }

    }
}