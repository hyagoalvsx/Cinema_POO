using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class ProdutoDAO : IDao<Produto>
    {
        public void Create(Produto produto)
        {
            try
            {
                string sql = @"INSERT INTO Produto (nome, categoria, quant_estoque, preco_unitario) 
                               VALUES (@nome, @categoria, @quant, @preco)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                    cmd.Parameters.AddWithValue("@quant", produto.Quant_estoque);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco_unitario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                string sql = @"UPDATE Produto SET nome=@nome, categoria=@categoria, 
                               quant_estoque=@quant, preco_unitario=@preco 
                               WHERE id_produto=@id_produto";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                    cmd.Parameters.AddWithValue("@quant", produto.Quant_estoque);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco_unitario);
                    cmd.Parameters.AddWithValue("@id_produto", produto.Id_produto);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_produto).");
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
                string sql = "DELETE FROM Produto WHERE id_produto=@id_produto";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_produto", id);
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

        public List<Produto> GetAll()
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                string sql = "SELECT * FROM Produto ORDER BY nome";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Produto p = new Produto
                        {
                            Id_produto = dr.GetInt32("id_produto"),
                            Nome = dr.GetString("nome"),
                            Categoria = dr.GetString("categoria"),
                            Quant_estoque = dr.GetInt32("quant_estoque"),
                            Preco_unitario = dr.GetDecimal("preco_unitario")
                        };
                        lista.Add(p);
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
