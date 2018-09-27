using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenaiBanking.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        private string senha;

        public string Senha
        {
            get { return senha; } // TODO: Descriptografar do banco
            set { senha = value; } // TODO: Criptografar para o banco
        }

    }
}