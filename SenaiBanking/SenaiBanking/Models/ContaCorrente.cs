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
        public List<Transacao> Transacoes { get; set; }

        public void Sacar(double valor)
        {
            if (valor <= Saldo + Limite)
            {
                Saque saque = new Saque()
                {
                    Valor = valor,
                    Conta = this,
                    Data = DateTime.Now,
                    Tipo = "Saque",
                    Descricao = "Saque realizado"
                };
                Transacoes.Add(saque);
                // Guardar o saque na tabela de transacoes/saques no banco
                Saldo -= valor;
            }
            else
            {
                // Fazer tratamento de denial, talvez mude assinatura do método
            }
        }

        public void Depositar(double valor)
        {
            Deposito deposito = new Deposito()
            {
                Valor = valor,
                Conta = this,
                Data = DateTime.Now,
                Tipo = "Depósito",
                Descricao = "Depósito realizado"
            };
            Transacoes.Add(deposito);
            // Guardar a transação para extrato
            Saldo += valor;
        }

    }
}