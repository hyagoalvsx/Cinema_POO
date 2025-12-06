using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class VendaDAO : IDao<Venda>
    {
        public void Create(Venda venda)
        {
            try
            {
                string sql = @"INSERT INTO Venda (forma_pagamento, valor_total, data_hora_venda, fk_id_cliente, fk_id_funcionario) 
                               VALUES (@forma, @valor, @dataHora, @id_cliente, @id_funcionario)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@forma", venda.Forma_pagamento);
                    cmd.Parameters.AddWithValue("@valor", venda.Valor_total);
                    cmd.Parameters.AddWithValue("@dataHora", venda.Data_hora_venda);
                    cmd.Parameters.AddWithValue("@id_cliente", venda.Id_cliente);
                    cmd.Parameters.AddWithValue("@id_funcionario", venda.Id_funcionario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Venda venda)
        {
            try
            {
                string sql = @"UPDATE Venda SET forma_pagamento=@forma, valor_total=@valor, 
                               data_hora_venda=@dataHora, fk_id_cliente=@id_cliente, fk_id_funcionario=@id_funcionario 
                               WHERE id_venda=@id_venda";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@forma", venda.Forma_pagamento);
                    cmd.Parameters.AddWithValue("@valor", venda.Valor_total);
                    cmd.Parameters.AddWithValue("@dataHora", venda.Data_hora_venda);
                    cmd.Parameters.AddWithValue("@id_cliente", venda.Id_cliente);
                    cmd.Parameters.AddWithValue("@id_funcionario", venda.Id_funcionario);
                    cmd.Parameters.AddWithValue("@id_venda", venda.Id_venda);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_venda).");
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
                string sql = "DELETE FROM Venda WHERE id_venda=@id_venda";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_venda", id);
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

        public List<Venda> GetAll()
        {
            List<Venda> lista = new List<Venda>();
            try
            {
                string sql = "SELECT * FROM Venda ORDER BY data_hora_venda";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Venda v = new Venda
                        {
                            Id_venda = dr.GetInt32("id_venda"),
                            Forma_pagamento = dr.GetString("forma_pagamento"),
                            Valor_total = dr.GetDecimal("valor_total"),
                            Data_hora_venda = dr.GetDateTime("data_hora_venda"),
                            Id_cliente = dr.GetInt32("fk_id_cliente"),
                            Id_funcionario = dr.GetInt32("fk_id_funcionario")
                        };
                        lista.Add(v);
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
