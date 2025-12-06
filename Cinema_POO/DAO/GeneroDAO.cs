using Cinema_POO.Models;
using ConexaoBancoDados.Utilitarios;
using ConexaoBancoDados.Interfaces;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class GeneroDAO : IDao<Genero>
    {
        public void Create(Genero genero)
        {
            try
            {
                string sql = @"INSERT INTO Genero (nome_genero) VALUES (@nome_genero)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome_genero", genero.Nome_genero);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Genero genero)
        {
            try
            {
                string sql = @"UPDATE Genero SET nome_genero = @nome_genero WHERE id_genero = @id_genero";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome_genero", genero.Nome_genero);
                    cmd.Parameters.AddWithValue("@id_genero", genero.Id_genero);
                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_genero).");
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
                string sql = "DELETE FROM Genero WHERE id_genero = @id_genero";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_genero", id);
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

        public List<Genero> GetAll()
        {
            List<Genero> lista = new List<Genero>();
            try
            {
                string sql = "SELECT * FROM Genero ORDER BY nome_genero";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Genero g = new Genero
                        {
                            Id_genero = dr.GetInt32("id_genero"),
                            Nome_genero = dr.GetString("nome_genero")
                        };
                        lista.Add(g);
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
