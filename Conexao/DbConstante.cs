using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EstudoVendas.Conexao
{
    public enum DBManagement
    {
        [Description("MSSQL")]
        MSSQL = 0,
        [Description("MariaDB")]
        MariaDB = 1,
        [Description("MySQL")]
        MySQL = 2,
        [Description("PostgreSQL")]
        PostgreSQL = 3,
        [Description("Firebird")]
        Firebird = 4,
        [Description("SQLite")]
        SQLite = 5
    }
    public static class DbConstante
    {
        public const string CONEXAO_ESTABELECIDA = "Conexão Estabelecida com Sucesso!";
        public const string CONEXAO_FALHA = "Não foi Possível Estabelecer Conexão!";
        public const string CONEXAO_PERDA = "O sistema atual perdeu a conexão com o servidor de banco de dados. Por favor cheque novamente! Erro: ";
        public const string CONNECTION_STRING_MSSQL = "Data Source={0};User ID={1};Password={2};Initial Catalog={3}";
        public const string SECAO_BANCO_DADOS = "BANCO_DADOS";
        public const string CONFIG_TYPE_DATABASE = "Type";
        public const string CONFIG_SERVER = "Server";
        public const string CONFIG_USER_NAME = "UserName";
        public const string CONFIG_PASSWORD = "Password";
        public const string COFING_DATABASE = "Database";
        public const string CONFIG_PORT = "Port";
        public const string ARQUIVO_CONFIG = "Config.ini";
        public const string LINE_BREAK = "\r\n";
        public const string MSG_ERRO = "Erro: ";
    }
}
