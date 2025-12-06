using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class FilmeDAO : IDao<Filme>
    {
        public void Create(Filme filme)
        {
            try
            {
                string sql = @"INSERT INTO Filme (duracao_minutos, classificacao_indicativa, titulo, sinopse, fk_id_genero) 
                               VALUES (@duracao, @classificacao, @titulo, @sinopse, @id_genero)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@duracao", filme.Duracao_minutos);
                    cmd.Parameters.AddWithValue("@classificacao", filme.Classificacao_indicativa);
                    cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@sinopse", filme.Sinopse);
                    cmd.Parameters.AddWithValue("@id_genero", filme.Id_genero);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Filme filme)
        {
            try
            {
                string sql = @"UPDATE Filme SET duracao_minutos=@duracao, classificacao_indicativa=@classificacao, 
                               titulo=@titulo, sinopse=@sinopse, fk_id_genero=@id_genero 
                               WHERE id_filme=@id_filme";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@duracao", filme.Duracao_minutos);
                    cmd.Parameters.AddWithValue("@classificacao", filme.Classificacao_indicativa);
                    cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@sinopse", filme.Sinopse);
                    cmd.Parameters.AddWithValue("@id_genero", filme.Id_genero);
                    cmd.Parameters.AddWithValue("@id_filme", filme.Id_filme);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_filme).");
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
                string sql = "DELETE FROM Filme WHERE id_filme=@id_filme";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_filme", id);
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

        public List<Filme> GetAll()
        {
            List<Filme> lista = new List<Filme>();
            try
            {
                string sql = "SELECT * FROM Filme ORDER BY titulo";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Filme f = new Filme
                        {
                            Id_filme = dr.GetInt32("id_filme"),
                            Duracao_minutos = dr.GetInt32("duracao_minutos"),
                            Classificacao_indicativa = dr.GetString("classificacao_indicativa"),
                            Titulo = dr.GetString("titulo"),
                            Sinopse = dr.GetString("sinopse"),
                            Id_genero = dr.GetInt32("fk_id_genero")
                        };
                        lista.Add(f);
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
