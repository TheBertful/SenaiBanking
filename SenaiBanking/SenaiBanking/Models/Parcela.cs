using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Parcela
    {
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public string Numero { get; set; }
        public string Status { get; set; }
    }
}