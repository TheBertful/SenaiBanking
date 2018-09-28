using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class ContaCorrente
    {
        public int Id { get; set; } // Banco de dados
        public Cliente ClienteProp { get; set; }
        public string Numero { get; set; }        
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public string Tipo { get; set; }

        public void Sacar(double valor)
        {
            if (valor > Saldo + Limite)
            {

            }
        }

    }
}