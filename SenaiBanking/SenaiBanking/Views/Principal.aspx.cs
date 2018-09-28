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
            if(conta != null)
            {
                lblSaudacao.Text = conta.ClienteProp.Nome;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnSaque_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Sacar.aspx");

        }

        protected void btnDeposito_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Depositar.aspx");
        }

        protected void btnTransferencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Transferir.aspx");
        }

        protected void btnInvestimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Investimentos.aspx");
        }

        protected void btnEmprestimo_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaldo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Saldo.aspx");
        }

        protected void btnExtrato_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Extrato.aspx");
        }
    }
}