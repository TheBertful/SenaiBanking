<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwAplicacoesCDB.aspx.cs" Inherits="SenaiBanking.Views.vwAplicacoesCDB" %>

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
                    <a href="" class="dropbtn">Conta Corrente</a>
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
                        <a href="vwAplicacoes.aspx">Apliacação</a>
                        <a href="#">Meus investimentos</a>
                        <a href="#">Resgate</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwEmprestimo.aspx" class="dropbtn">Empréstimo</a>
                    <div class="dropdown-content">
                        <a href="vwListarEmprestimos.aspx">Listar empréstimos</a>
                        <a href="vwSolicitarEmprestimo.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <form id="form1" runat="server">
        <h1 class="h1">Aplicações / CDB</h1>
        <div class="container">
            <br />
            <div class="ajuste col-lg-12 col-sm-12">
                <asp:Label ID="lblValorDisponivel" runat="server" Text="Valor disponível para aplicação"></asp:Label>
                <br />
                <asp:Label ID="lblSaldoAtual" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblValorAplicar" runat="server" Text="Digite o Valor"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorAplicar" runat="server" class="form-control" Width="40%" OnTextChanged="txtValorAplicar_TextChanged"></asp:TextBox>
                <br />
                <asp:Label ID="lblMsg" runat="server" CssClass="alert alert-primary col-lg-12 col-md-12 col-sm-12 col-xl-12"></asp:Label>
                <br />
                <asp:TextBox class="alert alert-danger col-lg-12 col-md-12 col-sm-12 col-xl-12" ClientIDMode="AutoID" ID="txtMsgError" runat="server" role="alert"></asp:TextBox>
                <br />
                <asp:Label ID="lblDataAplicacao" runat="server" Text="Data da Aplicação"></asp:Label>
                <br />
                <asp:Label ID="lblData" runat="server"></asp:Label>
                <br />
                <div>
                    <asp:Label ID="lblAviso" runat="server"></asp:Label>
                </div>
                <div class="ajuste">
                    <br />
                    <asp:Button class="btn btn-secondary" ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                </div>
                <br />
            </div>
        </div>
        <div class="col-lg-12 col-sm-12 col-md-12">
            <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
    </div>
</body>
</html>
