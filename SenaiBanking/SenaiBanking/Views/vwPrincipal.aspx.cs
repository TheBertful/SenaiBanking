using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            ContaContabilEmprestimo cce = Session["Emprestimos"] as ContaContabilEmprestimo;
            ContaContabilInvestimento cci = Session["Investimentos"] as ContaContabilInvestimento;
            lblContaContabilEmprestimo.Text = cce.CalcularSaldo().ToString();
            lblContaContabilInvestimento.Text = cci.CalcularSaldo().ToString();
            if(conta != null)
            {
                lblSaudacao.Text = conta.ClienteProp.Nome;
            }
            else
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        protected void btnSaque_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwSacar.aspx");

        }

        protected void btnDeposito_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwDepositar.aspx");
        }

        protected void btnTransferencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwTransferir.aspx");
        }

        protected void btnInvestimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwInvestimentos.aspx");
        }

        protected void btnEmprestimo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwEmprestimo.aspx");
        }

        protected void btnSaldo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwSaldo.aspx");
        }

        protected void btnExtrato_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwExtrato.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["PrimeiroLogin"] = "Não";
            Response.Redirect("~/Views/vwLogin.aspx");
        }
    }
}