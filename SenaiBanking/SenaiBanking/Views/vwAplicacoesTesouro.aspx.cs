using SenaiBanking.Models;
using System;

namespace SenaiBanking.Views
{
    public partial class vwAplicacoesTesouro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //É carregado as sessões das Classes ContaCorrente, Investimentos e Banco
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            ContaContabilInvestimento containvestimento = Session["Investimentos"] as ContaContabilInvestimento;
            Banco banco = Session["Banco"] as Banco;

            //Se conta for diferente de nula, lista as informações nos devidos campos da View
            if (conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
                lblSaldoAtual.Text = Convert.ToString("R$ " + conta.Saldo);
                lblMsg.Visible = false;
                txtMsgError.Visible = false;
                lblData.Text = Convert.ToString(DateTime.Now);
            }

            //Se nula, redireciona para a página principal
            else
            {
                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)  //Botão "Confirmar"
        {
            //para fazer o tratamento de exceções como, valores negativos, string... utilizamos o try, catch
            try
            {
                String texto = txtValorAplicar.Text;     //txtValorAplicar.Text recebe como parâmetro o valor digitado pelo usuário e convertemos
                texto = texto.Replace('.', ',');         // de .(ponto) para ,(vírgula), caso o mesmo digite (ponto) para tratativa no saldo
                double valor = Convert.ToDouble(texto);  //em seguida convertemos a variável "texto" em double e armazenamos na variável "valor"
                ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente; //É carregado a sessão da classe ContaCorrente

                //caso o valor informado pelo usuário seja maior que o saldo em conta, é carregado o alert txtMsgError.Text
                if (Math.Round(Convert.ToDouble(texto), 2) > (conta.Saldo))
                {
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "Atenção!! Valor maior que o saldo da conta";
                }

                //caso o valor informado pelo usuário seja maior que 0 (zero), instanciamos o objeto
                //É feita a atribuição do valor informado pelo usuário, Data do sistema, tipo do investimento e descrição
                else if (Math.Round(Convert.ToDouble(texto), 2) > 0)
                {
                    InvestimentoTesouroDireto investimentoTesouro = new InvestimentoTesouroDireto()
                    {
                        ValorInicial = Convert.ToDouble(texto),
                        Data = DateTime.Now,
                        Tipo = "Investimento",
                        Descricao = "Tesouro"
                    };

                    //É invocado o método "AplicarInvestimento" passando como parâmetro o objeto acima "investimentoPoupanca",
                    conta.AplicarInvestimento(investimentoTesouro);

                    //após investimento é feito a atualização do saldo na conta do usuário e informado o valor investido 
                    lblSaldoAtual.Text = Convert.ToString(conta.Saldo);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Valor investido: R$ " + texto;
                }

                //Senão, é carregado o alert txtMsgError.Text
                else
                {
                    txtMsgError.Visible = true;
                    txtMsgError.Text = "O valor deve ser superior a zero(0.00)";
                }
            }

            //Pego as excessões(caso tenha) valores negativos, string... e retorno o alert
            catch (Exception)
            {
                txtMsgError.Visible = true;
                txtMsgError.Text = "Não foi possível realizar sua aplicação, verifique o campo Valor";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)  //Botão Voltar
                                                                    //redireciona para a página de tipos de investimentos
        {
            Response.Redirect("~/Views/vwTiposInvestimento.aspx");
        }

        protected void txtValorAplicar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
