﻿using SenaiBanking.Models;
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
            ContaCorrente conta = Session["Contacorrente"] as ContaCorrente;
            lblLimite.Text = "Você possui R$ 900,00 de limite para o empréstimo.";
            if (!IsPostBack)
            {
                txtValor.Text = "0";
            }
            if ((Session["ContaCorrente"] as ContaCorrente) != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            { 
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        public List<Parcela> PopulateGrid()
        {
            int parcelas = Convert.ToInt32(ddlQuantidadeParcelas.SelectedValue);
            double valor = Convert.ToDouble(txtValor.Text);
            List<Parcela> resultado = new List<Parcela>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Parcela", Type.GetType("System.String"));
            dt.Columns.Add("Valor", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));


            if (valor != 0)
            {
                //var acumulador = 0.0;
                for (var i = 0; i < parcelas; i++)
                {
                    valor = valor + (valor * 0.05);
                    //acumulador = acumulador + valor;
                }
                var parcela = valor / parcelas;

                for (var i = 0; i < parcelas; i++)
                {
                    DateTime dataAtual = DateTime.Now;

                    Parcela p = new Parcela();
                    p.Valor = Math.Round(parcela, 2);
                    p.Status = "Pendente";
                    p.Vencimento = dataAtual.AddMonths(i + 1);
                    p.Numero = (i + 1).ToString() + " / " + parcelas.ToString();
                    
                    DataRow dr = dt.NewRow();
                    dr["Parcela"] = p.Numero;
                    dr["Valor"] = "R$ " + p.Valor.ToString();
                    dr["Vencimento"] = p.Vencimento.ToShortDateString();
                    dt.Rows.Add(dr);
                    gdvParcelas.DataSource = dt;
                }
            }
            else
            {
                gdvParcelas.DataSource = null;
            }
            gdvParcelas.DataBind();
            return resultado;
        }

        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
            double numero = 0;

            if (double.TryParse(txtValor.Text, out numero))
            {
                if (numero > 900)
                {
                    txtValor.Text = "900";
                }
            }
            else
            {
                txtValor.Text = "0";
            }
            PopulateGrid();
        }

        protected void ddlQuantidadeParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        protected void btnConcluir_Click(object sender, EventArgs e)
        {

            //DateTime agora = DateTime.Now;
            //DateTime depois = DateTime.Now.AddSeconds(3);

            //while (agora < depois)
            //{
            //    agora = DateTime.Now;
            //}

            gdvParcelas.Visible = false;
            lblLimite.Visible = false;
            lblQuantidadeParcelas.Visible = false;
            lblValor.Visible = false;
            txtValor.Visible = false;
            btnConcluir.Visible = false;
            ddlQuantidadeParcelas.Visible = false;
            lblTipoEmprestimo.Visible = false;
            ddlTipoEmprestimo.Visible = false;
            lblDescricao.Visible = false;
            txtDescricao.Visible = false;
            lblFormaPagamento.Visible = false;
            ddlFormaPagamento.Visible = false;

            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            List<Emprestimo> emprestimos = Session["Emprestimos"] as List<Emprestimo>;


            conta.Saldo = conta.Saldo + Convert.ToDouble(txtValor.Text);

            Emprestimo emp = new Emprestimo()
            {
                Valor = Convert.ToDouble(txtValor.Text),
                Conta = conta,
                Data = DateTime.Now,
                Descricao = txtDescricao.Text,
                Tipo = ddlTipoEmprestimo.SelectedValue,
                FormaPagamento = ddlFormaPagamento.SelectedValue,
                Parcelas = PopulateGrid()
            };
            emprestimos.Add(emp);
            Session["Emprestimos"] = emprestimos;
            Session["ContaCorrente"] = conta;
            lblAviso.Text = "Emprestimo realizado com sucesso! Seu novo saldo é de: R$ " + conta.Saldo.ToString();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}