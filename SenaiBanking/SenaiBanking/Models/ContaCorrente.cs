using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class ContaCorrente
    {
        public int Id { get; set; } // Banco de dados
        public Cliente ClienteProp { get; set; } // Referência ao cliente, para login
        public string Numero { get; set; } // Número da conta
        public double Saldo { get; set; } // Saldo atual da conta
        public double Limite { get; set; } // Limite de crédito disponível
        public string Tipo { get; set; } // Tipo da conta, para eventual valor padrão na criação
        public List<Transacao> Transacoes { get; set; } // Acumulado de transações feitas pela conta
        public Banco BancoProp { get; set; }

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
            // Inserir na lista da contaContabil, e na lista de transações, e fazer as relações bilaterais
            // Se saldo for suficiente, instanciar uma Transação de aplicação(p/ extrato) e incluir na lista de transações o investimento em si
            if(SaldoSuficiente(investimento.Valor))
            {
                investimento.Status = "Aplicado";
                investimento.Conta = this;
                Transacoes.Add(investimento);
                investimento.ContaContabil = BancoProp.ContaInvestimento;
                investimento.ContaContabil.Investimentos.Add(investimento);
                
                Transacao t = new Transacao()
                {
                    Tipo = "Aplicação",
                    Conta = this,
                    Valor = -investimento.Valor,
                    Data = DateTime.Today,
                    Descricao = "Aplicação feita no investimento '" + investimento.Descricao + "'"
                };

            }
        }

        public void ResgatarInvestimento(Investimento investimento)
        {
            // Não precisa remover da lista da ContaContabil, status resgatado na lista Transacoes

        }

        // Realiza a solicitação de um empréstimo
        public void SolicitarEmprestimo(Emprestimo emprestimo)
        {
            // Adicionar na lista da conta contábil e de transacoes da conta
            // Atualizar saldo

        }

        // Paga parcela de empréstimo
        public void PagarParcela(Parcela p)
        {
            // Atualizar conta contábil não é necessário, apenas criar transação de pagamento de parcelas

        }

        // Paga empréstimo todo
        public void PagarEmprestimo(Emprestimo e)
        {
            // Atualizar conta contábil não é necessário, pelo cálculo
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