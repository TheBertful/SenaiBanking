<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwSolicitarEmprestimo.aspx.cs" Inherits="SenaiBanking.Views.vwSolicitarEmprestimo" %>

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
                        <a href="vwListarEmprestimo.aspx">Listar empréstimos</a>
                        <a href="vwSolicitarEmprestimos.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div class="container">

        <h1 class="h1">Solicitar Emprestimo</h1>
        <form id="form1" runat="server">
            <br />
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblAviso" runat="server" CssClass="alert-primary form-control col-6"></asp:Label><br />
                <asp:Label ID="lblLimite" runat="server" CssClass="alert-primary form-control col-6"></asp:Label>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblTipoEmprestimo" runat="server" Text="Tipo de emprestimo"></asp:Label><br />
                <asp:DropDownList ID="ddlTipoEmprestimo" runat="server" CssClass="form-control col-4" AutoPostBack="True" OnSelectedIndexChanged="ddlQuantidadeParcelas_SelectedIndexChanged">
                    <asp:ListItem>Pessoal</asp:ListItem>
                    <asp:ListItem Enabled="false">Imobiliario</asp:ListItem>
                    <asp:ListItem Enabled="false">Automotivo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblValor" runat="server" Text="Valor"></asp:Label><br />
                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control col-4" AutoPostBack="True" OnTextChanged="txtValor_TextChanged"></asp:TextBox>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblQuantidadeParcelas" runat="server" Text="Quantidade de parcelas"></asp:Label><br />
                <asp:DropDownList ID="ddlQuantidadeParcelas" runat="server" CssClass="form-control col-4" AutoPostBack="True" OnSelectedIndexChanged="ddlQuantidadeParcelas_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label><br />
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control col-6" AutoPostBack="True" OnTextChanged="txtValor_TextChanged"></asp:TextBox>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblFormaPagamento" runat="server" Text="Forma de pagamento"></asp:Label><br />
                <asp:DropDownList ID="ddlFormaPagamento" runat="server" CssClass="form-control col-4" AutoPostBack="True" OnSelectedIndexChanged="ddlQuantidadeParcelas_SelectedIndexChanged">
                    <asp:ListItem>Debito em conta</asp:ListItem>
                    <asp:ListItem>Boleto</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:GridView ID="gdvParcelas" runat="server" CssClass="table-light text-center col-6"></asp:GridView>
            </div>
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Button CssClass="btn btn-secondary" ID="btnConcluir" runat="server" Text="Concluir" OnClick="btnConcluir_Click" />
            </div>
            <br />
            <div>
            </div>
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </form>
        <div class="footer"></div>
        <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
