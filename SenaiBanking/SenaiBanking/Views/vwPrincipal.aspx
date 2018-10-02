<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwPrincipal.aspx.cs" Inherits="SenaiBanking.Views.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Principal.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .Barra{
                list-style-type: none;
                margin: 0;
                padding: 0;
                overflow: hidden;
                background-color: #333;
                height: 52px;
        }
        .liCor{
                color: white;
                bottom: 0;
                position: absolute;
        }
    </style>
</head>
<body>
    <div class="head">
        <div class="logo"></div>
        <div class="menu">
            <ul class="Barra" >
                <li class="liCor">
                    <asp:Label ID="lbl" runat="server" Text="Seja Bem-Vindo(a), "></asp:Label>
                    <asp:Label ID="lblSaudacao" runat="server"></asp:Label>
                </li>
            </ul>
        </div>
    </div>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row col-lg-12 col-sm-12 col-xl-12 col-md-12">
                    <asp:Label ID="lblNumeroConta" runat="server" Text=""></asp:Label>
                </div>
                <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnSaque" runat="server" Text="Saque" OnClick="btnSaque_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnDeposito" runat="server" Text="Depósito" OnClick="btnDeposito_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-md-12 col-sm-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnTransferencia" runat="server" Text="Transferência" OnClick="btnTransferencia_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-md-12 col-sm-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnInvestimento" runat="server" Text="Investimento" OnClick="btnInvestimento_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-md-12 col-sm-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnEmprestimo" runat="server" Text="Empréstimo" OnClick="btnEmprestimo_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-md-12 col-sm-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnSaldo" runat="server" Text="Saldo" OnClick="btnSaldo_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnExtrato" runat="server" Text="Extrato" OnClick="btnExtrato_Click" />
                    </div>
                    <div class="ajuste col-lg-12 col-sm-12 col-md-12 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblAviso" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblCCE" runat="server" Text="Saldo atual da Conta Contábil de Empréstimo: "></asp:Label>
                        <asp:Label ID="lblContaContabilEmprestimo" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblCCI" runat="server" Text="Saldo atual da Conta Contábil de Investimento: "></asp:Label>
                        <asp:Label ID="lblContaContabilInvestimento" runat="server"></asp:Label>
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
    <div class="footer"></div>
    <div class="footer1 text-center CorLetras">Direitos.</div>
</body>
</html>
