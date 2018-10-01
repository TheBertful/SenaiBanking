using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Transferir : System.Web.UI.Page
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

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroConta = Convert.ToInt32(txtConta.Text);
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
                ContaCorrente conta2 = Session["ContaCorrente2"] as ContaCorrente;
                String texto = txtValor.Text;
                texto = texto.Replace('.', ',');
                Double valor = Math.Round(Convert.ToDouble(texto), 2);
                if ((valor <= conta.Saldo) && (Convert.ToUInt32(conta2.Numero) == numeroConta))
                {
                    if(valor > 0)
                    {
                        Transferencia transferir = new Transferencia()
                        {
                            Conta = conta,
                            Data = DateTime.Now,
                            Descricao = "Transferencia da Conta de numero: " + conta.Numero + " Proprietário: " + conta.ClienteProp.Nome + "  para a Conta de numero: " +
                            conta2.Numero + " Proprietário: " + conta2.ClienteProp.Nome + " no valor de: R$" + valor + " na data referente: " + DateTime.Now,
                            Favorecido = conta2,
                            Tipo = "transferencia",
                            Valor = valor
                        };
                        conta.Transferir(valor, conta2);
                        lblMsg.Visible = true;
                        lblMsg.Text = "Transferencia realizada com sucesso... Valor: R$" + valor + " para a conta: " + conta2.Numero + " Proprietário: " + conta2.ClienteProp.Nome;
                    }
                    else
                    {
                        lblMsgError.Visible = true;
                        lblMsgError.Text = "Valor informado é inválido...";
                    }
                }
                else
                {
                    lblMsgError.Visible = true;
                    lblMsgError.Text = "Valor informado excede o Saldo, ou numero da conta é inválido...";
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                lblMsgError.Visible = true;
                lblMsgError.Text = "Informe um valor válido";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}