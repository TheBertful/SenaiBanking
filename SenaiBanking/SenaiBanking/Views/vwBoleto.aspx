<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwBoleto.aspx.cs" Inherits="SenaiBanking.Views.vwBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style>
        .botoes
        {
            margin-top:15px;
        }
        @media only screen and (max-width: 770px) 
        {
            .separador 
            {
                margin-top: 15px;
            }
        }
        .msg
        {
            margin-top:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-12">
                <img src="../Content/img/boleto.png"/ class="img-fluid" />
            </div>
            <div class="col-md-12 text-center msg">
                <asp:Label ID="lblMsg" runat="server"  CssClass="alert alert-primary col-md-12"></asp:Label><br />
                <asp:Label ID="lblMsgError" runat="server"  CssClass="alert alert-danger col-md-12"></asp:Label><br /> 
            </div>
            <div class="col-md-12 text-center botoes">
                <asp:Button ID="btnVoltar" CssClass="btn btn-secondary col-md-4 separador" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                <asp:Button ID="btnDeclarar" CssClass="btn btn-success col-md-4 separador" runat="server" Text="Pago" OnClick="btnDeclarar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
