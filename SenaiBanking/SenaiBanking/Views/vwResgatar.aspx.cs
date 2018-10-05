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
            else
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                lblMsg.Visible = false;
                txtMsgError.Visible = false;
                txtDescricao.Visible = false;
                lblDescricao.Visible = false;
                txtRendimento.Visible = false;
                lblRendimento.Visible = false;
                txtValorTotal.Visible = false;
                lblValorTotal.Visible = false;

                btnSimular.Visible = false;
                btnConfirmar.Visible = false;


                PopulateGridListarInvestimento();
            }

        }

        public void PopulateGridListarInvestimento() //Popula a grid com a lista de investimentos
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

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            //  context.Response.Write("session_timeout;" + redirectLocation);
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

        protected void btnConfirmar_Click(object sender, EventArgs e)  //Confirmar resgate do investimento
        {
            Investimento investimento = Session["investimento"] as Investimento;
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

            // conta.ResgatarInvestimento(investimento);
            try
            {
                String texto = txtValorTotal.Text;     //txtValorAplicar.Text recebe como parâmetro o valor digitado pelo usuário e convertemos
                texto = texto.Replace('.', ',');         // de .(ponto) para ,(vírgula), caso o mesmo digite (ponto) para tratativa no saldo
                double valor = Convert.ToDouble(texto);
                if (investimento.Descricao == "Poupança")  //Confirmação para poupança
                {
                    investimento.TipoInvestimento = txtDescricao.Text;

                    investimento.Valor = valor;

                }
                else if (investimento.Descricao == "CDB")  //Confirmação para CDB
                {
                    investimento.TipoInvestimento = txtDescricao.Text;

                    investimento.Valor = valor;

                }
                else if (investimento.Descricao == "Tesouro")  //Confirmação para Tesouro
                {
                    investimento.TipoInvestimento = txtDescricao.Text;

                    investimento.Valor = valor;

                }

                conta.ResgatarInvestimento(investimento);

                lblMsg.Visible = true;
                lblMsg.Text = "Valor Resgatado -(menos) Impostos: R$ " + investimento.Valor;

                PopulateGridListarInvestimento();

            }

            catch (Exception)
            {
                txtMsgError.Visible = true;
                txtMsgError.Text = "Não foi possível realizar sua aplicação, verifique o campo Valor";
            }
        }


        protected void gdvResgatarInvestimento_RowCommand(object sender, GridViewCommandEventArgs e) //operação "Selecionar" da Grid
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            Investimento investimento = conta.ListarInvestimentosNaoResgatados()[Convert.ToInt32(e.CommandArgument)];

            Session["investimento"] = investimento;

            txtDescricao.Visible = true;
            lblDescricao.Visible = true;
            txtRendimento.Visible = true;
            lblRendimento.Visible = true;
            txtValorTotal.Visible = true;
            lblValorTotal.Visible = true;

            btnSimular.Visible = true;
            btnConfirmar.Visible = false;

            txtDescricao.Text = investimento.Descricao;
            txtRendimento.Text = Convert.ToString(investimento.Rendimento);
            txtValorTotal.Text = Convert.ToString(investimento.Valor);

        }

        protected void btnSimularRendimento_Click(object sender, EventArgs e)  //Operação Simular Rendimento
        {
            //Carrego a sessão de investimento
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            // InvestimentoPoupanca investimentoPoupanca = Session["InvestimentoPoupanca"] as InvestimentoPoupanca;

            Investimento investimento = Session["investimento"] as Investimento;

            // chamo o método render para cálculo

            txtDescricao.Visible = true;
            lblDescricao.Visible = true;
            txtRendimento.Visible = true;
            lblRendimento.Visible = true;
            txtValorTotal.Visible = true;
            lblValorTotal.Visible = true;
            btnSimular.Visible = true;
            btnConfirmar.Visible = true;

            String texto = txtValorTotal.Text;     //txtValorAplicar.Text recebe como parâmetro o valor digitado pelo usuário e convertemos
            texto = texto.Replace('.', ',');         // de .(ponto) para ,(vírgula), caso o mesmo digite (ponto) para tratativa no saldo
            double valor = Convert.ToDouble(texto);

            if (investimento.Descricao == "Poupança")  //Silumação para poupança
            {

                double aumento = Math.Round(valor * ((5.15 / 12) / 100), 2); // divide no mês

                txtDescricao.Text = investimento.Descricao;
                txtRendimento.Text = Convert.ToString(investimento.Rendimento);
                txtValorTotal.Text = Convert.ToString(aumento + valor);
            }
            else if (investimento.Descricao == "CDB") //Simulação para CDB
            {

                txtDescricao.Text = investimento.Descricao;
                txtRendimento.Text = Convert.ToString(investimento.Rendimento);

                String textoCDB = txtRendimento.Text;
                textoCDB = textoCDB.Replace('.', ',');
                double valorCDB = Math.Round(Convert.ToDouble(textoCDB), 2);

                txtValorTotal.Text = Convert.ToString(valor + valorCDB);
            }
            else if (investimento.Descricao == "Tesouro") //Simulação para Tesouro

            {
                txtDescricao.Text = investimento.Descricao;
                txtRendimento.Text = Convert.ToString(investimento.Rendimento);

                String textoTesouro = txtRendimento.Text;
                textoTesouro = textoTesouro.Replace('.', ',');
                double valorTesouro = Math.Round(Convert.ToDouble(textoTesouro), 2);

                txtValorTotal.Text = Convert.ToString(valor + valorTesouro);
            }

            gdvResgatarInvestimento.Visible = false;
            btnSimular.Visible = false;

        }
    }
}
