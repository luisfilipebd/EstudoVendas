using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstudoVendas.Conexao;
using EstudoVendas.LFRGlobal;
using static EstudoVendas.Conexao.DbConstante;
using static EstudoVendas.LFRGlobal.LFRConstante.Message;

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
            if ((TxtUsuario.Text == "Admin") && (TxtSenha.Text == "Admin"))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}