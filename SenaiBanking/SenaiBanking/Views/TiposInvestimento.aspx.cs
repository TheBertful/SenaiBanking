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
        protected void btnTesouro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Aplicacoes.aspx");
        }

        protected void btnCDB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Aplicacoes.aspx");
=======
        protected void btnCdb_Click(object sender, EventArgs e)
        {

        }

        protected void btnTesouro_Click(object sender, EventArgs e)
        {

>>>>>>> 62f2636d6ec2cb14b66f09d91ade78f2cb177622
        }

        protected void btnPoupanca_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Response.Redirect("~/Views/Aplicacoes.aspx");
=======

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
>>>>>>> 62f2636d6ec2cb14b66f09d91ade78f2cb177622
        }
    }
}