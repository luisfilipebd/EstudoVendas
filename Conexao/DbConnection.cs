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
        private static string GetConncetionStringTest(DBManagement typeDB, string server, string userName, string password, string database)
        {
            return string.Format(GetConncetionConstant(typeDB),
                                 server,
                                 userName,
                                 password,
                                 database);
        }

        private static string GetConncetionString(DBManagement typeDB)
        {
            return string.Format(GetConncetionConstant(typeDB),
                                 ArqConfig.SERVER,
                                 ArqConfig.USER_NAME,
                                 ArqConfig.PASSWORD,
                                 ArqConfig.DATABASE);
        }

        public static IDbConnection GetConnectionTest(DBManagement typeDB, string server, string userName, string password, string database)
        {
            switch (typeDB)
            {
                case DBManagement.MSSQL:
                    return GetConnMSSQL(GetConncetionStringTest(typeDB, server, userName, password, database));
                case DBManagement.MariaDB:
                    return null;
                case DBManagement.MySQL:
                    return null;
                case DBManagement.PostgreSQL:
                    return null;
                case DBManagement.Firebird:
                    return null;
                case DBManagement.SQLite:
                    return GetConnSQLite(GetConncetionStringTest(typeDB, server, userName, password, database));
                default:
                    return null;
            }
        }

        public static IDbConnection GetConnection(DBManagement typeDB)
        {
            switch(typeDB)
            {
                case DBManagement.MSSQL:
                    return GetConnMSSQL(GetConncetionString(typeDB));
                case DBManagement.MariaDB:
                    return null;
                case DBManagement.MySQL:
                    return null;
                case DBManagement.PostgreSQL:
                    return null;
                case DBManagement.Firebird:
                    return null;
                case DBManagement.SQLite:
                    return GetConnSQLite(GetConncetionString(typeDB));
                default:
                    return null;
            }
        }

        public static string GetConncetionConstant(DBManagement typeDB)
        {
            switch (typeDB)
            {
                case DBManagement.MSSQL:
                    return CONNECTION_STRING_MSSQL;
                case DBManagement.MariaDB:
                    return null;
                case DBManagement.MySQL:
                    return null;
                case DBManagement.PostgreSQL:
                    return null;
                case DBManagement.Firebird:
                    return null;
                case DBManagement.SQLite:
                    return null;
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