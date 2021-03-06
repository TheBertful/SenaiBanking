﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class ContaContabilEmprestimo : IContaContabil
    {
        public List<Emprestimo> Emprestimos { get; set; }
        public Banco BancoProp { get; set; }

        // Retorna o valor de todas as pendencias de empréstimo de cada conta corrente do banco
        public double CalcularSaldo()
        {
            double saldo = 0;
            foreach (Emprestimo emprestimo in Emprestimos)
            {
                saldo += emprestimo.ValorPendente();
            }
            return saldo;
        }
    }
}