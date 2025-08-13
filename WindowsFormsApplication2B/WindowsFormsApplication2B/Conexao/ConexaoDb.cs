using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2B.Conexao
{
    public class ConexaoDb
    {
        private MySqlConnection conexao;

        public string conexaoString = "server=localhost;port=3306;database=aplicacao_teste_erico;user=root;password=caara511";

        public MySqlConnection Conectar()
        {
            conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            return conexao;
        }
    }
}
