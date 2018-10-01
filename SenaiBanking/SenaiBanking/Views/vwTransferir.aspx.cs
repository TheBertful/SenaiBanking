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
                txtMsg.Visible = false;
                txtMsgError.Visible = false;
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
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
                ContaCorrente conta2 = Session["ContaCorrente2"] as ContaCorrente;
                String texto = txtValor.Text;
                texto = texto.Replace('.', ',');
                Double valor = Math.Round(Convert.ToDouble(texto), 2);
                if (valor <= conta.Saldo)
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

                        txtMsg.Visible = true;
                        txtMsg.Text = "Transferencia realizada com sucesso... Valor: R$" + valor + " para a conta: " + conta2.Numero + " Proprietário: " + conta2.ClienteProp.Nome;
                    }
                    else
                    {
                        txtMsgError.Visible = true;
                        txtMsgError.Text = "Valor informado é inválido...";
                    }
                }
                else
                {
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "Valor informado excede o Saldo...";
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                txtMsgError.Visible = true;
                txtMsgError.Text = "Informe um valor válido";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}