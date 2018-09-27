﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saldo.aspx.cs" Inherits="SenaiBanking.Views.Saldo" %>

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
        <div class="container">
            <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                <div class="ajuste col-lg-12 col-md-6 col-sm-12 col-xl-12">
                    <asp:Label ID="lblSaldo" runat="server" Text="Saldo"></asp:Label>
                    <asp:TextBox ID="txtSaldo" runat="server" class="form-control" Width="20%"></asp:TextBox>
                </div>
                <div class="ajuste col-lg-3 col-md-3 col-sm-3 col-xs-12">
                    <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" />
                </div>
                <div>
                  <asp:Label ID="lblAviso" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
