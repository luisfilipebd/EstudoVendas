using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using static EstudoVendas.Conexao.DbConstante;
using static EstudoVendas.LFRGlobal.LFRImutavel;

namespace EstudoVendas.Conexao
{
    public class DbConnection
    {
        private static string GetConncetionString()
        {
            //ConfigIni Ini = new ConfigIni(PathConfig.PATH_CONFIG + ARQUIVO_CONFIG);

            //return string.Format(CONNECTION_STRING_MSSQL,
            //                     Ini.GetString(SECAO_BANCO_DADOS, CONFIG_SERVER),
            //                     Ini.GetString(SECAO_BANCO_DADOS, CONFIG_USER_NAME),
            //                     Ini.GetString(SECAO_BANCO_DADOS, CONFIG_PASSWORD),
            //                     Ini.GetString(SECAO_BANCO_DADOS, COFING_DATABASE));

            return string.Format(CONNECTION_STRING_MSSQL,
                                 ArqConfig.SERVER,
                                 ArqConfig.USER_NAME,
                                 ArqConfig.PASSWORD,
                                 ArqConfig.DATABASE);
        }

        public static IDbConnection GetConnection(DBManagement TypeDB)
        {
            switch(TypeDB)
            {
                case DBManagement.MSSQL:
                    return GetConnMSSQL(GetConncetionString());
                case DBManagement.MariaDB:
                    return null;
                case DBManagement.MySQL:
                    return null;
                case DBManagement.PostgreSQL:
                    return null;
                case DBManagement.Firebird:
                    return null;
                case DBManagement.SQLite:
                    return GetConnSQLite(GetConncetionString());
                default:
                    return null;
            }
        }
        public static SqlConnection GetConnMSSQL(string connString)
        {
            SqlConnection myConn = new SqlConnection(connString);
            try
            {
                return myConn;
            }
            catch (Exception ex)
            {
                throw new Exception(CONEXAO_PERDA + ex.Message);
            }
        }
        public static SqliteConnection GetConnSQLite(string connString)
        {
            SqliteConnection myConn = new SqliteConnection(connString);
            try
            {
                return myConn;
            }
            catch (Exception ex)
            {
                throw new Exception(CONEXAO_PERDA + LINE_BREAK + MSG_ERRO + ex.Message);
            }
        }
        public static bool Connected(IDbConnection con)
        {
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}