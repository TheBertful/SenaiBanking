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
                lblMsgError.Visible = false;
                lblMsg.Visible = false;

                if(!IsPostBack)
                {

                }
            }
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
                DateTime DataIni = Convert.ToDateTime(DtaInicio.SelectedDate.ToShortDateString());
                DateTime DataFim = Convert.ToDateTime(DtaFim.SelectedDate.ToShortDateString());

                DateTime DataCompara = Convert.ToDateTime("01/01/0001");
                int result = DateTime.Compare(DataIni, DataCompara);
                if (result != 0)
                {
                    result = DateTime.Compare(DataIni, DataFim);
                    int result1 = DateTime.Compare(DataFim, DataIni);
                    if (((result < 0) && (result1 > 0)) || (result1 == 0))
                    {
                        var resultado = conta.Transacoes.Where(x => x.Data.Date >= DataIni.Date).Where(y => y.Data.Date <= DataFim.Date);
                        gvdExtrato.DataSource = resultado;
                        gvdExtrato.DataBind();

                        lblMsg.Visible = true;
                        lblMsg.Text = "Movimentações da conta referente as dias "+DataIni.ToString()+ " até " +DataFim.ToString();
                    }
                    else
                    {
                        lblMsgError.Visible = true;
                        lblMsgError.Text = "Verifique se a data de Inicio é menor que a Data Final...";
                    }
                }
                else
                {
                    lblMsgError.Visible = true;
                    lblMsgError.Text = "Verifique se as datas estão corretas...";
                }  
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                lblMsgError.Visible = true;
                lblMsgError.Text = "Verifique se todos os campos estão preenchidos...";
            }     
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}