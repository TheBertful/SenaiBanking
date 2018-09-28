using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Investimentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMeusInvestimentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TiposInvestimento.aspx");
        }

        protected void btnAplicacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TiposInvestimento.aspx");
        }

        protected void btnResgate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TiposInvestimento.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Principal.aspx");
        }
    }
}