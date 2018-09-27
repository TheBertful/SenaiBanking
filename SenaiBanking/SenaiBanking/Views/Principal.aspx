<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SenaiBanking.Views.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Principal.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row col-lg-12 col-md-12 col-sm-12 col-xl-12">
                    <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnSaque" runat="server" Text="Saque" OnClick="btnSaque_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnDeposito" runat="server" Text="Depósito" OnClick="btnDeposito_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnTransferencia" runat="server" Text="Transferência" OnClick="btnTransferencia_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnInvestimento" runat="server" Text="Investimento" OnClick="btnInvestimento_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnEmprestimo" runat="server" Text="Empréstimo" OnClick="btnEmprestimo_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-md-6 col-sm-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnSaldo" runat="server" Text="Saldo" OnClick="btnSaldo_Click" />
                    </div>
                    <div class="ajuste col-lg-6 col-sm-6 col-md-6 col-xl-12">
                        <asp:Button class="btn btn-secondary btn-lg mesmo-tamanho" ID="btnExtrato" runat="server" Text="Extrato" OnClick="btnExtrato_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblAviso" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
