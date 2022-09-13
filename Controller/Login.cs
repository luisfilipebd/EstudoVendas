using EstudoVendas.LFRGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EstudoVendas.LFRGlobal.LFRFuncoes;

namespace EstudoVendas.Controller
{
    internal class Login
    {
        public bool SalvarConfiguracao(Model.Login Dados)
        {
            return SetArchiveConfig(Dados.TipoBanco,
                                    Dados.Servidor,
                                    Dados.BancoDados,
                                    Dados.Porta,
                                    Dados.Usuario,
                                    Dados.Senha);
        }
    }
}
