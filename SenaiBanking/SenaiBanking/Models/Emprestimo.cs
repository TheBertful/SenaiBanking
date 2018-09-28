using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Emprestimo : Transacao
    {
        // Valor é herdado de Transacao
        public List<Parcela> Parcelas { get; set; }
        public string FormaPagamento { get; set; }
        
    }
}