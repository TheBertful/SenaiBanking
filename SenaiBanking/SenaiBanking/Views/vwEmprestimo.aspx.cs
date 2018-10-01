using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class vwEmprestimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            { 
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwSolicitarEmprestimo.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwListarEmprestimos.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}