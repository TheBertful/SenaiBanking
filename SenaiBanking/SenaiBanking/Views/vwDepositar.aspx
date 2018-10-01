<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwDepositar.aspx.cs" Inherits="SenaiBanking.Views.Depositar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Sacar.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
                    <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
                </div>
        <div class="container">
             <div>
                <asp:TextBox class="alert alert-primary col-lg-12 col-md-12 col-sm-12 col-xl-12" ClientIDMode="AutoID" ID="txtMsg" runat="server" role="alert"></asp:TextBox>
                <asp:TextBox class="alert alert-danger col-lg-12 col-md-12 col-sm-12 col-xl-12" ClientIDMode="AutoID" ID="txtMsgError" runat="server" role="alert"></asp:TextBox>
             </div>
             <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                <div class="ajuste col-lg-12 col-md-6 col-sm-12 col-xl-12">
                    <asp:Label ID="lblDeposito" runat="server" Text="Valor "></asp:Label>
                    <asp:TextBox ID="txtDeposito" runat="server" class="form-control" Width="20%"></asp:TextBox>
                </div>
                <div class="ajuste col-lg-3 col-md-3 col-sm-3 col-xs-12">
                    <asp:Button class="btn btn-secondary" ID="btnDepositar" runat="server" Text="Depositar" OnClick="btnDepositar_Click" />
                    <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
