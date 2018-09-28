using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Transacao
    {
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public ContaCorrente Conta { get; set; }
        public string Descricao { get; set; }
    }
}