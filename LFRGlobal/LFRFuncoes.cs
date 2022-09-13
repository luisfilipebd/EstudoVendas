using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EstudoVendas.Conexao.DbConstante;

namespace EstudoVendas.LFRGlobal
{
    public static class EnumExtensions
    {
        public static string GetDescriptionAttribute(this Enum value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                    ? ((DescriptionAttribute)attributes[0]).Description
                    : value.ToString();
        }
    }

    public class LFRFuncoes
    {        
        public static void GetArchiveConfig()
        {
            ConfigIni Ini = new ConfigIni(PathConfig.PATH_CONFIG + ARQUIVO_CONFIG);

            ArqConfig.GetArqConfig(Conexao.DBManagement.MSSQL,
                                   Ini.GetString(SECAO_BANCO_DADOS, CONFIG_TYPE_DATABASE),
                                   Ini.GetString(SECAO_BANCO_DADOS, CONFIG_SERVER),
                                   Ini.GetString(SECAO_BANCO_DADOS, CONFIG_USER_NAME),
                                   Ini.GetString(SECAO_BANCO_DADOS, CONFIG_PASSWORD),
                                   Ini.GetString(SECAO_BANCO_DADOS, COFING_DATABASE),
                                   Ini.GetString(SECAO_BANCO_DADOS, CONFIG_PORT));
        }
    }
}
