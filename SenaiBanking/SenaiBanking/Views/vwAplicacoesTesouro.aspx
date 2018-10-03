<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwAplicacoesTesouro.aspx.cs" Inherits="SenaiBanking.Views.vwAplicacoesTesouro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Aplicação</title>
</head>
<body>
    <div class="container">
        <h1 class="h1">Aplicações</h1>
        <br />
        <form id="form1" runat="server">
            <div class="row col-lg-12 col-sm-12">
                <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
                    <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
                    <asp:TextBox ID="txtNumeroConta" runat="server" class="form-control" Width="4%"></asp:TextBox>
                </div>
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
                        <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                        <asp:Button class="btn btn-secondary" ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                    </div>
                    <br />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
