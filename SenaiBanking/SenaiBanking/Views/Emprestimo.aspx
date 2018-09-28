<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emprestimo.aspx.cs" Inherits="SenaiBanking.Views.Emprestimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div class="container">
                <br/>
                    <div class="row">
                        <asp:Label ID="lblLimite" runat="server" CssClass="text-warning"></asp:Label><br/>
                    </div><br/>
                    <div class="">
                        <asp:Label ID="lblValor" runat="server" Text="Valor"></asp:Label><br/>
                        <asp:TextBox ID="txtValor" runat="server" CssClass="form-control col-4" AutoPostBack="True" OnTextChanged="txtValor_TextChanged"></asp:TextBox>
                    </div><br/>
                    <div class="">
                        <asp:Label ID="lblQuantidadeParcelas" runat="server" Text="Quantidade de parcelas"></asp:Label><br/>
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
                    </div><br/>
                   <div>
                       <asp:GridView ID="gdvParcelas" runat="server" CssClass="table-secondary col-6"></asp:GridView>
                   </div><br/>
                    <div>
                        <asp:Button CssClass="btn btn-secondary" ID="btnConcluir" runat="server" Text="Concluir" OnClick="btnConcluir_Click" />
                    </div><br/>
                    <div>
                        <asp:Label ID="lblAviso" runat="server"></asp:Label>
                    </div>
                </div>
    </form>
</body>
</html>
