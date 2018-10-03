<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwTiposInvestimento.aspx.cs" Inherits="SenaiBanking.Views.TiposInvestimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Principal.css" rel="stylesheet" />
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
                <h1 class="h1">Tipos de Investimento</h1>
        <div class="container">
            <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">

                <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnCdb" runat="server" Text="CDB" OnClick="btnCDB_Click" />
                </div>
                <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnTesouro" runat="server" Text="Tesouro" OnClick="btnTesouro_Click" />
                </div>
                <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnPoupanca" runat="server" Text="Poupança" OnClick="btnPoupanca_Click" />
                </div>
                <div>
                    <asp:Label ID="lblAviso" runat="server"></asp:Label>
                </div>
                 <div class="col-lg-12 col-sm-12 col-md-12">
            <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>     
            </div>
        </div>
    </form>
</body>
</html>
