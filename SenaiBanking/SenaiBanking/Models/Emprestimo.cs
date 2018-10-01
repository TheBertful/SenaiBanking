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
        
        // Verifica as parcelas do empréstimo, se pelo menos uma estiver pendente, ele está pendente
        public bool IsPendente()
        {
            foreach (Parcela parcela in Parcelas)
            {
                if (parcela.Status.Equals("Pendente"))
                {
                    return true;
                }
            }
            return false;
        }

    }
}