<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwInvestimentos.aspx.cs" Inherits="SenaiBanking.Views.Investimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Principal.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <br />
    <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
        <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
        <!--<asp:TextBox class="form-control" ID="txtNumeroConta" runat="server" Width="4%"></asp:TextBox>-->
    </div>
    <br />
    <br />
    <div id="sub-menu">
        <h3>Investimento</h3>
    </div>

    <form id="form1" runat="server">
        <div class="container">
            <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnMeusInvestimentos" runat="server" Text="Meus investimentos" OnClick="btnMeusInvestimentos_Click" />
                </div>
                <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnAplicacao" runat="server" Text="Aplicação" OnClick="btnAplicacao_Click" />
                </div>
                <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">

                    <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnResgate" runat="server" Text="Resgate" OnClick="btnResgate_Click" />
                    <br />
                    <div class="ajuste col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                    </div>
                </div>
                <div>
                    <asp:Label ID="lblAviso" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
