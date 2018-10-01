using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Emprestimo : Transacao
    {
        // Valor é herdado de Transacao
        public List<Parcela> Parcelas { get; set; }
        public string FormaPagamento { get; set; }
        
        // Verifica as parcelas do empréstimo, se pelo menos uma estiver pendente, ele está pendente
        public bool IsPendente()
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

        // Quitar uma parcela específica deste empréstimo, adiciona nas transacoes
        public void QuitarParcela(Parcela p)
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
        }

        // Quitar todas as parcelas
        public void QuitarTudo()
        {
            foreach (Parcela p in Parcelas)
            {
                QuitarParcela(p);
            } 
        }
    }
}