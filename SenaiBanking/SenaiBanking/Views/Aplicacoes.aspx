<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aplicacoes.aspx.cs" Inherits="SenaiBanking.Views.Aplicacoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Sacar.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row col-lg-12 col-sm-12">
            <div class="ajuste col-lg-12 col-sm-12">
                <asp:Label ID="lblValorDisponivel" runat="server" Text="Valor disponível para aplicação"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="R$ 2.000.000,00"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblValorAplicar" runat="server" Text="Digite o Valor"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorAplicar" runat="server" class="form-control" Text="R$ 0,00" Width="40%"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblDataAplicacao" runat="server" Text="Data da Aplicação"></asp:Label>
                <br />
                <asp:Label ID="lblData" runat="server" Text="28/09/2018"></asp:Label>
                <br />
                <div class="ajuste">
                    <br />
                    <br />
                    <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                    <asp:Button class="btn btn-secondary" ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />                  
                </div>
              
            </div>
        </div>
    </form>
</body>
</html>
