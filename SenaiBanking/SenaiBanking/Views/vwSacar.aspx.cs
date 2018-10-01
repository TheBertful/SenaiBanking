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
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (conta != null)
            {
                lblMsg.Visible = false;
                lblMsgError.Visible = false;
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        protected void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
                String texto = txtSacar.Text;
                texto = texto.Replace('.', ',');
                double valor = Math.Round(Convert.ToDouble(texto), 2);
                if(conta.Saldo >= valor)
                {
                    if(valor > 0)
                    {
                        conta.Sacar(valor);
                        lblMsg.Visible = true;
                        lblMsg.Text = "O saque foi realizado com sucesso, R$" + Math.Round(valor, 2) + " | Seu saldo atual é de R$" + Math.Round(conta.Saldo, 2);
                    }
                    else
                    {
                        lblMsgError.Visible = true;
                        lblMsgError.Text = "Verifique o valor informado";
                    }
                }
                else
                {
                    lblMsgError.Visible = true;
                    double total = conta.Saldo - valor;
                    lblMsgError.Text = "O valor do saque excede o valor em conta em: -R$" + Math.Abs(total);
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                lblMsgError.Visible = true;
                lblMsgError.Text = "Valor informado não é valido, Verifique o campo Valor";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}