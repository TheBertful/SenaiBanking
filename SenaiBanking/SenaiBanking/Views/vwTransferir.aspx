<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwTransferir.aspx.cs" Inherits="SenaiBanking.Views.Transferir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Sacar.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                        <a href="vwSolicitarEmprestimos.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="exibirConta">
            <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
            <asp:Label ID="txtNumeroConta" runat="server" class="form-control tamanhoConta"></asp:Label>
        </div>
        <div class="container">
             <div>
               <asp:Label ID="lblMsg" runat="server"  CssClass="alert alert-primary col-lg-12 col-md-12 col-sm-12 col-xl-12"></asp:Label><br />
               <asp:Label ID="lblMsgError" runat="server"  CssClass="alert alert-danger col-lg-12 col-md-12 col-sm-12 col-xl-12"></asp:Label><br /> 
             </div>
             <div class="row col-lg-12 col-sm-12">
                    <div class="ajuste col-lg-12 col-sm-12">
                        <asp:Label ID="lblConta" runat="server" Text="Conta"></asp:Label>
                        <asp:TextBox ID="txtConta" runat="server" class="form-control" Width="15%"></asp:TextBox>
                    </div>
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12">
                        <asp:Label ID="lblValor" runat="server" Text="Valor"></asp:Label>
                        <asp:TextBox ID="txtValor" runat="server" class="form-control" Width="15%"></asp:TextBox>
                    </div>
                   <div class="ajuste col-lg-3 col-md-3 col-sm-3 col-xs-12">
                    <asp:Button class="btn btn-secondary" ID="btnTransferir" runat="server" Text="Transferir" OnClick="btnTransferir_Click"/>
                    <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
                </div>
                    <div>
                        <asp:Label ID="lblAviso" runat="server"></asp:Label>
                    </div>
                 </div>
        </div>
    </form>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
