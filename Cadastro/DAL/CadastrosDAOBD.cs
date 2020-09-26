using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro.DAL
{
    class CadastrosDAOBD : ICadastrosDAO
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
                //bool cadastro = VerificarUsuario(usuario);
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

        public bool ValidarUsuario(string usuario, string senha)
        {
            int i = 0;
            SqlConnection conn = conexao.AbrirConexao();
            if (conn != null)
            {
               
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(usuario) FROM Cadastro WHERE usuario = @usuario AND senha = @senha";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                
                i = (Int32)cmd.ExecuteScalar();

                if (i != 0)
                {
                    return true;
                }
            }
            conexao.FecharConexao();
            return false;
        }

       /* public bool VerificarUsuario(string usuario)
        {
            int i = 0;
            SqlConnection conn = conexao.AbrirConexao();
            if (conn != null)
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(usuario) FROM Cadastro WHERE usuario = @usuario";
                cmd.Parameters.AddWithValue("@usuario", usuario);

                i = (Int32)cmd.ExecuteScalar();

                if (i != 0)
                {
                    return true;
                }
            }
            conexao.FecharConexao();
            return false;
        }*/
    }
}
