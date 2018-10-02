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
    public partial class vwResgatar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

            if (conta == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }

            PopulateGridListarInvestimento();

        }

        public void PopulateGridListarInvestimento()
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
                conta.ListarInvestimentos().ForEach(item =>
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
            gdvResgatarInvestimento.DataSource = dt;
            gdvResgatarInvestimento.DataBind();
        }

        public void PopulateGridResgatarInvestimento()
        {
            ContaCorrente contaCorrente = new ContaCorrente();

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwInvestimentos.aspx");

        }

        protected void gdvResgatar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescricao.Text = gdvResgatarInvestimento.SelectedRow.Cells[1].Text;
            txtRendimento.Text = gdvResgatarInvestimento.SelectedRow.Cells[3].Text;
            txtValorTotal.Text = gdvResgatarInvestimento.SelectedRow.Cells[5].Text;
        }

        protected void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtRendimento_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtValortotal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
