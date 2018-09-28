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
            Transferencia transferir = new Transferencia()
            {
               Conta = conta,
<<<<<<< HEAD
               Data = DateTime.Now,


=======
               
>>>>>>> a4f8d2e1bce2c1e8db3360d8c67252004fcd0fa2
            };

            List<Transferencia> classe = Session["Transferir"] as List<Transferencia>;
            classe.Add(transferir);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}