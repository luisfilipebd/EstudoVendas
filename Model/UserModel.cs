using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoVendas.Model
{
    public class UserModel
    {
        public string TipoBanco;
        public string Servidor;
        public string BancoDados;
        public int Porta;
        public string Usuario;
        public string Senha;

//        public string ObterComandoValidarLogin()
//        {
//            string sql = "SELECT COUNT(0)" + Environment.NewLine +
//                         "FROM User" + Environment.NewLine +
//                         "WHERE User = @user" + Environment.NewLine +
//                         "  AND Password = @password" + Environment.NewLine +
//                         "  AND Inactive = 'N'";
//            return sql;
//        }

        internal class ObterComandoValidarLogin
        {
        }
    }
}