using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Depositar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (conta != null)
            {
                txtMsg.Visible = false;
                txtMsgError.Visible = false;
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        protected void btnDepositar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = Session["contacorrente"] as ContaCorrente;
                double valor = Convert.ToDouble(txtDeposito.Text);
                conta.Transacoes = new List<Transacao>();
                conta.Depositar(valor);
                txtMsg.Visible = true;
                txtMsg.Text = "O deposito foi realizado com sucesso no valor de R$" + Math.Round(valor,2) + " | Seu saldo atual é de R$" + Math.Round(conta.Saldo,2);
            }
            catch(Exception erro)
            {
                txtMsgError.Visible = true;
                txtMsgError.Text = "Não foi possível realizar o seu deposito";
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}