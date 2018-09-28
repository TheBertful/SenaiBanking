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
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            Transacao transferir = new Transacao()
            {
               Conta = conta.Numero,
               
            };

            List<Tranferencia> classe = Session["Transferir"] as List<Tranferencia>;
            classe.Add(transferir);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}