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
    public partial class vwEmprestimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ContaCorrente"] as ContaCorrente) == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwSolicitarEmprestimo.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwListarEmprestimos.aspx");
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //Limite preestabelecido de 900 reais
        //    lblLimite.Text = "Você possui R$ 900,00 de limite para o empréstimo.";
        //    if (!IsPostBack)
        //    {
        //        txtValor.Text = "0";
        //    }
        //    //Se não estiver logado, retorna para tela de login
        //    if((Session["ContaCorrente"] as ContaCorrente) == null)
        //    {
        //        Response.Redirect("~/Views/vwLogin.aspx");
        //    }
        //}

        ////Atualiza a tabela de parcelas previstas para o emprestimo
        //public List<Parcela> PopulateGrid()
        //{
        //    int parcelas = Convert.ToInt32(ddlQuantidadeParcelas.SelectedValue);
        //    double valor = Convert.ToDouble(txtValor.Text);
        //    List<Parcela> resultado = new List<Parcela>();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Parcela", Type.GetType("System.String"));
        //    dt.Columns.Add("Valor", Type.GetType("System.String"));
        //    dt.Columns.Add("Vencimento", Type.GetType("System.String"));

        //    //Se valor for 0, não gera tabela
        //    if (valor != 0)
        //    {
        //        for (var i = 0; i < parcelas; i++)
        //        {
        //            valor = valor + (valor * 0.05);
        //        }
        //        var parcela = valor / parcelas;

        //        for (var i = 0; i < parcelas; i++)
        //        {
        //            DateTime dataAtual = DateTime.Now;

        //            Parcela p = new Parcela();
        //            p.Valor = Math.Round(parcela, 2);
        //            p.Status = "Pendente";
        //            p.Vencimento = dataAtual.AddMonths(i + 1);
        //            p.Numero = (i + 1).ToString() + " / " + parcelas.ToString();

        //            DataRow dr = dt.NewRow();
        //            dr["Parcela"] = p.Numero;
        //            dr["Valor"] = "R$ " + p.Valor.ToString();
        //            dr["Vencimento"] = p.Vencimento.ToShortDateString();
        //            dt.Rows.Add(dr);
        //            gdvParcelas.DataSource = dt;
        //        }
        //    }
        //    else
        //    {
        //        gdvParcelas.DataSource = null;
        //    }
        //    gdvParcelas.DataBind();
        //    return resultado;
        //}

        ////Quando valor e alterado, faz o calculo para verifica a previsão de parcelas
        //protected void txtValor_TextChanged(object sender, EventArgs e)
        //{
        //    double numero = 0;

        //    //Verifica se é numero, senão o else seta valor padrão de 0 no campo valor
        //    if (double.TryParse(txtValor.Text, out numero))
        //    {
        //        //Se o valor inserido, foi maior que 900 que é o limite, ele seta o valor maximo no campo de 900 pra fazer a previsão das parcelas
        //        if (numero > 900)
        //        {
        //            txtValor.Text = "900";
        //        }
        //    }
        //    else
        //    {
        //        txtValor.Text = "0";
        //    }
        //    PopulateGrid();
        //}

        ////Chama a operação para tentar recalcular a previsão de parcelas sempre que e alterado a quantidade de parcelas
        //protected void ddlQuantidadeParcelas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PopulateGrid();
        //}

        ////Quando clicar em concluir, o emprestimo sera criado e armazenado na Session emprestimos
        //protected void btnConcluir_Click(object sender, EventArgs e)
        //{

        //    //DateTime agora = DateTime.Now;
        //    //DateTime depois = DateTime.Now.AddSeconds(3);

        //    //while (agora < depois)
        //    //{
        //    //    agora = DateTime.Now;
        //    //}

        //    gdvParcelas.Visible = false;
        //    lblLimite.Visible = false;
        //    lblQuantidadeParcelas.Visible = false;
        //    lblValor.Visible = false;
        //    txtValor.Visible = false;
        //    btnConcluir.Visible = false;
        //    ddlQuantidadeParcelas.Visible = false;
        //    lblTipoEmprestimo.Visible = false;
        //    ddlTipoEmprestimo.Visible = false;
        //    lblDescricao.Visible = false;
        //    txtDescricao.Visible = false;
        //    lblFormaPagamento.Visible = false;
        //    ddlFormaPagamento.Visible = false;

        //    ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
        //    List<Emprestimo> emprestimos = Session["Emprestimos"] as List<Emprestimo>;


        //    conta.Saldo = conta.Saldo + Convert.ToDouble(txtValor.Text);

        //    //Criação do objeto emprestimo
        //    Emprestimo emp = new Emprestimo()
        //    {
        //        Valor = Convert.ToDouble(txtValor.Text),
        //        //Usa a conta que esta na Session logada para o emprestimo
        //        Conta = conta,
        //        Data = DateTime.Now,
        //        Descricao = txtDescricao.Text,
        //        Tipo = ddlTipoEmprestimo.SelectedValue,
        //        FormaPagamento = ddlFormaPagamento.SelectedValue,
        //        Parcelas = PopulateGrid()
        //    };

        //    //Adiciona o emprestimo novo a lista de emprestimos e devolve as informações atualizadas a Session respectiva
        //    emprestimos.Add(emp);
        //    Session["Emprestimos"] = emprestimos;
        //    Session["ContaCorrente"] = conta;
        //    lblAviso.Text = "Emprestimo realizado com sucesso! Seu novo saldo é de: R$ " + conta.Saldo.ToString();
        //}


        ////Volta para pagina principal
        //protected void btnVoltar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/vwPrincipal.aspx");
        //}
    }
}