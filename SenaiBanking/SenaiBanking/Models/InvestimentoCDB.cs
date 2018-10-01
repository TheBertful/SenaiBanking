using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class InvestimentoCDB : InvestimentoIndexado
    {
        // Colocar informações específicas padrão
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