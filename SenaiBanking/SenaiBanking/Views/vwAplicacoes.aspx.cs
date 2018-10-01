using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Aplicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

            if (conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                lblSaldoAtual.Text = Convert.ToString(conta.Saldo);
              //  lblData.Text = DateTime.Now();
            }
            else
            {
                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (Convert.ToDouble(txtValorAplicar.Text) > (conta.Saldo))
            {
                txtMsgError.Text = "Atenção!! Valor maior que o saldo da conta";
            }
            else if (Convert.ToDouble(txtValorAplicar.Text) > 0)
            {
              //  conta.AplicarInvestimento();
            }
           
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwTiposInvestimento.aspx");
        }

        protected void txtValorAplicar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}