<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwListarInvestimentos.aspx.cs" Inherits="SenaiBanking.Views.vwListarInvestimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
                </Columns>
            </asp:GridView>
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
