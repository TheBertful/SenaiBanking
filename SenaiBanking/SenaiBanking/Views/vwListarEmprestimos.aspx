<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwListarEmprestimos.aspx.cs" Inherits="SenaiBanking.Views.vwListarEmprestimos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Lista de Emprestimos</title>
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
                    <a href="" class="dropbtn">Conta Corrente</a>
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
                        <a href="vwAplicacoes.aspx">Aplicação</a>
                        <a href="#">Meus investimentos</a>
                        <a href="#">Resgate</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="vwEmprestimo.aspx" class="dropbtn">Empréstimo</a>
                    <div class="dropdown-content">
                        <a href="vwListarEmprestimos.aspx">Listar Empréstimos</a>
                        <a href="vwSolicitarEmprestimo.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div class="container">
        <h1 class="h1">Listar Emprestimos</h1>
        <form id="form1" runat="server">
            <br />
            <br />
            <!-- Onde serão exibidos avisos -->
            <asp:Label ID="lblAviso" runat="server" />
            <br />
            <div>

                <!-- Tabela de emprestimos pendentes realizados -->
                <asp:GridView ID="gdvEmprestimos" runat="server" CssClass="table-light text-center col-6"
                    AutoGenerateColumns="False" OnRowCommand="gdvEmprestimos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Numero">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtId" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descrição">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Forma de Pagamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFormaPagamento" runat="server" Text='<%# Bind("FormaPagamento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFormaPagamento" runat="server" Text='<%# Bind("FormaPagamento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data da solicitação">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtData" runat="server" Text='<%# Bind("Data") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblData" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qtd. Parcelas">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtParcelas" runat="server" Text='<%# Bind("Parcelas") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblParcelas" runat="server" Text='<%# Bind("Parcelas") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operações" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnVisualizar" runat="server" CausesValidation="false" CommandName="" Text="Visualizar" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div>
                <!-- Tabela de parcelas do emprestimo que clicou em visualizar se o mesmo for pagamento tipo boleto -->
                <asp:GridView ID="gdvParcelasBoleto" runat="server" CssClass="table-light text-center col-6" AutoGenerateColumns="False" OnRowCommand="gdvParcelasBoleto_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Numero">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNumero" runat="server" Text='<%# Bind("Numero") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNumero" runat="server" Text='<%# Bind("Numero") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtValor" runat="server" Text='<%# Bind("Valor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblValor" runat="server" Text='<%# Bind("Valor") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="Operações" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnGerarBoleto" runat="server" CausesValidation="false" CommandName="" Text="Gerar Boleto" CommandArgument='<%# Bind("Numero") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <!-- Tabela de parcelas do emprestimo que clicou em visualizar se o mesmo for pagamento tipo debito em conta -->
                <asp:GridView ID="gdvParcelasDebitoEmConta" runat="server" AutoGenerateColumns="False" CssClass="table-light text-center col-6" OnRowCommand="gdvParcelasDebitoEmConta_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Numero">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNumeroDC" runat="server" Text='<%# Bind("Numero") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNumeroDC" runat="server" Text='<%# Bind("Numero") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStatusDC" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatusDC" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtValotDC" runat="server" Text='<%# Bind("Valor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblValorDC" runat="server" Text='<%# Bind("Valor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vencimento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDataDC" runat="server" Text='<%# Bind("Vencimento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDataDC" runat="server" Text='<%# Bind("Vencimento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operações" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPagar" runat="server" CausesValidation="false" CommandName="" Text="Pagar antecipado" CommandArgument='<%# Bind("Numero") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        
        <div class="col-lg-12 col-sm-12 col-md-12">
            <asp:Button CssClass="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
            </form>
    </div>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
