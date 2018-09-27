<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SenaiBanking.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/Login.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row col-lg-12 col-sm-12">
                    <div class="ajuste col-lg-12 col-sm-12">
                        <asp:Label ID="lblCpf" runat="server" Text="CPF"></asp:Label>
                        <asp:TextBox ID="txtCpf" runat="server" class="form-control" Width="40%"></asp:TextBox>
                    </div>
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12">
                        <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
                        <asp:TextBox ID="txtSenha" runat="server" class="form-control" Width="40%"></asp:TextBox>
                    </div>
                    <div class="ajuste">
                        <asp:Button class="btn btn-secondary" ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                    </div>
                 </div>
            </div>
        </div>
    </form>
</body>
</html>
