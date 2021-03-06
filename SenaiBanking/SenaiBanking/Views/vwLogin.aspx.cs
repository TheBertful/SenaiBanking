﻿using SenaiBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SenaiBanking.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMsg.Visible = false;
            string primeiroLogin = Session["PrimeiroLogin"] as string;

            if (primeiroLogin == null)
            {
                // Instanciação de Banco e Contas contábeis
                Banco banco = new Banco()
                {
                    Nome = "Banco Exemplo"
                };
                ContaContabilEmprestimo cce = new ContaContabilEmprestimo()
                {
                    Emprestimos = new List<Emprestimo>(),
                    BancoProp = banco
                };
                ContaContabilInvestimento cci = new ContaContabilInvestimento()
                {
                    Investimentos = new List<Investimento>(),
                    BancoProp = banco
                };
                banco.ContaEmprestimo = cce;
                banco.ContaInvestimento = cci;

                Session["Emprestimos"] = cce;
                Session["Investimentos"] = cci;
                Session["Banco"] = banco;

                Cliente cliente = new Cliente()
                {
                    Id = 1,
                    Nome = "Usuario",
                    //Cpf = "00000000000",
                    Cpf = "0",
                    Senha = "123"
                };
                Session["Cliente"] = cliente;

                Session["ContaCorrente"] = new ContaCorrente()
                {
                    Id = 1,
                    ClienteProp = cliente,
                    Limite = 1000.00,
                    Numero = "1",
                    Saldo = 1500.00,
                    Tipo = "Silver",
                    Transacoes = new List<Transacao>(),
                    BancoProp = Session["Banco"] as Banco
                };

                Cliente cliente2 = new Cliente()
                {
                    Id = 2,
                    Nome = "Usuario 2",
                    //Cpf = "00000000000",
                    Cpf = "1",
                    Senha = "123"
                };
                Session["Cliente2"] = cliente2;

                Session["ContaCorrente2"] = new ContaCorrente()
                {
                    Id = 2,
                    ClienteProp = cliente2,
                    Limite = 6000.00,
                    Numero = "2",
                    Saldo = 8500.00,
                    Tipo = "Gold",
                    Transacoes = new List<Transacao>(),
                    BancoProp = Session["Banco"] as Banco
                };

            }

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = Session["Cliente"] as Cliente;
            Cliente cliente2 = Session["Cliente2"] as Cliente;
            ContaCorrente contacorrente = Session["ContaCorrente"] as ContaCorrente;
            ContaCorrente contacorrente2 = Session["Contacorrente2"] as ContaCorrente;
            if (cliente.Cpf.Equals(txtCpf.Text) && cliente.Senha.Equals(txtSenha.Text))
            {
                Session["Cliente"] = cliente;
                Session["ContaCorrente"] = contacorrente;
                Session["Cliente2"] = cliente2;
                Session["ContaCorrente2"] = contacorrente2;
                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
            else if (cliente2.Cpf.Equals(txtCpf.Text) && cliente2.Senha.Equals(txtSenha.Text))
            {
                Session["Cliente"] = cliente2;
                Session["ContaCorrente"] = contacorrente2;
                Session["Cliente2"] = cliente;
                Session["ContaCorrente2"] = contacorrente;
                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
            else
            {
                txtMsg.Visible = true;
                txtMsg.Text = "Login ou senha inválidos";
            }
        }
    }
}