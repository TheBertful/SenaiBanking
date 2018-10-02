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
    public partial class vwSolicitarEmprestimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Limite preestabelecido de 900 reais
            lblLimite.Text = "Você possui R$ 900,00 de limite para o empréstimo.";
            
            if (!IsPostBack)
            {
                txtValor.Text = "0";
                lblAviso.Text = "O empréstimo tem juros de 5% ao mês.";
            }
            //Se não estiver logado, retorna para tela de login
            if ((Session["ContaCorrente"] as ContaCorrente) == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }
        }

        //Atualiza a tabela de parcelas previstas para o emprestimo
        public List<Parcela> PopulateGrid()
        {
            int parcelas = Convert.ToInt32(ddlQuantidadeParcelas.SelectedValue);
            double valor = Convert.ToDouble(txtValor.Text);
            List<Parcela> resultado = new List<Parcela>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Parcela", Type.GetType("System.String"));
            dt.Columns.Add("Valor", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));

            //Se valor for 0, não gera tabela
            if (valor != 0)
            {
                for (var i = 0; i < parcelas; i++)
                {
                    valor = valor + (valor * 0.05);
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

        //Quando valor e alterado, faz o calculo para verifica a previsão de parcelas
        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
            double numero = 0;

            //Verifica se é numero, senão o else seta valor padrão de 0 no campo valor
            if (double.TryParse(txtValor.Text, out numero))
            {
                //Se o valor inserido, foi maior que 900 que é o limite, ele seta o valor maximo no campo de 900 pra fazer a previsão das parcelas
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

        //Chama a operação para tentar recalcular a previsão de parcelas sempre que e alterado a quantidade de parcelas
        protected void ddlQuantidadeParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        //Quando clicar em concluir, o emprestimo sera criado e armazenado na Session emprestimos
        protected void btnConcluir_Click(object sender, EventArgs e)
        {

            int quantasParcelas = Convert.ToInt32(ddlQuantidadeParcelas.SelectedValue);
            double valor = Convert.ToDouble(txtValor.Text);
            List<Parcela> parcelas = new List<Parcela>();
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            conta.Saldo = conta.Saldo + Convert.ToDouble(txtValor.Text);
            lblAviso.Text = "O empréstimo tem juros de 5% ao mês.";

            //Criação do objeto emprestimo
            Emprestimo emp = new Emprestimo();
            emp.Id = conta.ListarEmprestimos() != null ? conta.ListarEmprestimos().Count() + 1 : 1;
            emp.Valor = Convert.ToDouble(txtValor.Text);
                //Usa a conta que esta na Session logada para o emprestimo
                emp.Conta = conta;
                emp.Data = DateTime.Now;
                emp.Descricao = txtDescricao.Text;
                emp.Tipo = ddlTipoEmprestimo.SelectedValue;
                emp.FormaPagamento = ddlFormaPagamento.SelectedValue;
                emp.Parcelas = new List<Parcela>();
                emp.Limite = 900;
                emp.NumParcelas = 0;
                emp.TaxaJuros = 5;
                emp.ContaContabil = Session["Emprestimos"] as ContaContabilEmprestimo;

            if (valor != 0)
            {
                //Calcula o juros sobre juros
                for (var i = 0; i < quantasParcelas; i++)
                {
                    valor = valor + (valor * 0.05);
                }

                //Define o valor de cada parcela para uso
                var parcela = valor / quantasParcelas;

                DateTime dataAtual = DateTime.Now;
                for (var i = 0; i < quantasParcelas; i++)
                {
                    Parcela p = new Parcela();
                    p.Valor = Math.Round(parcela, 2);
                    p.Status = "Pendente";
                    p.Vencimento = dataAtual.AddMonths(i + 1);
                    p.Numero = String.Concat((i + 1).ToString(), " / ", quantasParcelas.ToString());
                    emp.Parcelas.Add(p);
                }
                emp.NumParcelas = emp.Parcelas.Count();

                //Adiciona o emprestimo novo a lista de emprestimos e devolve as informações atualizadas a Session respectiva
                Session["ContaCorrente"] = conta;
                lblAviso.Text = "Emprestimo realizado com sucesso! Seu novo saldo é de: R$ " + conta.Saldo.ToString();
                conta.SolicitarEmprestimo(emp);

                //Deixa apenas o campo voltar e o texto informando que o emprestimo foi realizado
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
            }
            else
            {
                lblAviso.Text = "Não é possível fazer emprestimo sem valor!";
            }
        }


        //Volta para pagina principal
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwPrincipal.aspx");
        }
    }
}