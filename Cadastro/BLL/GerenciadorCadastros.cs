using Cadastro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BLL
{
    class GerenciadorCadastros
    {
        private ICadastrosDAO Dao;

        public GerenciadorCadastros()
        {
            Dao = DAOFactory.CriarCadastrosDAO();
        }

        public bool Inserir(string email, string usuario, string senha)
        {
            return Dao.Inserir(email, usuario, senha);
        }

        public List<string> Listar()
        {
            return Dao.Listar();
        }
    }
}
