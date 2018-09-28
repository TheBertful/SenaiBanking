using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class InvestimentoTesouroDireto : InvestimentoIndexado
    {
        // Taxa cobrada costuma ser serviço(da corretora ou banco, de 0 a 2%) + taxa de custódia da B3
        public InvestimentoTesouroDireto() : base()
        {
            Indexador = 6.5; // Selic atual pra exemplo
            Porcentagem = 100;
            Random r = new Random();
            Taxa = 0.3 + r.NextDouble() * 2;
        }

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