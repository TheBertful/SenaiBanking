<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwResgatar.aspx.cs" Inherits="SenaiBanking.Views.vwResgatar" %>

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
                <asp:GridView ID="gdvResgatarInvestimento" CssClass="table-light text-center col-6" runat="server" AutoGenerateColumns="False"  OnRowCommand="gdvResgatarInvestimento_RowCommand">
                    <Columns>

                        <asp:TemplateField HeaderText="Descrição">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data Solicitação">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDataSolicitacao" runat="server" Text='<%# Bind("DataSolicitacao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDataSolicitacao" runat="server" Text='<%# Bind("DataSolicitacao") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rendimento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRendimento" runat="server" Text='<%# Bind("Rendimento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRendimento" runat="server" Text='<%# Bind("Rendimento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vencimento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVencimento" runat="server" Text='<%# Bind("Vencimento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblVencimento" runat="server" Text='<%# Bind("Vencimento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor Total">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtValorTotal" runat="server" Text='<%# Bind("Valortotal") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblValorTotal" runat="server" Text='<%# Bind("Valortotal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Operações" ShowHeader="False">
                           <EditItemTemplate>
                                <asp:LinkButton ID="txtSelecionar" runat="server" CausesValidation="false" CommandName="" Text="Render"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="false" CommandName="RowCommand" Text="Render" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div class="col-lg-12 col-sm-12 col-md-12">
                <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
                <br />
                <asp:TextBox ID="txtDescricao" runat="server" class="form-control" Width="40%" OnTextChanged="txtDescricao_TextChanged"></asp:TextBox>
                <asp:Label ID="lblRendimento" runat="server" Text="Rendimento"></asp:Label>
                <br />
                <asp:TextBox ID="txtRendimento" runat="server" class="form-control" Width="40%" OnTextChanged="txtRendimento_TextChanged"></asp:TextBox>
                <asp:Label ID="lblValorTotal" runat="server" Text="Valor Total"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorTotal" runat="server" class="form-control" Width="40%" OnTextChanged="txtValortotal_TextChanged"></asp:TextBox>
                <br />
                <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                <asp:Button class="btn btn-secondary" ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
            </div>
            <br />
        </form>
    </div>
</body>
</html>
