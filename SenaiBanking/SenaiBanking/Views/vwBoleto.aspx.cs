using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class vwBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (conta != null)
            {
                lblMsg.Visible = false;
                lblMsgError.Visible = false;
            }
            else
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        protected void btnDeclarar_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            Parcela parcela = Session["parcela"] as Parcela;
 
            Emprestimo emprestimo = parcela.EmprestimoProp;
            emprestimo.PagarParcela(parcela);

            lblMsg.Visible = true;
            lblMsg.Text = "OK parcela paga";

            Session["parcela"] = null;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwListarEmprestimos.aspx"); 
        }
    }
}