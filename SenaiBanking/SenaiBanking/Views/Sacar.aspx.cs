using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Saque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMsg.Visible = false;
        }

        public double Sacar(double valor)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Saldo -= valor;
            return valor;
        }

        protected void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente();
                double valor = Convert.ToDouble(txtSacar.Text);
                valor = Sacar(valor);
                txtMsg.Visible = true;
                txtMsg.Text = "O saque foi realizado com sucesso, R$" + valor + " | Seu saldo atual é de R$" + conta.Saldo;
            }
            catch (Exception erro)
            {
                txtMsg.Text = "Valor informado não é valido, Verifique o campo Valor";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}