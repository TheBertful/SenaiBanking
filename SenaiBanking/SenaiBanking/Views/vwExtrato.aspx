<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwExtrato.aspx.cs" Inherits="SenaiBanking.Views.Extrato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        @media only screen and (max-width: 767px) {
            .separador {
                margin-top: 15px;
            }

            .centralizarTabelas {
                margin-left: 24%;
            }

            .grid {
                margin-top: 25px;
            }

            .separadorBtn {
                margin-left: 15%;
            }
        }

        @media only screen and (min-width: 767px) {
            .separadorBtn {
                margin-top: 15px;
                margin-left: 10%;
            }
        }

        .grid {
            margin-top: 30px;
            display: block;
            margin-left: auto;
            margin-right: auto
        }
    </style>
</head>
<body>
    <div class="head">
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
                        <a href="vwSolicitarEmprestimos.aspx">Solicitar Empréstimos</a>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div class="containerA">
    <form id="form1" runat="server">
        <div class="exibirConta">
            <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
            <asp:Label ID="txtNumeroConta" runat="server"  class="form-control tamanhoConta"></asp:Label>
        </div>
        <div class="container">
            <div>
                <asp:Label ID="lblMsg" runat="server" CssClass="alert alert-primary col-md-12"></asp:Label><br />
                <asp:Label ID="lblMsgError" runat="server" CssClass="alert alert-danger col-md-12"></asp:Label><br />
            </div>
            <br />
            <div class="row col-md-12 text-left">
                <div class="col-md-2"></div>
                <div class="col-md-4">
                    <asp:Label ID="lblDtaInicio" runat="server" Text="Data Ínicio"></asp:Label>
                    <asp:Calendar class="centralizarTabelas " ID="DtaInicio" runat="server"></asp:Calendar>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-4">
                    <asp:Label ID="lblDtaFim" runat="server" Text="Data Fim"></asp:Label>
                    <asp:Calendar ID="DtaFim" class="centralizarTabelas" runat="server"></asp:Calendar>
                </div>
            </div>
            <div class="row col-md-12 text-center">
                <asp:Button class="btn btn-secondary separador separadorBtn Corbtn col-md-4" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                <div class="col-md-1"></div>
                <asp:Button class="btn btn-secondary separador separadorBtn Corbtn col-md-4" ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" />
            </div>
            <div class="col-md-12">
                <div class="col-md-2"></div>
                <div class="col-md-6 grid">
                    <asp:GridView ID="gvdExtrato" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Data">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("data") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tipo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descrição">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("valor") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    </div>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
