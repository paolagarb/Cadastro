using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro.DAL
{
    class ConexaoBD
    {
        private static SqlConnection conexao;

        public ConexaoBD()
        {
            if (conexao == null)
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cadastros.mdf;Integrated Security=True";
            }
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                if (conexao.State != ConnectionState.Open)
                {
                    conexao.Open();
                }
                return conexao;
            } catch (SqlException e)
            {
                Console.WriteLine($"Erro de conexão: {e}");
            }
            return null;
        }
        
        public bool FecharConexao()
        {
            try
            {
                conexao.Close();
                return true;
            } catch (SqlException e)
            {
                Console.WriteLine($"Erro ao fechar a conexão: {e}");
            }
            return false;
        }
    }
}
