using EstudoVendas.LFRGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EstudoVendas.Conexao.DbConstante;

namespace EstudoVendas.Controller
{
    internal class Login
    {
        public bool SalvarConfiguracao(Model.Login Dados)
        {
            using (ConfigIni ini = new ConfigIni(PathConfig.PATH_CONFIG + ARQUIVO_CONFIG))
            {
                ini.SetString(SECAO_BANCO_DADOS, CONFIG_TYPE_DATABASE, Dados.TipoBanco);
                ini.SetString(SECAO_BANCO_DADOS, CONFIG_SERVER, Dados.Servidor);
                ini.SetString(SECAO_BANCO_DADOS, COFING_DATABASE, Dados.BancoDados);
                ini.SetInt(SECAO_BANCO_DADOS, CONFIG_PORT, Dados.Porta);
                ini.SetString(SECAO_BANCO_DADOS, CONFIG_USER_NAME, Dados.Usuario);
                ini.SetString(SECAO_BANCO_DADOS, CONFIG_PASSWORD, Dados.Senha);
            }
            return true;
        }
    }
}
