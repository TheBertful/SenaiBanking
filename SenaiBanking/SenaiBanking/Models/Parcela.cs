using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public DateTime Vencimento { get; set; } // Data de vencimento da mesma, para fins de pagamento automático
        public double Valor { get; set; } // Valor a ser pago
        public string Numero { get; set; } // Numero ordenado da Parcela
        public string Status { get; set; } // Pode ser "Pendente" ou "Pago", representa se a parcela foi paga
        public Emprestimo EmprestimoProp { get; set; } // Empréstimo ao qual a parcela está vinculada
    }
}