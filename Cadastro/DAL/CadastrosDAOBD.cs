using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro.DAL
{
    class CadastrosDAOBD : ICadastroDAO
    {
        private ConexaoBD conexao;

        public CadastrosDAOBD()
        {
            conexao = new ConexaoBD();
        }

        public bool Inserir(string email, string usuario, string senha)
        {
            SqlConnection conn = conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Cadastro(email, usuario, senha) VALUES (@email, @usuario, @senha)";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.ExecuteNonQuery();
                conexao.FecharConexao();
                return true;
            }
            return false;
        }

        public List<string> Listar()
        {
            SqlConnection conn = conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT email, usuario, senha FROM Cadastro";
                SqlDataReader dados = cmd.ExecuteReader();

                List<string> cadastros = new List<string>();
                while (dados.Read())
                {
                    string cadastro = dados["cadastro"].ToString();
                    cadastros.Add(cadastro);
                }
                conexao.FecharConexao();
                return cadastros;
            }
            return null;
        }

    }
}
