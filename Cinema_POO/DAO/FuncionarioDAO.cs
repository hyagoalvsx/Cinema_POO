using Cinema_POO.Models;
using ConexaoBancoDados.Utilitarios;
using ConexaoBancoDados.Interfaces;
using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.DAO
{
    internal class FuncionarioDAO : IDao<Funcionario>
    {
        public void Create(Funcionario funcionario)
        {
            try
            {
                string sql = @"INSERT INTO Funcionario (nome, cpf, cargo,salario, data_admissao) 
                               VALUES (@nome, @cpf, @cargo, @salario, @data_admissao)";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                    cmd.Parameters.AddWithValue("@salario", funcionario.Salario);
                    cmd.Parameters.AddWithValue("@data_admissao", funcionario.Data_admissao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Funcionario funcionario)
        {
            try
            {
                string sql = @"UPDATE Funcionario 
                               SET nome = @nome, cpf = @cpf, cargo = @cargo, salario = @salario data_admissao = @data_admissao 
                               WHERE id_funcionario = @id_funcionario";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                    cmd.Parameters.AddWithValue("@salario", funcionario.Salario);
                    cmd.Parameters.AddWithValue("@data_admissao", funcionario.Data_admissao);
                    cmd.Parameters.AddWithValue("@id_funcionario", funcionario.Id_funcionario);

                    var linhas = cmd.ExecuteNonQuery();
                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o id_funcionario).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id_funcionario)
        {
            try
            {
                string sql = "DELETE FROM Funcionario WHERE id_funcionario = @id_funcionario";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                {
                    cmd.Parameters.AddWithValue("@id_funcionario", id_funcionario);
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

        public List<Funcionario> GetAll()
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                string sql = "SELECT * FROM Funcionario ORDER BY nome";
                using (var conectar = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conectar))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Funcionario f = new Funcionario
                        {
                            Id_funcionario = dr.GetInt32("id_funcionario"),
                            Nome = dr.GetString("nome"),
                            Cpf = dr.GetString("cpf"),
                            Cargo = dr.GetString("cargo"),
                            Salario = dr.GetDecimal("salario"),
                            Data_admissao = dr.GetDateTime("data_admissao")
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
