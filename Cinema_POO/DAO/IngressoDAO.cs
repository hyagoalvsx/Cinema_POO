using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class IngressoDAO : IDao<Ingresso>
    {
        public void Create(Ingresso ingresso)
        {
            try
            {
                string sql = @"INSERT INTO Ingresso (tipo_ingresso, valor_pago, fk_id_venda, fk_id_sessao) 
                               VALUES (@tipo, @valor, @id_venda, @id_sessao)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@tipo", ingresso.Tipo_ingresso);
                    cmd.Parameters.AddWithValue("@valor", ingresso.Valor_pago);
                    cmd.Parameters.AddWithValue("@id_venda", ingresso.Id_venda);
                    cmd.Parameters.AddWithValue("@id_sessao", ingresso.Id_sessao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Ingresso ingresso)
        {
            try
            {
                string sql = @"UPDATE Ingresso SET tipo_ingresso=@tipo, valor_pago=@valor, 
                               fk_id_venda=@id_venda, fk_id_sessao=@id_sessao 
                               WHERE id_ingresso=@id_ingresso";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@tipo", ingresso.Tipo_ingresso);
                    cmd.Parameters.AddWithValue("@valor", ingresso.Valor_pago);
                    cmd.Parameters.AddWithValue("@id_venda", ingresso.Id_venda);
                    cmd.Parameters.AddWithValue("@id_sessao", ingresso.Id_sessao);
                    cmd.Parameters.AddWithValue("@id_ingresso", ingresso.Id_ingresso);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_ingresso).");
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
                string sql = "DELETE FROM Ingresso WHERE id_ingresso=@id_ingresso";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_ingresso", id);
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

        public List<Ingresso> GetAll()
        {
            List<Ingresso> lista = new List<Ingresso>();
            try
            {
                string sql = "SELECT * FROM Ingresso ORDER BY tipo_ingresso";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Ingresso i = new Ingresso
                        {
                            Id_ingresso = dr.GetInt32("id_ingresso"),
                            Tipo_ingresso = dr.GetString("tipo_ingresso"),
                            Valor_pago = dr.GetDecimal("valor_pago"),
                            Id_venda = dr.GetInt32("fk_id_venda"),
                            Id_sessao = dr.GetInt32("fk_id_sessao")
                        };
                        lista.Add(i);
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
