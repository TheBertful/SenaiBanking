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
                //txtMsg.Visible = false;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            ContaCorrente conta2 = Session["ContaCorrente2"] as ContaCorrente;

            Transferencia transferir = new Transferencia()
            {
               Conta = conta,
               Data = DateTime.Now,
               Descricao = "Transferencia da Conta de numero: "+conta.Numero+" Proprietário: "+conta.ClienteProp.Nome+"  para a Conta de numero: "+
               conta2.Numero+" Proprietário: "+conta2.ClienteProp.Nome+" no valor de: R$"+ txtValor.Text + " na data referente: "+DateTime.Now,
               Favorecido = conta2,
               Tipo = "transferencia",
               Valor = Convert.ToDouble(txtValor.Text)
            };

            conta.Sacar(Convert.ToDouble(txtValor.Text));
            //conta2.Depositar(Convert.ToDouble(txtValor.Text));

            List<Transferencia> classe = Session["Transferir"] as List<Transferencia>;
            classe.Add(transferir);

            // txtMsg.Visible = true;
            // txtMsg.Text = "Transferencia realizada com sucesso... Valor: R$"+txtValor.Text+" para a conta: "+conta2.Numero+" Proprietário: "conta2.conta2.ClienteProp.Nome";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}