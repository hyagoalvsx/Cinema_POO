using MySql.Data.MySqlClient;

namespace ConexaoBancoDados.Utilitarios
{
    internal class Conexao
    {
        private const string strconexao =
            "server=localhost;port=3306;uid=root;pwd=HYAgo1311%;database=Cinema";

        public static MySqlConnection Conectar()
        {
            // cria um novo objeto de conexão usando a string de conexão DEFINIDA
            MySqlConnection conectar = new MySqlConnection(strconexao);
            try
            {
                // tenta abrir a conexão com banco de dados
                conectar.Open();
                return conectar;
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro ao conectar,lança a exceção
                throw new Exception(ex.Message);
            }
        }
    }
}
