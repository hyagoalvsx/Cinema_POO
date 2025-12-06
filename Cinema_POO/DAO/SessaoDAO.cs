using Cinema_POO.Models;
using ConexaoBancoDados.Utilitarios;
using ConexaoBancoDados.Interfaces;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class SessaoDAO : IDao<Sessao>
    {
        public void Create(Sessao sessao)
        {
            try
            {
                string sql = @"INSERT INTO Sessao (valor_ingresso, data_hora_inicio, fk_id_filme, fk_id_sala) 
                               VALUES (@valor, @datahora, @id_filme, @id_sala)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@valor", sessao.Valor_ingresso);
                    cmd.Parameters.AddWithValue("@datahora", sessao.Data_horario_inicio);
                    cmd.Parameters.AddWithValue("@id_filme", sessao.Id_filme);
                    cmd.Parameters.AddWithValue("@id_sala", sessao.Id_sala);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Sessao sessao)
        {
            try
            {
                string sql = @"UPDATE Sessao SET valor_ingresso=@valor, data_hora_inicio=@datahora, 
                               fk_id_filme=@id_filme, fk_id_sala=@id_sala 
                               WHERE id_sessao=@id_sessao";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@valor", sessao.Valor_ingresso);
                    cmd.Parameters.AddWithValue("@datahora", sessao.Data_horario_inicio);
                    cmd.Parameters.AddWithValue("@id_filme", sessao.Id_filme);
                    cmd.Parameters.AddWithValue("@id_sala", sessao.Id_sala);
                    cmd.Parameters.AddWithValue("@id_sessao", sessao.Id_sessao);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro atualizado (verifique o id_sessao).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Sessao WHERE id_sessao=@id_sessao";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_sessao", id);
                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi encontrado com esse ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Sessao> GetAll()
        {
            List<Sessao> lista = new List<Sessao>();
            try
            {
                string sql = "SELECT * FROM Sessao ORDER BY data_hora_inicio";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sessao s = new Sessao
                        {
                            Id_sessao = dr.GetInt32("id_sessao"),
                            Valor_ingresso = dr.GetDecimal("valor_ingresso"),
                            Data_horario_inicio = dr.GetDateTime("data_hora_inicio"),
                            Id_filme = dr.GetInt32("fk_id_filme"),
                            Id_sala = dr.GetInt32("fk_id_sala")
                        };
                        lista.Add(s);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
