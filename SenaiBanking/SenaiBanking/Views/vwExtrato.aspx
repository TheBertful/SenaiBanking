<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwExtrato.aspx.cs" Inherits="SenaiBanking.Views.Extrato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Sacar.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row saudacao col-lg-12 col-sm-12 col-xl-12 col-md-12">
                    <asp:Label ID="lblNumeroConta" runat="server" Text="Conta:"></asp:Label>
                    <asp:TextBox ID="txtNumeroConta" runat="server" class="form-control" Width="4%"></asp:TextBox>
                </div>
        <div class="container">
            <div>
                <asp:Label ID="lblMsg" runat="server"  CssClass="alert alert-primary col-lg-12 col-md-12 col-sm-12 col-xl-12"></asp:Label><br />
                <asp:Label ID="lblMsgError" runat="server"  CssClass="alert alert-primary col-lg-12 col-md-12 col-sm-12 col-xl-12"></asp:Label><br /> 
            </div>
            <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                <div class="ajuste col-lg-4 col-md-4 col-sm-4 col-xl-12">
                    <asp:Label ID="lblDtaInicio" runat="server" Text="Data Ínicio"></asp:Label>
                    <asp:Calendar ID="DtaInicio" runat="server"></asp:Calendar>
                </div>
                <div class="ajuste col-lg-4 col-md-4 col-sm-4 col-xl-12">
                    <asp:Label ID="lblDtaFim" runat="server" Text="Data Fim"></asp:Label>
                    <asp:Calendar ID="DtaFim" runat="server"></asp:Calendar>
                </div>
                <div class="botao col-lg-4 col-md-4 col-sm-4 col-xl-12">
                    <asp:Button class="btn btn-secondary" ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" />
                </div>
                <div>
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
                <div class="ajuste col-lg-4 col-sm-4 col-md-4 col-xl-12">
                    <asp:Button class="btn btn-secondary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
