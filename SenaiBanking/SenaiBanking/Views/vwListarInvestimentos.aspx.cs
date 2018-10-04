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
    public partial class vwListarInvestimentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

            if (conta == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
            else
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                PopulateGridInvestimento();
            }

        }

        public void PopulateGridInvestimento()
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            DataTable dt = new DataTable();

            dt.Columns.Add("Descricao", Type.GetType("System.String"));
            dt.Columns.Add("DataSolicitacao", Type.GetType("System.String"));
            dt.Columns.Add("Rendimento", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));
            dt.Columns.Add("ValorTotal", Type.GetType("System.String"));


            List<Investimento> lista = conta.ListarInvestimentos();
            if (lista != null)
            {
                lista.ForEach(item =>
                {
                    DataRow dr = dt.NewRow();

                    dr["Descricao"] = item.Descricao;
                    dr["DataSolicitacao"] = item.Data.ToShortDateString();
                    dr["Rendimento"] = item.Rendimento.ToString();
                    dr["Vencimento"] = item.Vencimento.ToShortDateString();
                    dr["ValorTotal"] = item.Valor.ToString();
                    dt.Rows.Add(dr);
                });
            }
            gdvListarInvestimentos.DataSource = dt;
            gdvListarInvestimentos.DataBind();
        }

        protected void txtValorResgatar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwInvestimentos.aspx");
        }

        protected void gdvListarInvestimentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
