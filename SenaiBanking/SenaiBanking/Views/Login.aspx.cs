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
            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Usuario",
                Cpf = "00000000000",
                Senha = "123"
            };
            Session["Cliente"] = cliente;

            Session["ContaCorrente"] = new ContaCorrente()
            {
                Id = 1,
                ClienteProp = cliente,
                Limite = 1000.00,
                Numero = 1,
                Saldo = 1500.00,
                Tipo = "Gold",
            };

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

        }
    }
}