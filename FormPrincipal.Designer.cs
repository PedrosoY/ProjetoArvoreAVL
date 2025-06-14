namespace ProjetoArvoreAVL
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBoxOperacoes = new GroupBox();
            btnLerArquivoTxT = new Button();
            labelValor = new Label();
            txtValor = new TextBox();
            btnInserir = new Button();
            btnRemover = new Button();
            btnBuscar = new Button();
            btnPreOrdem = new Button();
            btnFatores = new Button();
            btnAltura = new Button();
            groupBoxVisualizacao = new GroupBox();
            panelDesenho = new Panel();
            dataGridViewLog = new DataGridView();
            colComando = new DataGridViewTextBoxColumn();
            colResultado = new DataGridViewTextBoxColumn();
            PanelCodigoAtual = new Panel();
            txtBoxLinhasCodigoAtual = new TextBox();
            groupBoxOperacoes.SuspendLayout();
            groupBoxVisualizacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLog).BeginInit();
            PanelCodigoAtual.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxOperacoes
            // 
            groupBoxOperacoes.BackColor = Color.FromArgb(45, 45, 45);
            groupBoxOperacoes.Controls.Add(btnLerArquivoTxT);
            groupBoxOperacoes.Controls.Add(labelValor);
            groupBoxOperacoes.Controls.Add(txtValor);
            groupBoxOperacoes.Controls.Add(btnInserir);
            groupBoxOperacoes.Controls.Add(btnRemover);
            groupBoxOperacoes.Controls.Add(btnBuscar);
            groupBoxOperacoes.Controls.Add(btnPreOrdem);
            groupBoxOperacoes.Controls.Add(btnFatores);
            groupBoxOperacoes.Controls.Add(btnAltura);
            groupBoxOperacoes.ForeColor = Color.White;
            groupBoxOperacoes.Location = new Point(12, 12);
            groupBoxOperacoes.Name = "groupBoxOperacoes";
            groupBoxOperacoes.Size = new Size(350, 269);
            groupBoxOperacoes.TabIndex = 0;
            groupBoxOperacoes.TabStop = false;
            groupBoxOperacoes.Text = "Operações na Árvore AVL";
            // 
            // btnLerArquivoTxT
            // 
            btnLerArquivoTxT.BackColor = Color.FromArgb(70, 70, 70);
            btnLerArquivoTxT.FlatStyle = FlatStyle.Flat;
            btnLerArquivoTxT.ForeColor = Color.White;
            btnLerArquivoTxT.Location = new Point(16, 217);
            btnLerArquivoTxT.Name = "btnLerArquivoTxT";
            btnLerArquivoTxT.Size = new Size(316, 43);
            btnLerArquivoTxT.TabIndex = 8;
            btnLerArquivoTxT.Text = "Ler Arquivo TxT";
            btnLerArquivoTxT.UseVisualStyleBackColor = false;
            btnLerArquivoTxT.Click += btnLerArquivoTxT_Click;
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new Point(16, 30);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(36, 15);
            labelValor.TabIndex = 0;
            labelValor.Text = "Valor:";
            // 
            // txtValor
            // 
            txtValor.BackColor = Color.FromArgb(60, 60, 60);
            txtValor.ForeColor = Color.White;
            txtValor.Location = new Point(58, 27);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(274, 23);
            txtValor.TabIndex = 1;
            // 
            // btnInserir
            // 
            btnInserir.BackColor = Color.FromArgb(70, 70, 70);
            btnInserir.FlatStyle = FlatStyle.Flat;
            btnInserir.ForeColor = Color.White;
            btnInserir.Location = new Point(16, 70);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(150, 43);
            btnInserir.TabIndex = 2;
            btnInserir.Text = "Inserir";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.FromArgb(70, 70, 70);
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.ForeColor = Color.White;
            btnRemover.Location = new Point(182, 70);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(150, 43);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(70, 70, 70);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(16, 119);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(150, 43);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnPreOrdem
            // 
            btnPreOrdem.BackColor = Color.FromArgb(70, 70, 70);
            btnPreOrdem.FlatStyle = FlatStyle.Flat;
            btnPreOrdem.ForeColor = Color.White;
            btnPreOrdem.Location = new Point(182, 119);
            btnPreOrdem.Name = "btnPreOrdem";
            btnPreOrdem.Size = new Size(150, 43);
            btnPreOrdem.TabIndex = 5;
            btnPreOrdem.Text = "Pré-Ordem";
            btnPreOrdem.UseVisualStyleBackColor = false;
            btnPreOrdem.Click += btnPreOrdem_Click;
            // 
            // btnFatores
            // 
            btnFatores.BackColor = Color.FromArgb(70, 70, 70);
            btnFatores.FlatStyle = FlatStyle.Flat;
            btnFatores.ForeColor = Color.White;
            btnFatores.Location = new Point(16, 168);
            btnFatores.Name = "btnFatores";
            btnFatores.Size = new Size(150, 43);
            btnFatores.TabIndex = 6;
            btnFatores.Text = "Fatores de Balanceamento";
            btnFatores.UseVisualStyleBackColor = false;
            btnFatores.Click += btnFatores_Click;
            // 
            // btnAltura
            // 
            btnAltura.BackColor = Color.FromArgb(70, 70, 70);
            btnAltura.FlatStyle = FlatStyle.Flat;
            btnAltura.ForeColor = Color.White;
            btnAltura.Location = new Point(182, 168);
            btnAltura.Name = "btnAltura";
            btnAltura.Size = new Size(150, 43);
            btnAltura.TabIndex = 7;
            btnAltura.Text = "Altura da Árvore";
            btnAltura.UseVisualStyleBackColor = false;
            btnAltura.Click += btnAltura_Click;
            // 
            // groupBoxVisualizacao
            // 
            groupBoxVisualizacao.BackColor = Color.FromArgb(45, 45, 45);
            groupBoxVisualizacao.Controls.Add(panelDesenho);
            groupBoxVisualizacao.Controls.Add(dataGridViewLog);
            groupBoxVisualizacao.ForeColor = Color.White;
            groupBoxVisualizacao.Location = new Point(378, 12);
            groupBoxVisualizacao.Name = "groupBoxVisualizacao";
            groupBoxVisualizacao.Size = new Size(780, 576);
            groupBoxVisualizacao.TabIndex = 1;
            groupBoxVisualizacao.TabStop = false;
            groupBoxVisualizacao.Text = "Visualização da Árvore e Log";
            // 
            // panelDesenho
            // 
            panelDesenho.BackColor = Color.FromArgb(60, 60, 60);
            panelDesenho.Location = new Point(16, 27);
            panelDesenho.Name = "panelDesenho";
            panelDesenho.Size = new Size(748, 300);
            panelDesenho.TabIndex = 0;
            panelDesenho.Paint += panelDesenho_Paint;
            // 
            // dataGridViewLog
            // 
            dataGridViewLog.BackgroundColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewLog.Columns.AddRange(new DataGridViewColumn[] { colComando, colResultado });
            dataGridViewLog.EnableHeadersVisualStyles = false;
            dataGridViewLog.GridColor = Color.Black;
            dataGridViewLog.Location = new Point(16, 333);
            dataGridViewLog.Name = "dataGridViewLog";
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewLog.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewLog.RowTemplate.ReadOnly = true;
            dataGridViewLog.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewLog.Size = new Size(748, 233);
            dataGridViewLog.TabIndex = 1;
            // 
            // colComando
            // 
            colComando.HeaderText = "Comando";
            colComando.Name = "colComando";
            colComando.ReadOnly = true;
            colComando.Width = 150;
            // 
            // colResultado
            // 
            colResultado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colResultado.HeaderText = "Resultado";
            colResultado.Name = "colResultado";
            colResultado.ReadOnly = true;
            // 
            // PanelCodigoAtual
            // 
            PanelCodigoAtual.BackColor = Color.FromArgb(45, 45, 45);
            PanelCodigoAtual.Controls.Add(txtBoxLinhasCodigoAtual);
            PanelCodigoAtual.Location = new Point(12, 288);
            PanelCodigoAtual.Name = "PanelCodigoAtual";
            PanelCodigoAtual.Size = new Size(350, 301);
            PanelCodigoAtual.TabIndex = 2;
            // 
            // txtBoxLinhasCodigoAtual
            // 
            txtBoxLinhasCodigoAtual.Location = new Point(16, 7);
            txtBoxLinhasCodigoAtual.Multiline = true;
            txtBoxLinhasCodigoAtual.Name = "txtBoxLinhasCodigoAtual";
            txtBoxLinhasCodigoAtual.Size = new Size(316, 284);
            txtBoxLinhasCodigoAtual.TabIndex = 0;
            txtBoxLinhasCodigoAtual.TextChanged += txtBoxLinhasCodigoAtual_TextChanged;
            // 
            // FormPrincipal
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1169, 601);
            Controls.Add(PanelCodigoAtual);
            Controls.Add(groupBoxOperacoes);
            Controls.Add(groupBoxVisualizacao);
            ForeColor = Color.White;
            MinimumSize = new Size(1185, 640);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Árvore AVL";
            groupBoxOperacoes.ResumeLayout(false);
            groupBoxOperacoes.PerformLayout();
            groupBoxVisualizacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewLog).EndInit();
            PanelCodigoAtual.ResumeLayout(false);
            PanelCodigoAtual.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxOperacoes;
        private Label labelValor;
        private TextBox txtValor;
        private Button btnInserir;
        private Button btnRemover;
        private Button btnBuscar;
        private Button btnPreOrdem;
        private Button btnFatores;
        private Button btnAltura;
        private Button btnLerArquivoTxT;

        private GroupBox groupBoxVisualizacao;
        private Panel panelDesenho;
        private DataGridView dataGridViewLog;
        private DataGridViewTextBoxColumn colComando;
        private DataGridViewTextBoxColumn colResultado;

        private Panel PanelCodigoAtual;
        private TextBox txtBoxLinhasCodigoAtual;
    }
}
