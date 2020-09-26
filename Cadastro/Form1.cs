using Cadastro.BLL;
using Cadastro.DAL;
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
    public partial class Form1 : Form
    {
        GerenciadorCadastros cadastro = new GerenciadorCadastros();


        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha os campos!");
            } else
            {
                bool validar = cadastro.ValidarUsuario(usuario, senha);
                if (validar)
                {
                    MessageBox.Show("OK");
                } else
                {
                    MessageBox.Show("Inválido!");
                }
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
