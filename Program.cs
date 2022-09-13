using System;
using System.IO;
using System.Windows.Forms;
using static EstudoVendas.Conexao.DbConstante;
using EstudoVendas.View;
using EstudoVendas.LFRGlobal;
using static EstudoVendas.LFRGlobal.LFRImutavel;

namespace EstudoVendas
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            PathConfig.GetPath(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\");

            if (!File.Exists(PathConfig.PATH_CONFIG + ARQUIVO_CONFIG))
            {
                Application.Run(new FrmConfiguracaoBanco());
            }
            LFRFuncoes.GetArchiveConfig();

            var form = new FrmLogin();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmPrincipal());
            }
        }
    }
}
