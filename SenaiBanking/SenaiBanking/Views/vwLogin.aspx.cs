using SenaiBanking.Models;
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
            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Usuario",
                //Cpf = "00000000000",
                Cpf = "0",
                Senha = "123"
            };
            Session["Cliente"] = cliente;

            Cliente cliente2 = new Cliente()
            {
                Id = 1,
                Nome = "Usuario 2",
                //Cpf = "00000000000",
                Cpf = "1",
                Senha = "123"
            };
            Session["Cliente2"] = cliente2;

            Session["Emprestimos"] = new List<Emprestimo>();
            Session["Transacao"] = new List<Transferencia>();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = Session["Cliente"] as Cliente;
            Cliente cliente2 = Session["Cliente2"] as Cliente;
            if (cliente.Cpf.Equals(txtCpf.Text) && cliente.Senha.Equals(txtSenha.Text))
            {
                Session["ContaCorrente"] = new ContaCorrente()
                {
                    Id = 1,
                    ClienteProp = cliente,
                    Limite = 1000.00,
                    Numero = "1",
                    Saldo = 1500.00,
                    Tipo = "Silver",
                };

                Session["ContaCorrente2"] = new ContaCorrente()
                {
                    Id = 2,
                    ClienteProp = cliente2,
                    Limite = 6000.00,
                    Numero = "2",
                    Saldo = 8500.00,
                    Tipo = "Gold",
                };

                Response.Redirect("~/Views/vwPrincipal.aspx");
            }
            else if(cliente2.Cpf.Equals(txtCpf.Text) && cliente2.Senha.Equals(txtSenha.Text))
            {
                Session["ContaCorrente"] = new ContaCorrente()
                {
                    Id = 2,
                    ClienteProp = cliente2,
                    Limite = 6000.00,
                    Numero = "2",
                    Saldo = 8500.00,
                    Tipo = "Gold",
                };

                Session["ContaCorrente2"] = new ContaCorrente()
                {
                    Id = 1,
                    ClienteProp = cliente,
                    Limite = 1000.00,
                    Numero = "1",
                    Saldo = 1500.00,
                    Tipo = "Silver",
                };
 
            }
            else
            {
                txtMsg.Visible = true;
                txtMsg.Text = "Login ou senha inválidos";
            }
        }
    }
}