using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class ContaCorrente : Conta
    {
        public double Limite { get; set; }
    }
}