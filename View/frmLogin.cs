using System;
using System.Windows.Forms;
using EstudoVendas.Conexao;
using static EstudoVendas.LFRGlobal.LFRConstante;
using static EstudoVendas.Conexao.DbConstante;
using static EstudoVendas.LFRGlobal.LFRConstante.Message;
using static EstudoVendas.LFRGlobal.LFRImutavel;
using EstudoVendas.View;

namespace EstudoVendas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void LblTestarConexao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DbConnection.Connected(DbConnection.GetConnection(ArqConfig.TYPE)))
            {
                MessageBox.Show(CONEXAO_ESTABELECIDA, sTitInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(CONEXAO_FALHA, sTitWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if ((TxtUsuario.Text.Equals("Admin")) && (TxtSenha.Text.Equals("Admin")))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(FalhaLogin, sTitWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new FrmConfiguracaoBanco();
            form.ShowDialog();
        }
    }
}