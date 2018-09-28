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
            if (SaldoSuficiente(valor))
            {
                Saque saque = new Saque()
                {
                    Valor = -valor,
                    Conta = this,
                    Data = DateTime.Today,
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
                Data = DateTime.Today,
                Tipo = "Depósito",
                Descricao = "Depósito realizado"
            };
            Transacoes.Add(deposito);
            // Guardar a transação para extrato
            Saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente favorecido)
        {
            if (SaldoSuficiente(valor))
            {
                DateTime data = DateTime.Today;
                Transferencia transferencia = new Transferencia()
                {
                    Valor = -valor,
                    Conta = this,
                    Data = data,
                    Tipo = "Transferência",
                    Descricao = "Transferência realizada",
                    Favorecido = favorecido
                };
                Transacoes.Add(transferencia);
                Transferencia transferido = new Transferencia()
                {
                    Valor = valor,
                    Conta = favorecido,
                    Data = data,
                    Tipo = "Transferência",
                    Descricao = "Transferência recebida"
                };
                favorecido.Transacoes.Add(transferido);

                // Atualizar saldos
                Saldo -= valor;
                favorecido.Saldo += valor;
            }
        }

        // Retorna lista de Transacoes do tipo Saque, Depósito e Transferência
        public List<Transacao> ConsultarExtrato(DateTime inicio, DateTime fim)
        {
            List<Transacao> extrato = new List<Transacao>();
            foreach (Transacao t in Transacoes)
            {
                if ((t.Tipo == "Saque" || t.Tipo == "Depósito" || t.Tipo == "Transferência") && (t.Data <= fim && t.Data >= inicio))
                {
                    extrato.Add(t);
                }
            }
            return extrato;
        }



        private bool SaldoSuficiente(double valor)
        {
            return valor <= Saldo + Limite;
        }

    }
}