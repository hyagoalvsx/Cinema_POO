using Cinema_POO.Models;
using ConexaoBancoDados.Utilitarios;
using ConexaoBancoDados.Interfaces;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class SalaDAO : IDao<Sala>
    {
        public void Create(Sala sala)
        {
            try
            {
                string sql = @"INSERT INTO Sala (tipo_sala, nome_sala, capacidade) 
                               VALUES (@tipo, @nome, @capacidade)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@tipo", sala.Tipo_sala);
                    cmd.Parameters.AddWithValue("@nome", sala.Nome_sala);
                    cmd.Parameters.AddWithValue("@capacidade", sala.Capacidade);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Sala sala)
        {
            try
            {
                string sql = @"UPDATE Sala SET tipo_sala=@tipo, nome_sala=@nome, capacidade=@capacidade 
                               WHERE id_sala=@id_sala";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@tipo", sala.Tipo_sala);
                    cmd.Parameters.AddWithValue("@nome", sala.Nome_sala);
                    cmd.Parameters.AddWithValue("@capacidade", sala.Capacidade);
                    cmd.Parameters.AddWithValue("@id_sala", sala.Id_sala);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro atualizado (verifique o id_sala).");
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
                string sql = "DELETE FROM Sala WHERE id_sala=@id_sala";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_sala", id);
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

        public List<Sala> GetAll()
        {
            List<Sala> lista = new List<Sala>();
            try
            {
                string sql = "SELECT * FROM Sala ORDER BY nome_sala";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sala s = new Sala
                        {
                            Id_sala = dr.GetInt32("id_sala"),
                            Tipo_sala = dr.GetString("tipo_sala"),
                            Nome_sala = dr.GetString("nome_sala"),
                            Capacidade = dr.GetInt32("capacidade")
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
