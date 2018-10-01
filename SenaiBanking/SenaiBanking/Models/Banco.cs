using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Banco
    {
        public string Nome { get; set; }
        public ContaContabilEmprestimo ContaEmprestimo { get; set; }
        public ContaContabilInvestimento ContaInvestimento { get; set; }
    }
}