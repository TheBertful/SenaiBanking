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

            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descricao", Type.GetType("System.String"));
            dt.Columns.Add("DataSolicitacao", Type.GetType("System.String"));
            dt.Columns.Add("Rendimento", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));
            dt.Columns.Add("ValorTotal", Type.GetType("System.String"));


            List<Investimento> lista = conta.ListarInvestimentosNaoResgatados();
            if (lista != null)
            {

                int i = 0;
                lista.ForEach(item =>
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = i;
                    dr["Descricao"] = item.Descricao;
                    dr["DataSolicitacao"] = item.Data.ToShortDateString();
                    dr["Rendimento"] = item.Rendimento.ToString();
                    dr["Vencimento"] = item.Vencimento.ToShortDateString();
                    dr["ValorTotal"] = item.Valor.ToString();
                    dt.Rows.Add(dr);
                    i++;
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

            try
            {
               Investimento investimento = Session["investimento"]as Investimento;

             
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

                conta.ResgatarInvestimento(investimento);
  
                txtMsgError.Visible = true;
                txtMsgError.Text = "Valor Resgatado: R$ " + investimento.Valor;

                PopulateGridListarInvestimento();

            }

            catch (Exception)
            {
                txtMsgError.Visible = true;
                txtMsgError.Text = "Não foi possível realizar sua aplicação, verifique o campo Valor";
            }
        }
    

        protected void gdvResgatarInvestimento_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gdvResgatarInvestimento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            Investimento investimento = conta.ListarInvestimentosNaoResgatados()[Convert.ToInt32(e.CommandArgument)];
            investimento.Render();
            Session["investimento"] = investimento;

            txtDescricao.Text = investimento.Descricao;
            txtRendimento.Text = Convert.ToString(investimento.Rendimento);
            txtValorTotal.Text = Convert.ToString(investimento.Valor);

        }
    }
}
