using EstudoVendas.LFRGlobal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EstudoVendas.LFRGlobal.LFRFuncoes;
using static EstudoVendas.Model.UserModel;



namespace EstudoVendas.Controller
{
    internal class UserControl
    {
        public bool SalvarConfiguracao(Model.UserModel Dados)
        {
            return SetArchiveConfig(Dados.TipoBanco,
                                    Dados.Servidor,
                                    Dados.BancoDados,
                                    Dados.Porta,
                                    Dados.Usuario,
                                    Dados.Senha);
        }

        public bool ValidarLogin(IDbConnection con, Model.UserModel Dados)
        {
            con.Open();

            return true;
        }
    }
}
