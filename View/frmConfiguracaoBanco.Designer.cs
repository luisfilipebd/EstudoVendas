namespace EstudoVendas.View
{
    partial class FrmConfiguracaoBanco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CbTipoBanco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBancoDados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPorta = new System.Windows.Forms.TextBox();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnTestarConexao = new System.Windows.Forms.Button();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CbTipoBanco
            // 
            this.CbTipoBanco.FormattingEnabled = true;
            this.CbTipoBanco.Items.AddRange(new object[] {
            "Microsoft SQL Server",
            "MariaDB",
            "MySQL",
            "PostgreSQL",
            "Firebird",
            "SQLite"});
            this.CbTipoBanco.Location = new System.Drawing.Point(12, 25);
            this.CbTipoBanco.Name = "CbTipoBanco";
            this.CbTipoBanco.Size = new System.Drawing.Size(300, 21);
            this.CbTipoBanco.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Servidor/Instância";
            // 
            // TxtServidor
            // 
            this.TxtServidor.Location = new System.Drawing.Point(12, 65);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(300, 20);
            this.TxtServidor.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Banco de Dados";
            // 
            // TxtBancoDados
            // 
            this.TxtBancoDados.Location = new System.Drawing.Point(12, 104);
            this.TxtBancoDados.Name = "TxtBancoDados";
            this.TxtBancoDados.Size = new System.Drawing.Size(300, 20);
            this.TxtBancoDados.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Porta";
            // 
            // TxtPorta
            // 
            this.TxtPorta.Location = new System.Drawing.Point(12, 143);
            this.TxtPorta.Name = "TxtPorta";
            this.TxtPorta.Size = new System.Drawing.Size(50, 20);
            this.TxtPorta.TabIndex = 4;
            this.TxtPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPorta_KeyPress);
            this.TxtPorta.Leave += new System.EventHandler(this.TxtPorta_Leave);
            // 
            // TxtSenha
            // 
            this.TxtSenha.Location = new System.Drawing.Point(197, 143);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(115, 20);
            this.TxtSenha.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Senha";
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(237, 169);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvar.TabIndex = 8;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnTestarConexao
            // 
            this.BtnTestarConexao.Location = new System.Drawing.Point(127, 169);
            this.BtnTestarConexao.Name = "BtnTestarConexao";
            this.BtnTestarConexao.Size = new System.Drawing.Size(104, 23);
            this.BtnTestarConexao.TabIndex = 7;
            this.BtnTestarConexao.Text = "Testar Conexão";
            this.BtnTestarConexao.UseVisualStyleBackColor = true;
            this.BtnTestarConexao.Click += new System.EventHandler(this.BtnTestarConexao_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(68, 143);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(115, 20);
            this.TxtUsuario.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Usuário";
            // 
            // FrmConfiguracaoBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 204);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnTestarConexao);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtPorta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtBancoDados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbTipoBanco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracaoBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Acesso ao Banco";
            this.Load += new System.EventHandler(this.FrmConfiguracaoBanco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbTipoBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtServidor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBancoDados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPorta;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnTestarConexao;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label6;
    }
}