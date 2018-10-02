<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwTiposInvestimento.aspx.cs" Inherits="SenaiBanking.Views.TiposInvestimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Principal.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
            <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
            <asp:TextBox ID="txtNumeroConta" runat="server" class="form-control" Width="4%"></asp:TextBox>
        </div>
        <br />
        <br />
        <div id="sub-menu">
            <h3>Tipos de Investimento</h3>
        </div>
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
                <div class=" col-lg-6 col-md-6 col-sm-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                </div>
            </div>
        </div>
        </div>
    </form>
    </div>
</body>
</html>
