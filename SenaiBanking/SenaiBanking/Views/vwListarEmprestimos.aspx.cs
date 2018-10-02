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
    public partial class vwListarEmprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ContaCorrente"] as ContaCorrente) == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
            PopulateGridEmprestimos();
        }
        public void PopulateGridEmprestimos()
        {
            //List<Emprestimo> emprestimos = Session["emprestimos"] as List<Emprestimo>;
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Tipo", Type.GetType("System.String"));
            dt.Columns.Add("Descricao", Type.GetType("System.String"));
            dt.Columns.Add("FormaPagamento", Type.GetType("System.String"));
            dt.Columns.Add("Data", Type.GetType("System.String"));
            dt.Columns.Add("Parcelas", Type.GetType("System.String"));
            //if(emprestimos != null)
            //if (conta.BancoProp.ContaEmprestimo.Emprestimos != null)
            List<Emprestimo> lista = conta.ListarEmprestimos();
            if (lista != null)
            {
                conta.ListarEmprestimos().ForEach(item => {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = item.Id;
                    dr["Tipo"] = item.Tipo;
                    dr["Descricao"] = item.Descricao;
                    dr["FormaPagamento"] = item.FormaPagamento;
                    dr["Data"] = item.Data.ToShortDateString();
                    dr["Parcelas"] = item.Parcelas.Count().ToString();
                    dt.Rows.Add(dr);
                });
            }
            gdvEmprestimos.DataSource = dt;
            gdvEmprestimos.DataBind();
        }

        protected void gdvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            //List<Emprestimo> emprestimos = Session["emprestimos"] as List<Emprestimo>;
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            List<Emprestimo> lista = conta.ListarEmprestimos();
            List<Parcela> parcelas = new List<Parcela>();

            Emprestimo emprestimo = null;
            //emprestimos.ForEach(item => {
            lista.ForEach(item => { 
                if(item.Id == id)
                {
                    emprestimo = item;
                }
            });

            DataTable dt = new DataTable();

            dt.Columns.Add("Numero", Type.GetType("System.String"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));
            dt.Columns.Add("Valor", Type.GetType("System.String"));
            if (emprestimo != null)
            {
                emprestimo.Parcelas.ForEach(item => {
                    DataRow dr = dt.NewRow();
                    dr["Numero"] = item.Numero.ToString();
                    dr["Status"] = item.Status;
                    dr["Vencimento"] = item.Vencimento.ToShortDateString();
                    dr["Valor"] = item.Valor.ToString();
                    dt.Rows.Add(dr);
                });
            }
            if (emprestimo != null)
            {
                if(emprestimo.FormaPagamento.Equals("Boleto"))
                {
                    gdvParcelasDebitoEmConta.DataSource = null;
                    gdvParcelasBoleto.DataSource = dt;
                    gdvParcelasBoleto.DataBind();
                    gdvParcelasDebitoEmConta.DataBind();
                    PopulateGridEmprestimos();
                } else
                {
                    gdvParcelasBoleto.DataSource = null;
                    gdvParcelasDebitoEmConta.DataSource = dt;
                    gdvParcelasDebitoEmConta.DataBind();
                    gdvParcelasBoleto.DataBind();
                    PopulateGridEmprestimos();
                }
                
            }
            Session["emprestimo"] = emprestimo;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }

        protected void gdvParcelasBoleto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = 0;
            string numero = e.CommandArgument.ToString();
            if(numero.Length > 5)
            {
                id = Convert.ToInt32(numero.Substring(0, 2));
            }
            else
            {
                id = Convert.ToInt32(numero.Substring(0, 1));
            }

            Emprestimo emp = Session["emprestimo"] as Emprestimo;
            Parcela p = new Parcela();
            int count = 1;
            emp.Parcelas.ForEach(item => {
                if (count == id)
                    p = item;
                count++;
            });
            Session["parcela"] = p;

            Response.Redirect("~/Views/vwBoleto.aspx");
        }

        protected void gdvParcelasDebitoEmConta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = 0;
            string numero = e.CommandArgument.ToString();
            if (numero.Length > 5)
            {
                id = Convert.ToInt32(numero.Substring(0, 2));
            }
            else
            {
                id = Convert.ToInt32(numero.Substring(0, 1));
            }

            Emprestimo emp = Session["emprestimo"] as Emprestimo;
            Parcela p = new Parcela();
            int count = 1;
            emp.Parcelas.ForEach(item => {
                if (count == id)
                    p = item;
                count++;
            });
            Session["parcela"] = p;

            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            conta.PagarParcela(p);
        }
    }
}