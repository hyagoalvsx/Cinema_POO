using Cinema_POO.Models;
using ConexaoBancoDados.Interfaces;
using ConexaoBancoDados.Utilitarios;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class ClienteDAO : IDao<Cliente>
    {
        public void Create(Cliente cliente)
        {
            try
            {
                string sql = @"INSERT INTO Cliente (nome, email, cpf, telefone) 
                               VALUES (@nome, @email, @cpf, @telefone)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                string sql = @"UPDATE Cliente 
                               SET nome = @nome, email = @email, cpf = @cpf, telefone = @telefone 
                               WHERE id_cliente = @id_cliente";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.Id_cliente);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_cliente).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id_cliente)
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE id_cliente = @id_cliente";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    var linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                        throw new Exception("Nenhum registro foi encontrado com esse ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                string sql = "SELECT * FROM Cliente ORDER BY nome";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cliente c = new Cliente();
                        c.Id_cliente = dr.GetInt32("id_cliente");
                        c.Nome = dr.GetString("nome");
                        c.Email = dr.GetString("email");
                        c.Cpf = dr.GetString("cpf");
                        c.Telefone = dr.GetString("telefone");
                        listaClientes.Add(c);
                    }
                }
                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
