using SenaiBanking.Models;
using System;

namespace SenaiBanking.Views
{
    public partial class Aplicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            ContaContabilInvestimento containvestimento = Session["Investimentos"] as ContaContabilInvestimento;
            Banco banco = Session["Banco"] as Banco;

            if (conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                lblSaldoAtual.Text = Convert.ToString(conta.Saldo);
                txtMsgError.Visible = false;
                lblData.Text = Convert.ToString(DateTime.Now);
            }
            else
            {
                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        { try
            {     
                String texto = txtValorAplicar.Text;
                texto = texto.Replace('.', ',');
                double valor = Convert.ToDouble(texto);
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;

                if (Math.Round(Convert.ToDouble(texto), 2) > (conta.Saldo))
                {
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "Atenção!! Valor maior que o saldo da conta";
                }
                else if (Math.Round(Convert.ToDouble(texto), 2) > 0)
                {
                    InvestimentoPoupanca investimentoPoupanca = new InvestimentoPoupanca();

                    investimentoPoupanca.ValorInicial = (Math.Round(Convert.ToDouble(texto),2));
                    investimentoPoupanca.Data = DateTime.Now;

                    conta.AplicarInvestimento(investimentoPoupanca);

                    lblSaldoAtual.Text = Convert.ToString(conta.Saldo);
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "Valor investido: R$ "+ texto;
                }
                else
                {
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "O valor deve ser superior a zero(0.00)";
                }
            }catch
            {

            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwTiposInvestimento.aspx");
        }

        protected void txtValorAplicar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}