using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Emprestimo : Transacao
    {
        // Valor é herdado de Transacao
        public int Id { get; set; }
        public List<Parcela> Parcelas { get; set; } // Conjunto de parcelas com seus respectivos valores
        public string FormaPagamento { get; set; } // Boleto ou Débito em conta
        public double Limite { get; set; } // Limite de crédito
        public double TaxaJuros { get; set; } // Taxa de juros em % que está submetido o empréstimo
        public ContaContabilEmprestimo ContaContabil { get; set; }
        public bool Pendente // Indica se há parcelas pendentes
        {
            get
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

        // Gera parcelas com base no cálculo asdf
        public void GerarParcelas()
        {

        }

        // Quitar uma parcela específica deste empréstimo, adiciona nas transacoes
        public void PagarParcela(Parcela p)
        {
            p.Status = "Pago";
            Transacao t = new Transacao()
            {
                Tipo = "Pagamento",
                Valor = -p.Valor,
                Data = DateTime.Today,
                Conta = this.Conta,
                Descricao = "Pagamento parcela: " + p.Numero + "/" + Parcelas.Count
            };
            this.Conta.Transacoes.Add(t);
        }

        // Quitar todas as parcelas
        public void PagarTotal()
        {
            foreach (Parcela p in Parcelas)
            {
                PagarParcela(p);
            }
        }

        // Retorna o valor total pendente para pagamento
        public double ValorPendente()
        {
            double result = 0;
            foreach (Parcela p in Parcelas)
            {
                if (p.Status.Equals("Pendente")) result += p.Valor;
            }
            return result;
        }
    }
}