<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwResgatar.aspx.cs" Inherits="SenaiBanking.Views.vwResgatar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="head">
        <div class="exibirConta">
            <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
            <asp:Label ID="txtNumeroConta" runat="server" class="form-control tamanhoConta"></asp:Label>
        </div>
        <div class="logo"></div>
        <div class="menu">
            <ul>
                <li><a href="vwPrincipal.aspx">Inicio</a></li>
                <li class="dropdown">
                    <a href="Conta" class="dropbtn">Conta Corrente</a>
                    <div class="dropdown-content">
                        <a href="vwDepositar.aspx">Depósito</a>
                        <a href="vwExtrato.aspx">Extrato</a>
                        <a href="vwSaldo.aspx">Saldo</a>
                        <a href="vwSacar.aspx">Saque</a>
                        <a href="vwTransferir.aspx">Transferência</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwInvestimentos.aspx" class="dropbtn">Investimento</a>
                    <div class="dropdown-content">
                        <a href="vwAplicacoes.aspx">Apliacação</a>
                        <a href="#">Meus investimentos</a>
                        <a href="#">Resgate</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwEmprestimo.aspx" class="dropbtn">Empréstimo</a>
                    <div class="dropdown-content">
                        <a href="vwListarEmprestimos.aspx">Listar empréstimos</a>
                        <a href="vwSolicitarEmprestimo.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <form id="form1" runat="server">
        <h1 class="h1">Aplicações para Resgate</h1>
        <div class="container">
            <br />     
            <asp:GridView ID="gdvResgatarInvestimento" CssClass="table-light text-center col-6" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvResgatarInvestimento_RowCommand">
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
            <asp:TextBox class="alert alert-danger col-lg-12 col-md-12 col-sm-12 col-xl-12" ClientIDMode="AutoID" ID="txtMsgError" runat="server" role="alert"></asp:TextBox>
            <br />
            <asp:Button class="btn btn-secondary" ID="btnConfirmar" runat="server" Text="Confirmar Resgate" OnClick="btnConfirmar_Click" />
        </div>
        <br />
          <div class="col-lg-12 col-sm-12 col-md-12">
        <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    </div>
    </form>
</body>
</html>
