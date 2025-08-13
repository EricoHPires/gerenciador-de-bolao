using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2B.Conexao;
using WindowsFormsApplication2B.Dominio;

namespace WindowsFormsApplication2B.RepositorioMySql
{
    public class ParticipanteRepositorio
    {
        ConexaoDb conexao = new ConexaoDb();

        public void Insert(Participante p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "INSERT INTO participante (nome, pontuacaoTotal, exatas) VALUES (@nome, @pontuacaoTotal, @exatas)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@pontuacaoTotal", p.PontuacaoTotal);
                    cmd.Parameters.AddWithValue("@exatas", p.Exatas);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Participante p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "UPDATE participante SET pontuacaoTotal = @pontuacaoTotal, exatas = @exatas WHERE nome = @nome";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pontuacaoTotal", p.PontuacaoTotal);
                    cmd.Parameters.AddWithValue("@exatas", p.Exatas);
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Participante BuscarPorNome(string nome)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM participante WHERE nome = @nome";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Participante
                            {
                                Nome = reader["nome"].ToString(),
                                PontuacaoTotal = int.Parse(reader["pontuacaoTotal"].ToString()),
                                Exatas = int.Parse(reader["exatas"].ToString())
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Participante> ListarTodos()
        {
            var lista = new List<Participante>();

            using (var conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM participante";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var participante = new Participante
                        {
                            Nome = reader["nome"].ToString(),
                            Exatas = Convert.ToInt32(reader["exatas"].ToString()),
                            PontuacaoTotal = Convert.ToInt32(reader["pontuacaoTotal"].ToString())
                        };

                        lista.Add(participante);
                    }
                }
            }
            return lista;
        }

        public void DeletarPorNome(string nome)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "DELETE FROM participante WHERE nome = @nome";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
