using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public Cliente ClienteProp { get; set; }
        public int Numero { get; set; }
        public string Senha { get; set; }
        public double Saldo { get; set; }
    }
}