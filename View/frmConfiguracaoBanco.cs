using EstudoVendas.Conexao;
using EstudoVendas.Controller;
using EstudoVendas.LFRGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EstudoVendas.Conexao.DbConstante;
using static EstudoVendas.LFRGlobal.LFRConstante.Message;
using static EstudoVendas.LFRGlobal.EnumExtensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EstudoVendas.View
{
    public partial class FrmConfiguracaoBanco : Form
    {
        public FrmConfiguracaoBanco()
        {
            InitializeComponent();
        }

        private void BtnTestarConexao_Click(object sender, EventArgs e)
        {
            if (DbConnection.Connected(DbConnection.GetConnection(DBManagement.MSSQL)))
            {
                MessageBox.Show(CONEXAO_ESTABELECIDA, sTitInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(CONEXAO_FALHA, sTitWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            DBManagement Tipo = (DBManagement)CbTipoBanco.SelectedIndex;

            Controller.Login Funcao = new Controller.Login();
            Model.Login Dados = new Model.Login
            {
                TipoBanco = Tipo.GetDescriptionAttribute(),
                Servidor = TxtServidor.Text,
                BancoDados = TxtBancoDados.Text,
                Porta = Convert.ToInt32(TxtPorta.Text),
                Usuario = TxtUsuario.Text,
                Senha = TxtSenha.Text
            };

            if (Funcao.SalvarConfiguracao(Dados))
            {
                Close();
            }
        }

        private void CbBancoDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbTipoBanco.SelectedIndex == 0)
            {
                TxtPorta.Enabled = false;
                TxtPorta.Clear();
            }
        }
        private void TxtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPorta_Leave(object sender, EventArgs e)
        {
            if (TxtPorta.Text == "") {
                TxtPorta.Text = "0";
            }
        }
    }
}