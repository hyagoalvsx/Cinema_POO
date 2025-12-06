using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class AssentoDAO : IDao<Assento>
    {
        public void Create(Assento assento)
        {
            try
            {
                string sql = @"INSERT INTO Assento (poltrona, status_poltrona, fk_id_sala) 
                               VALUES (@poltrona, @status, @id_sala)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@poltrona", assento.Poltrona);
                    cmd.Parameters.AddWithValue("@status", assento.Status_poltrona);
                    cmd.Parameters.AddWithValue("@id_sala", assento.Id_sala);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Assento assento)
        {
            try
            {
                string sql = @"UPDATE Assento SET poltrona=@poltrona, status_poltrona=@status, 
                               fk_id_sala=@id_sala 
                               WHERE id_assento=@id_assento";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@poltrona", assento.Poltrona);
                    cmd.Parameters.AddWithValue("@status", assento.Status_poltrona);
                    cmd.Parameters.AddWithValue("@id_sala", assento.Id_sala);
                    cmd.Parameters.AddWithValue("@id_assento", assento.Id_assento);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_assento).");
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
                string sql = "DELETE FROM Assento WHERE id_assento=@id_assento";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_assento", id);
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

        public List<Assento> GetAll()
        {
            List<Assento> lista = new List<Assento>();
            try
            {
                string sql = "SELECT * FROM Assento ORDER BY poltrona";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Assento a = new Assento
                        {
                            Id_assento = dr.GetInt32("id_assento"),
                            Poltrona = dr.GetString("poltrona"),
                            Status_poltrona = dr.GetString("status_poltrona"),
                            Id_sala = dr.GetInt32("fk_id_sala")
                        };
                        lista.Add(a);
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
