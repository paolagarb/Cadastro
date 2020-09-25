using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.DAL
{
    class DAOFactory
    {
        public static ICadastrosDAO CriarCadastrosDAO()
        {
            return new CadastrosDAOBD();
        }
    }
}
