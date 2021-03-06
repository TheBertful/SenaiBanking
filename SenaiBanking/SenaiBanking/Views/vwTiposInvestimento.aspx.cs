﻿using SenaiBanking.Models;
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
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

            if(conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            {
                Response.Redirect("~/Views/vwPrincipal.aspx"); 
            }

        }

        protected void btnTesouro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwAplicacoesTesouro.aspx");

        }

        protected void btnCDB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwAplicacoesCDB.aspx");

        }

        protected void btnCdb_Click(object sender, EventArgs e)
        {

        }

        protected void btnPoupanca_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/vwAplicacoes.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwInvestimentos.aspx");
        }
    }
}