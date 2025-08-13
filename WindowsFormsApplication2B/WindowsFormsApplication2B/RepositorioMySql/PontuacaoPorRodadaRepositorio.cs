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
    public class PontuacaoPorRodadaRepositorio
    {
        ConexaoDb conexao = new ConexaoDb();

        public void Insert(PontuacaoPorRodada p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = @"INSERT INTO pontuacao_por_rodada 
                          (nome, rodada, pontuacao, exatas)
                          VALUES (@nome, @rodada, @pontuacao, @exatas)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@rodada", p.Rodada);
                    cmd.Parameters.AddWithValue("@pontuacao", p.Pontuacao);
                    cmd.Parameters.AddWithValue("@exatas", p.Exatas);
                    cmd.ExecuteNonQuery();

                    // Recupera o ID gerado automaticamente
                    p.Id = (int)cmd.LastInsertedId;
                }
            }
        }

        public void Update(PontuacaoPorRodada p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = @"UPDATE pontuacao_por_rodada
                           SET nome = @nome,
                               rodada = @rodada,
                               pontuacao = @pontuacao,
                               exatas = @exatas
                           WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@rodada", p.Rodada);
                    cmd.Parameters.AddWithValue("@pontuacao", p.Pontuacao);
                    cmd.Parameters.AddWithValue("@exatas", p.Exatas);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public PontuacaoPorRodada BuscarPorId(int id)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM pontuacao_por_rodada WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PontuacaoPorRodada
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Pontuacao = Convert.ToInt32(reader["pontuacao"]),
                                Exatas = Convert.ToInt32(reader["exatas"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<PontuacaoPorRodada> BuscarPorRodada(string rodada)
        {
            using (var conn = conexao.Conectar())
            {
                List<PontuacaoPorRodada> pontuacoes = new List<PontuacaoPorRodada>();
                string sql = "SELECT * FROM pontuacao_por_rodada WHERE rodada = @rodada";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rodada", rodada);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pontuacao = new PontuacaoPorRodada()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Pontuacao = Convert.ToInt32(reader["pontuacao"]),
                                Exatas = Convert.ToInt32(reader["exatas"])
                            };
                            pontuacoes.Add(pontuacao);
                        }
                    }
                }
                return pontuacoes;
            }
        }

        public List<PontuacaoPorRodada> SelectAll()
        {
            using (var conn = conexao.Conectar())
            {
                List<PontuacaoPorRodada> pontuacoes = new List<PontuacaoPorRodada>();
                string sql = "SELECT * FROM pontuacao_por_rodada";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pontuacao = new PontuacaoPorRodada()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Pontuacao = Convert.ToInt32(reader["pontuacao"]),
                                Exatas = Convert.ToInt32(reader["exatas"])
                            };
                            pontuacoes.Add(pontuacao);
                        }
                    }
                }
                return pontuacoes;
            }
        }

        public PontuacaoPorRodada BuscarPorNomeRodada(string nome, string rodada)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = @"SELECT * FROM pontuacao_por_rodada 
                           WHERE nome = @nome AND rodada = @rodada";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@rodada", rodada);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PontuacaoPorRodada
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Pontuacao = Convert.ToInt32(reader["pontuacao"]),
                                Exatas = Convert.ToInt32(reader["exatas"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void DeletarPorId(int id)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "DELETE FROM pontuacao_por_rodada WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
