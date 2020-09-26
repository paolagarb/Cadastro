using Cadastro.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Cadastro : Form
    {
        GerenciadorCadastros cadastro = new GerenciadorCadastros();
        public Cadastro()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string email = txtUsuario.Text;
            string senha = txtSenha.Text;
            string senhaConfirmar = txtConfirmaSenha.Text;

            if (!(string.IsNullOrEmpty(usuario)) || !(string.IsNullOrEmpty(email)) || !(string.IsNullOrEmpty(senha)) || !(string.IsNullOrEmpty(senhaConfirmar)))
            {
                if (senha != senhaConfirmar)
                {
                    MessageBox.Show("As senhas não coincidem!");
                } else 
                {
                    cadastro.Inserir(email, usuario, senha);
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    txtEmail.Text = "";
                    txtConfirmaSenha.Text = "";
                    

                    /*Form1 login = new Form1();
                    login.Show();
                    this.Visible = false;*/
                }
            } else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }
    }
}
