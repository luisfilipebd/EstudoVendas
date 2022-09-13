using EstudoVendas.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EstudoVendas.LFRGlobal
{
    internal class LFRConstante
    {
        public static class Message
        {
            public const string sTitInformation = "Informação";
            public const string sTitError = "Erro";
            public const string sTitWarning = "Aviso";
            public const string sTitQuestion = "Pergunta";
        }

        public const string FalhaLogin = "Usuário ou senha incorretos";
    }
}