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
                txtAviso.Visible = false;
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
                ContaCorrente conta = Session["contacorrrente"] as ContaCorrente;
                double valor = Convert.ToDouble(txtDeposito.Text);
                conta.Depositar(valor);
                txtAviso.Visible = true;
                txtAviso.Text = "O deposito foi realizado com sucesso, R$" + valor + " | Seu saldo atual é de R$" + conta.Saldo;
            }
            catch(Exception erro)
            {
                Console.WriteLine(erro);
                txtAviso.Visible = true;
                txtAviso.Text = "Não foi possível realizar o seu deposito";
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}