<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwListarInvestimentos.aspx.cs" Inherits="SenaiBanking.Views.vwListarInvestimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="container">
        <h1 class="h1">Listar Investimentos</h1>
        <form id="form1" runat="server">
            <br />
            <div>
            <asp:GridView ID="gdvListarInvestimentos"  CssClass="table-light text-center col-6" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvListarInvestimentos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="DataSolicitacao" HeaderText="Data Solicitação" />
                    <asp:BoundField DataField="Rendimento" HeaderText="Rendimento" />
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" />
                    <asp:BoundField DataField="Valortotal" HeaderText="Valor Total" />
                    <asp:ButtonField HeaderText="Operações" Text="Resgatar" />
                </Columns>
            </asp:GridView>
                </div>
            <br />
             <div class="ajuste col-lg-12 col-sm-12">
                 <asp:Label ID="lblValorResgate" runat="server" Text="Digite o Valor para Resgate"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorResgate" runat="server" class="form-control" Width="40%" OnTextChanged="txtValorResgatar_TextChanged"></asp:TextBox>
                 </div>
            <br />
            <br />
             <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
            <br />
        </form>
    </div>
</body>
</html>
