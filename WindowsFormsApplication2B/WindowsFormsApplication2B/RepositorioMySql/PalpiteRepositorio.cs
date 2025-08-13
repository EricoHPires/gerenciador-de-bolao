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
    public class PalpiteRepositorio
    {
        ConexaoDb conexao = new ConexaoDb();

        public void Insert(Palpite p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = @"INSERT INTO palpite 
                    (participanteNome, rodada, jogo, golsMandante, golsVisitante)
                    VALUES (@participanteNome, @rodada, @jogo, @golsMandante, @golsVisitante)";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@participanteNome", p.ParticipanteNome);
                    cmd.Parameters.AddWithValue("@rodada", p.Rodada);
                    cmd.Parameters.AddWithValue("@jogo", p.Jogo);
                    cmd.Parameters.AddWithValue("@golsMandante", p.GolsMandante);
                    cmd.Parameters.AddWithValue("@golsVisitante", p.GolsVisitante);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Palpite p)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = @"UPDATE palpite SET 
                    participanteNome = @participanteNome, 
                    rodada = @rodada, 
                    jogo = @jogo, 
                    golsMandante = @golsMandante, 
                    golsVisitante = @golsVisitante,
                    computado = @computado
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@participanteNome", p.ParticipanteNome);
                    cmd.Parameters.AddWithValue("@rodada", p.Rodada);
                    cmd.Parameters.AddWithValue("@jogo", p.Jogo);
                    cmd.Parameters.AddWithValue("@golsMandante", p.GolsMandante);
                    cmd.Parameters.AddWithValue("@golsVisitante", p.GolsVisitante);
                    cmd.Parameters.AddWithValue("@computado", p.Computado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Palpite BuscarPorId(int id)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM palpite WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Palpite
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ParticipanteNome = reader["participanteNome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Jogo = reader["jogo"].ToString(),
                                GolsMandante = Convert.ToInt32(reader["golsMandante"]),
                                GolsVisitante = Convert.ToInt32(reader["golsVisitante"]),
                                Computado = reader["computado"] != DBNull.Value && Convert.ToBoolean(reader["computado"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Palpite> BuscarPorRodada(string rodada)
        {
            using (var conn = conexao.Conectar())
            {
                List<Palpite> palpites = new List<Palpite>();
                string sql = "SELECT * FROM palpite WHERE rodada = @rodada";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rodada", rodada);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var palpite = new Palpite()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ParticipanteNome = reader["participanteNome"].ToString(),
                                Rodada = reader["rodada"].ToString(),
                                Jogo = reader["jogo"].ToString(),
                                GolsMandante = Convert.ToInt32(reader["golsMandante"]),
                                GolsVisitante = Convert.ToInt32(reader["golsVisitante"]),
                                Computado = reader["computado"] != DBNull.Value && Convert.ToBoolean(reader["computado"])
                            };
                            palpites.Add(palpite);
                        }
                    }
                }
                return palpites;
            }
        }

        public void DeletarPorId(int id)
        {
            using (var conn = conexao.Conectar())
            {
                string sql = "DELETE FROM palpite WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
