using EstudoVendas.Conexao;

namespace EstudoVendas.LFRGlobal
{
    internal class LFRImutavel
    {
        public class PathConfig
        {
            public static string PATH_CONFIG { get; private set; }
            public PathConfig(string path)
            {
                PATH_CONFIG = path;
            }
            public static PathConfig GetPath(string path)
            {
                return new PathConfig(path);
            }
        }

        public class ArqConfig
        {
            public static DBManagement TYPE { get; private set; }
            public static string TYPE_DATABASE { get; private set; }
            public static string SERVER { get; private set; }
            public static string USER_NAME { get; private set; }
            public static string PASSWORD { get; private set; }
            public static string DATABASE { get; private set; }
            public static string PORT { get; private set; }

            public ArqConfig(DBManagement typeCon, string typeBase, string server, string userName, string password, string database, string port)
            {
                TYPE = typeCon;
                TYPE_DATABASE = typeBase;
                SERVER = server;
                USER_NAME = userName;
                PASSWORD = password;
                DATABASE = database;
                PORT = port;
            }

            public static ArqConfig GetArqConfig(DBManagement typeCon, string typeBase, string server, string userName, string password, string database, string port)
            {
                return new ArqConfig(typeCon, typeBase, server, userName, password, database, port);
            }
        }
    }
}