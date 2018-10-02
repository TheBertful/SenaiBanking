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
            //Verifica se tem conta logada e aparece no canto da tela qual, senao vai pra tela de login
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;
            if (conta != null)
            {
                txtNumeroConta.Text = conta.Numero.ToString();
            }
            else
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }

            //Chama a função que vai alimentar a tabela com os emprestimos pendentes
            PopulateGridEmprestimos();
        }

        //Busca os emprestimos que estiverem pendentes e exibe na tabela de emprestimos, se não houver nenhum, a tabela não aparece.
        public void PopulateGridEmprestimos()
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente; //Chama conta para trabalhar com as funções dela
            DataTable dt = new DataTable(); //Cria o DataTable para configurá-lo com as informações recebidas da conta e servir de base de dados para a gridview
            List<Emprestimo> lista = conta.ListarEmprestimosPendentes();//Cria lista dos emprestimos que sera exibida e recebe apenas os que ainda nao foram quitados


            //Cria as colunas do DataTable que serão usadas de referencia na gridview
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Tipo", Type.GetType("System.String"));
            dt.Columns.Add("Descricao", Type.GetType("System.String"));
            dt.Columns.Add("FormaPagamento", Type.GetType("System.String"));
            dt.Columns.Add("Data", Type.GetType("System.String"));
            dt.Columns.Add("Parcelas", Type.GetType("System.String"));
            
            if (lista != null)//Verifica se a lista possui itens para evitar erros
            {
                lista.ForEach(item =>//percorre a lista de emprestimos criando uma linha pra cada e recebendo os respectivos valores nas respectivas colunas do DataTable
                {
                    DataRow dr = dt.NewRow();//Cria uma liha de DataTable
                    dr["Id"] = item.Id;
                    dr["Tipo"] = item.Tipo;
                    dr["Descricao"] = item.Descricao;
                    dr["FormaPagamento"] = item.FormaPagamento;
                    dr["Data"] = item.Data.ToShortDateString();
                    dr["Parcelas"] = item.Parcelas.Count().ToString();
                    dt.Rows.Add(dr);//Adiciona a linha configurada a DataTable
                });
            }
            gdvEmprestimos.DataSource = dt;//GridView recebe os valore configurados no DataTable como fonte de dados
            gdvEmprestimos.DataBind();//Recarrega a GridView
        }

        //Chama a função PopulateGridParcelas que tras as parcelas corretas passando como parmetro o Id do emprestimo 
        //recebido de argumento da gridView no botão "visualizar"
        protected void gdvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            PopulateGridParcelas(id);
        }

        //Quando o usuario clica em visualizar em um dos emprestimos exibido a GridView, e enviado por CommandArgument o id 
        //do emprestimo clicado que será utilizado para exibir as parcelas dele em uma Gridview apropriada
        public void PopulateGridParcelas(int id)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;//Chama conta para trabalhar com ela nas funções
            List<Emprestimo> lista = conta.ListarEmprestimosPendentes(); //Recebe emprestimos pendentes para selecionar de qual pertence a parcela
            Emprestimo emprestimo = null;//Instância um emprestimo para receber o selecionado e assim podermos trabalhar com ele
            DataTable dt = new DataTable();//Cria um DataTable que sera usado como fonte de dados das parcelas

            lista.ForEach(i => { if (i.Id == id) { emprestimo = i; } });//Roda a lista de emprestimo pra descobrir qual foi o selecionado e armazena ele na instância de emprestimo

            //Configura as colunas do DataTable que sera usado na gridview de parcelas
            dt.Columns.Add("Numero", Type.GetType("System.String"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            dt.Columns.Add("Vencimento", Type.GetType("System.String"));
            dt.Columns.Add("Valor", Type.GetType("System.String"));

            if (emprestimo != null)//Verifica se emprestimo foi recebido para evitar erro
            {
                emprestimo.Parcelas.ForEach(item =>//Adicionar dados respectivos das parcelas as colunas respectivas do datatable
                {
                    if (item.Status == "Pendente")
                    {
                        DataRow dr = dt.NewRow();
                        dr["Numero"] = item.Numero.ToString();
                        dr["Status"] = item.Status;
                        dr["Vencimento"] = item.Vencimento.ToShortDateString();
                        dr["Valor"] = converteParaMoeda(item.Valor);
                        dt.Rows.Add(dr);
                    }
                });
    
                if (emprestimo.FormaPagamento.Equals("Boleto"))//Se emprestimo for pagamento por boleto, os dados do datatabel
                    //são inseridos na gridview apropriada pra parcelas de boleto onde o botão exibido e o de "Gerar Boleto" 
                    //também e limpa a gridview de pagamentos por debito em conta para que não sejam exibidas duas gridview caso
                    //já tenha selecionada uma antes
                {
                    gdvParcelasDebitoEmConta.DataSource = null;
                    gdvParcelasBoleto.DataSource = dt;
                    gdvParcelasBoleto.DataBind();
                    gdvParcelasDebitoEmConta.DataBind();
                    PopulateGridEmprestimos();
                }
                else //Se for do tipo pagamento debitando da conta, fáz o inverso do escrito acima com as gridviews
                {
                    gdvParcelasBoleto.DataSource = null;
                    gdvParcelasDebitoEmConta.DataSource = dt;
                    gdvParcelasDebitoEmConta.DataBind();
                    gdvParcelasBoleto.DataBind();
                    PopulateGridEmprestimos();
                }

            }
            //Armazena o emprestimo selecionado em uma Session, pois na hora de selecionar a parcela dele para paga, vai precisa de sua referência
            Session["emprestimo"] = emprestimo;
        }

        //Volta para página anterior
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwEmprestimo.aspx");
        }

        //Quando uruario clica em Gerar Boleto na tabela de Parcelas do emprestimo que o pagamento é do tipo boleto, afunção
        //pega o numero da parcela que vai ser paga por argumento que vem do botão da gridview busca a parcela correta para armazenar 
        //em uma session e direcionar a página do boleto para efetuar o pagamento da parcela
        protected void gdvParcelasBoleto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int numParcela = 0;
            string numero = e.CommandArgument.ToString();//Recebe o numero da parcela
            Emprestimo emp = Session["emprestimo"] as Emprestimo;//Recebe o emprestimo que foi selecionado e armazenado na Session na função gdvEmprestimos_RowCommand
            Parcela p = new Parcela();//Instancia uma parcela que vai ser armazenada em uma Session para o pagamento da mesma na tela do boleto

            numParcela = numero.Length > 4 ? Convert.ToInt32(numero.Substring(0, 2)) : Convert.ToInt32(numero.Substring(0, 1)); //Verifica se o numero da parcela tem uma ou 
            //duas casas para extrair o valor correto do numero pois o mesmo vem no fomarto de strign ex: "3/10" (terceira de dez)


            
            int count = 1;//Utilizado no ForEach para apontar para a parcela correta que foi recebida com argumento 
            emp.Parcelas.ForEach(i => { if (count == numParcela) p = i;  count++; });//Quando acha a parcela correta, armazena na instância de parcela

            Session["parcela"] = p;//Manda a parcela para um Session para a tela de boleto utilizar
            //if (!emp.Pendente) //Verifica se o emprestimo foi quitado, se nao tiver parcela pendente, ele some da gridview do boleto
            //{
            //    gdvParcelasBoleto.DataSource = null;
            //    gdvParcelasBoleto.DataBind();
            //}
            Response.Redirect("~/Views/vwBoleto.aspx");//Redireciona para a tela do Boleto
        }

        //Quando o usuario clica em pagar em uma parcela de emprestimo que e do tipo de pagamento por debito em conta corrente
        //Será efetuado o pagamento da parcela e atualizado a gridview respectiva
        protected void gdvParcelasDebitoEmConta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContaCorrente conta = Session["ContaCorrente"] as ContaCorrente;//Chama conta para usar as funções dela pra trabalhar
            Emprestimo emp = Session["emprestimo"] as Emprestimo; //Chama o emprestimo selecionado quando clicou no botão visualizar na função gdvEmprestimos_RowCommand
            Parcela p = new Parcela(); //Instancia uma parcela que será utilizada para receber a parcela que sera paga
            int numParcela = 0;//irá receber o numero da parcela filtrado a ser paga recebida como parametro da gridview no botão de pagar parcela antecipada
            string numero = e.CommandArgument.ToString(); //Recebe o numero da parcela como argumento da gridview sem filtro ex: 3/15 (terceira de quinze parcelas)

            lblAviso.Text = "";//Limpa o aviso caso tenha aviso como saldo insuficiente de outra parcela de outro emprestimo

            if (conta.Saldo >= emp.Parcelas[0].Valor) //verifica se o saldo da conta e maior que o valor da parcela para pagar
            {
                numParcela = numero.Length > 4 ? Convert.ToInt32(numero.Substring(0, 2)) : Convert.ToInt32(numero.Substring(0, 1));//Filtra o numero da parcela

                int count = 1;
                emp.Parcelas.ForEach(item => { if (count == numParcela) p = item; count++; });//Busca a parcela do emprestimo a qual o numero se refere e armazena na instância de parcela

                //Session["parcela"] = p;

                emp.PagarParcela(p);//Usa o metodo do emprestimo no caso para pagar a parcela

                Session["ContaCorrente"] = conta;//Devolve a conta a Session atualizada

                PopulateGridParcelas(emp.Id);//Atualiza a grid de Parcelas nesse caso passa o id do emprestimo de parametro
                if (!emp.Pendente)//Verifica se o emprestimo ainda tem parcelas pendentes, se não tiver mais sua gridview de parcela desaparcel
                {
                    gdvParcelasDebitoEmConta.DataSource = null;
                    gdvParcelasDebitoEmConta.DataBind();
                }
                PopulateGridEmprestimos();
            } else//Se não tem saldo na conta, informa o usuario de saldo insuficiente
            {
                lblAviso.Text = "Saldo insuficiente.";
            }
            
        }

        //Converte double pra sempre ter duas casa depois da virgula retornando a string do valor ex. (1 vira 1,00) ou (1,1 vira 1,10)
        public string converteParaMoeda(double valor)
        {
            String v = Math.Round(valor, 2).ToString();//Formata o valor em double com duas casas decimais no maximo
            int posicao = v.IndexOf(",");//Verifica onde esta a virgula que separa as casas decimais
            if(posicao < 0) //Se nao tiver virgula a posição vem -1, nesse caso adiciona ,00 ao final da string
            {
                v = v + ",00";
            }
            if (posicao > v.Length - 3)//se tiver virgula na antipenultima casa, adiciona apenas um zero no final pois ja tem uma casa depois da virgula
            {
                v = v + "0";
            }
            //Senão já esta no formato correto ai não precisa fazer nada so retornar a string
            return v;
        }
    }
}