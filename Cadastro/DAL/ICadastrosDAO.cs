using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.DAL
{
    interface ICadastrosDAO
    {
        bool Inserir(string email, string usuario, string senha);
        List<string> Listar();
    }
}
