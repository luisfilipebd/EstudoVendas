using EstudoVendas.Conexao;
using EstudoVendas.LFRGlobal;
using System;
using System.Windows.Forms;
using static EstudoVendas.Conexao.DbConstante;
using static EstudoVendas.LFRGlobal.LFRConstante.Message;
using static EstudoVendas.LFRGlobal.EnumExtensions;
using static EstudoVendas.LFRGlobal.LFRImutavel;

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
            DBManagement Tipo = (DBManagement)CbTipoBanco.SelectedIndex;

            if (DbConnection.Connected(DbConnection.GetConnectionTest(Tipo,
                                                                      TxtServidor.Text,
                                                                      TxtUsuario.Text,
                                                                      TxtSenha.Text,
                                                                      TxtBancoDados.Text)))
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

            Controller.UserControl Funcao = new Controller.UserControl();
            Model.UserModel Dados = new Model.UserModel
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
            if (String.IsNullOrEmpty(TxtPorta.Text)) {
                TxtPorta.Text = "0";
            }
        }

        private void FrmConfiguracaoBanco_Load(object sender, EventArgs e)
        {
            CbTipoBanco.SelectedIndex = (int)ArqConfig.TYPE;
            TxtBancoDados.Text = ArqConfig.DATABASE;
            TxtPorta.Text = ArqConfig.PORT;
            TxtSenha.Text = ArqConfig.PASSWORD;
            TxtServidor.Text = ArqConfig.SERVER;
            TxtUsuario.Text = ArqConfig.USER_NAME;
        }
    }
}