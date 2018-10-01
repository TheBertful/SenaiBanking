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
                    Descricao = "Transferência realizada para a conta: "+favorecido.Numero+" Proprietário: "+favorecido.ClienteProp.Nome,
                    Favorecido = favorecido
                };
                Transacoes.Add(transferencia);
                Transferencia transferido = new Transferencia()
                {
                    Valor = valor,
                    Conta = favorecido,
                    Data = data,
                    Tipo = "Transferência",
                    Descricao = "Transferência recebida da conta:"+this.Numero+" Proprietário: "+this.ClienteProp.Nome
                };
                favorecido.Transacoes.Add(transferido);

                // Atualizar saldos
                Saldo -= valor;
                favorecido.Saldo += valor;
            }
            else
            {
                // Tratar caso não tenha saldo
            }
        }

        // Retorna lista de Transacoes do tipo Saque, Depósito e Transferência
        public List<Transacao> ConsultarExtrato(DateTime inicio, DateTime fim)
        {
            List<Transacao> extrato = new List<Transacao>();
            foreach (Transacao t in Transacoes)
            {
                if ((t.Tipo.Equals("Saque") || t.Tipo.Equals("Depósito") || t.Tipo.Equals("Transferência")) && (t.Data <= fim && t.Data >= inicio))
                {
                    extrato.Add(t);
                }
            }
            return extrato;
        }

        public void AplicarInvestimento(Investimento investimento)
        {
            // TODO: Inserir na lista da contaContabil, e na lista de transações, após instanciar
            // TODO: Atualizar saldo ou não* decidir isso

        }

        public void ResgatarInvestimento(Investimento investimento)
        {
            // TODO: Remover da lista da ContaContabil, status resgatado talvez
        }

        // Realiza a solicitação de um empréstimo
        public void SolicitarEmprestimo(Emprestimo emprestimo)
        {

        }

        // Retorna os investimentos vinculados à conta
        public List<Investimento> ListarInvestimentos()
        {
            List<Investimento> investimentos = new List<Investimento>();
            foreach(Transacao t in Transacoes)
            {
                if(t.Tipo.Equals("Investimento"))
                {
                    investimentos.Add(t as Investimento);
                }
            }
            return investimentos;
        }

        // Retorna os investimentos não-resgatados
        public List<Investimento> ListarInvestimentosNaoResgatados()
        {
            List<Investimento> investimentos = ListarInvestimentos();
            List<Investimento> aplicados = new List<Investimento>();
            foreach (Investimento i in investimentos)
            {
                if (i.Status.Equals("Aplicado")) aplicados.Add(i);
            }
            return aplicados;
        }

        // Retorna os empréstimos da conta
        public List<Emprestimo> ListarEmprestimos()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();
            foreach (Transacao t in Transacoes)
            {
                if (t.Tipo.Equals("Empréstimo"))
                {
                    emprestimos.Add(t as Emprestimo);
                }
            }
            return emprestimos;
        }

        // Retorna os empréstimos pendentes
        public List<Emprestimo> ListarEmprestimosPendentes()
        {
            List<Emprestimo> emprestimos = ListarEmprestimos();
            List<Emprestimo> pendentes = new List<Emprestimo>();
            foreach (Emprestimo e in emprestimos)
            {
                if (e.IsPendente()) pendentes.Add(e);
            }
            return pendentes;
        }

        private bool SaldoSuficiente(double valor)
        {
            return valor <= Saldo + Limite;
        }

    }
}