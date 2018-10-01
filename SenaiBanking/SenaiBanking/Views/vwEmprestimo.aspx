<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEmprestimo.aspx.cs" Inherits="SenaiBanking.Views.vwEmprestimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
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
</body>
</html>
