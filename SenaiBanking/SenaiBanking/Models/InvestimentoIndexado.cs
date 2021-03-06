﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class InvestimentoIndexado : Investimento
    {
        public double Indexador { get; set; } // Indexador que define o cálculo real do Rendimento
        public double Porcentagem { get; set; } // Porcentagem do indexador

        // Padrão é o investimento ter o Indexador como base
        public InvestimentoIndexado() : base()
        {
            Rendimento = Indexador * (Porcentagem / 100);
        }
    }
}