<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwListarInvestimentos.aspx.cs" Inherits="SenaiBanking.Views.vwListarInvestimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="head">
        <div class="exibirConta">
            <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
            <asp:Label ID="txtNumeroConta" runat="server" class="form-control tamanhoConta"></asp:Label>
        </div>
        <div class="logo"></div>
        <div class="menu">
            <ul>
                <li><a href="vwPrincipal.aspx">Inicio</a></li>
                <li class="dropdown">
                    <a href="Conta" class="dropbtn">Conta Corrente</a>
                    <div class="dropdown-content">
                        <a href="vwDepositar.aspx">Depósito</a>
                        <a href="vwExtrato.aspx">Extrato</a>
                        <a href="vwSaldo.aspx">Saldo</a>
                        <a href="vwSacar.aspx">Saque</a>
                        <a href="vwTransferir.aspx">Transferência</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwInvestimentos.aspx" class="dropbtn">Investimento</a>
                    <div class="dropdown-content">
                        <a href="vwAplicacoes.aspx">Aplicação</a>
                        <a href="#">Meus investimentos</a>
                        <a href="#">Resgate</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwEmprestimo.aspx" class="dropbtn">Empréstimo</a>
                    <div class="dropdown-content">
                        <a href="vwListarEmprestimos.aspx">Listar Empréstimos</a>
                        <a href="vwSolicitarEmprestimo.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
   <form id="form1" runat="server">
        <h1 class="h1">Lista de Investimento(s)</h1>
        <div class="container">
            <br />  
            <asp:GridView ID="gdvListarInvestimentos" CssClass="table-light text-center col-6" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvListarInvestimentos_SelectedIndexChanged">
                <Columns>

                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="DataSolicitacao" HeaderText="Data Solicitação" />
                    <asp:BoundField DataField="Rendimento" HeaderText="Rendimento" />
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" />
                    <asp:BoundField DataField="Valortotal" HeaderText="Valor Total" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="col-lg-12 col-sm-12 col-md-12">
            <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
      </div>
    </form>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
