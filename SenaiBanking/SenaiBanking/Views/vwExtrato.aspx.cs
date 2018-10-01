using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Extrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if(conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                txtMsgError.Visible = false;
                txtMsg.Visible = false;
            }

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
                DateTime DataIni = Convert.ToDateTime(DtaInicio.SelectedDate.ToShortDateString());
                DateTime DataFim = Convert.ToDateTime(DtaFim.SelectedDate.ToShortDateString());

                gvdExtrato.DataSource = conta.Transacoes;
                gvdExtrato.DataBind();
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                txtMsgError.Text = "Verifique se todos os campos estão preenchidos...";
            }
           

            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}