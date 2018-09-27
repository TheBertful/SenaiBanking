using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Connection
{
    public class ConexaoDB
    {
        public MySqlConnection Conexao { get; set; }
        public MySqlCommand Comando { get; set; }

        public ConexaoDB()
        {
            string con = "Server=localhost;Database=senaibanking;" +
                "Uid=root;Pwd=venus";
            Conexao = new MySqlConnection(con);
            Comando = Conexao.CreateCommand();
            Conexao.Open();
        }
    }
}