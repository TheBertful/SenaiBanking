using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class TiposInvestimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD

=======
>>>>>>> 23b78e21f201696ec5b6be33f8e36432f67643d7
        protected void btnTesouro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Aplicacoes.aspx");
        }

        protected void btnCDB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Aplicacoes.aspx");
<<<<<<< HEAD
        }

        protected void btnCdb_Click(object sender, EventArgs e)
        {

=======
>>>>>>> 23b78e21f201696ec5b6be33f8e36432f67643d7
        }

        protected void btnPoupanca_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            Response.Redirect("~/Views/Aplicacoes.aspx");


=======
            Response.Redirect("~/Views/Aplicacoes.aspx");
>>>>>>> 23b78e21f201696ec5b6be33f8e36432f67643d7
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}