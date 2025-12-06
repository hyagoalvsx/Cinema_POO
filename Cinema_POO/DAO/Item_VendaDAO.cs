using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class ItemVendaDAO : IDao<Item_Venda>
    {
        public void Create(Item_Venda item)
        {
            try
            {
                string sql = @"INSERT INTO Item_Venda (quantidade, preco_unitario, subtotal, fk_id_produto, fk_id_venda) 
                               VALUES (@quant, @preco, @subtotal, @id_produto, @id_venda)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@quant", item.Quantidade);
                    cmd.Parameters.AddWithValue("@preco", item.Preco_unitario);
                    cmd.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmd.Parameters.AddWithValue("@id_produto", item.Id_produto);
                    cmd.Parameters.AddWithValue("@id_venda", item.Id_venda);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Item_Venda item)
        {
            try
            {
                string sql = @"UPDATE Item_Venda SET quantidade=@quant, preco_unitario=@preco, subtotal=@subtotal, 
                               fk_id_produto=@id_produto, fk_id_venda=@id_venda 
                               WHERE id_item=@id_item";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@quant", item.Quantidade);
                    cmd.Parameters.AddWithValue("@preco", item.Preco_unitario);
                    cmd.Parameters.AddWithValue("@subtotal", item.Subtotal);
                    cmd.Parameters.AddWithValue("@id_produto", item.Id_produto);
                    cmd.Parameters.AddWithValue("@id_venda", item.Id_venda);
                    cmd.Parameters.AddWithValue("@id_item", item.Id_item);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_item).");
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
                string sql = "DELETE FROM Item_Venda WHERE id_item=@id_item";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_item", id);
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

        public List<Item_Venda> GetAll()
        {
            List<Item_Venda> lista = new List<Item_Venda>();
            try
            {
                string sql = "SELECT * FROM Item_Venda ORDER BY id_item";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Item_Venda i = new Item_Venda
                        {
                            Id_item = dr.GetInt32("id_item"),
                            Quantidade = dr.GetInt32("quantidade"),
                            Preco_unitario = dr.GetDecimal("preco_unitario"),
                            Subtotal = dr.GetDecimal("subtotal"),
                            Id_produto = dr.GetInt32("fk_id_produto"),
                            Id_venda = dr.GetInt32("fk_id_venda")
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
