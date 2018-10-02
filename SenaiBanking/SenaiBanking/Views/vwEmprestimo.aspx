<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEmprestimo.aspx.cs" Inherits="SenaiBanking.Views.vwEmprestimo" %>

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
        <div class="container">
            <br />
            
            <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
                <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
                <asp:TextBox ID="txtNumeroConta" runat="server" class="form-control" Width="4%"></asp:TextBox>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
            <br />
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xl-12">
                <asp:Button ID="btnSolicitar" runat="server" Text="Solicitar Emprestimo" CssClass="btn btn-secondary" OnClick="btnSolicitar_Click"/><br /><br />
                <asp:Button ID="btnListar" runat="server" Text="Listar Emprestimos" CssClass="btn btn-secondary" OnClick="btnListar_Click"/>
            </div>
        </div>
        
    </form>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
