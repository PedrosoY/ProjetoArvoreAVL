using System.ComponentModel;

namespace ProjetoArvoreAVL
{
    partial class FormularioPrincipal
    {
        private GroupBox groupBoxOperacoes;
        private Button btnCarregarArquivo;
        private Label lblValorNo;
        private TextBox txtValorNo;
        private Button btnAdicionar;
        private Button btnRemover;
        private Button btnBuscar;
        private Button btnPreOrdem;
        private Button btnBalanceamento;
        private Button btnAltura;

        private GroupBox groupBoxVisualizacao;
        private Panel panelHistorico;
        private Button btnPrevStep;
        private Button btnNextStep;
        private Label lblIndicador;
        private DataGridView dataGridViewLog;
        private DataGridViewTextBoxColumn colAcao;
        private DataGridViewTextBoxColumn colResultado;

        private Panel panelComandos;
        private TextBox txtHistoricoComandos;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBoxOperacoes = new GroupBox();
            btnCarregarArquivo = new Button();
            lblValorNo = new Label();
            txtValorNo = new TextBox();
            btnAdicionar = new Button();
            btnRemover = new Button();
            btnBuscar = new Button();
            btnPreOrdem = new Button();
            btnBalanceamento = new Button();
            btnAltura = new Button();
            groupBoxVisualizacao = new GroupBox();
            panelHistorico = new Panel();
            btnCenter = new Button();
            btnPrevStep = new Button();
            lblIndicador = new Label();
            btnNextStep = new Button();
            dataGridViewLog = new DataGridView();
            colAcao = new DataGridViewTextBoxColumn();
            colResultado = new DataGridViewTextBoxColumn();
            panelComandos = new Panel();
            txtHistoricoComandos = new TextBox();
            groupBoxOperacoes.SuspendLayout();
            groupBoxVisualizacao.SuspendLayout();
            panelHistorico.SuspendLayout();
            ((ISupportInitialize)dataGridViewLog).BeginInit();
            panelComandos.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxOperacoes
            // 
            groupBoxOperacoes.BackColor = Color.FromArgb(45, 45, 45);
            groupBoxOperacoes.Controls.Add(btnCarregarArquivo);
            groupBoxOperacoes.Controls.Add(lblValorNo);
            groupBoxOperacoes.Controls.Add(txtValorNo);
            groupBoxOperacoes.Controls.Add(btnAdicionar);
            groupBoxOperacoes.Controls.Add(btnRemover);
            groupBoxOperacoes.Controls.Add(btnBuscar);
            groupBoxOperacoes.Controls.Add(btnPreOrdem);
            groupBoxOperacoes.Controls.Add(btnBalanceamento);
            groupBoxOperacoes.Controls.Add(btnAltura);
            groupBoxOperacoes.ForeColor = Color.White;
            groupBoxOperacoes.Location = new Point(12, 12);
            groupBoxOperacoes.Name = "groupBoxOperacoes";
            groupBoxOperacoes.Size = new Size(350, 269);
            groupBoxOperacoes.TabIndex = 0;
            groupBoxOperacoes.TabStop = false;
            groupBoxOperacoes.Text = "Operações na Árvore AVL";
            // 
            // btnCarregarArquivo
            // 
            btnCarregarArquivo.BackColor = Color.FromArgb(70, 70, 70);
            btnCarregarArquivo.FlatStyle = FlatStyle.Flat;
            btnCarregarArquivo.ForeColor = Color.White;
            btnCarregarArquivo.Location = new Point(16, 217);
            btnCarregarArquivo.Name = "btnCarregarArquivo";
            btnCarregarArquivo.Size = new Size(316, 43);
            btnCarregarArquivo.TabIndex = 8;
            btnCarregarArquivo.Text = "Carregar Arquivo";
            btnCarregarArquivo.UseVisualStyleBackColor = false;
            btnCarregarArquivo.Click += btnCarregarArquivo_Click;
            // 
            // lblValorNo
            // 
            lblValorNo.AutoSize = true;
            lblValorNo.Location = new Point(16, 30);
            lblValorNo.Name = "lblValorNo";
            lblValorNo.Size = new Size(36, 15);
            lblValorNo.TabIndex = 0;
            lblValorNo.Text = "Valor:";
            // 
            // txtValorNo
            // 
            txtValorNo.BackColor = Color.FromArgb(60, 60, 60);
            txtValorNo.ForeColor = Color.White;
            txtValorNo.Location = new Point(62, 27);
            txtValorNo.Name = "txtValorNo";
            txtValorNo.Size = new Size(274, 23);
            txtValorNo.TabIndex = 1;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(70, 70, 70);
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.Location = new Point(16, 70);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(150, 43);
            btnAdicionar.TabIndex = 2;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
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
            // btnBalanceamento
            // 
            btnBalanceamento.BackColor = Color.FromArgb(70, 70, 70);
            btnBalanceamento.FlatStyle = FlatStyle.Flat;
            btnBalanceamento.ForeColor = Color.White;
            btnBalanceamento.Location = new Point(16, 168);
            btnBalanceamento.Name = "btnBalanceamento";
            btnBalanceamento.Size = new Size(150, 43);
            btnBalanceamento.TabIndex = 6;
            btnBalanceamento.Text = "Balanceamento";
            btnBalanceamento.UseVisualStyleBackColor = false;
            btnBalanceamento.Click += btnBalanceamento_Click;
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
            btnAltura.Text = "Altura";
            btnAltura.UseVisualStyleBackColor = false;
            btnAltura.Click += btnAltura_Click;
            // 
            // groupBoxVisualizacao
            // 
            groupBoxVisualizacao.BackColor = Color.FromArgb(45, 45, 45);
            groupBoxVisualizacao.Controls.Add(panelHistorico);
            groupBoxVisualizacao.Controls.Add(dataGridViewLog);
            groupBoxVisualizacao.ForeColor = Color.White;
            groupBoxVisualizacao.Location = new Point(378, 12);
            groupBoxVisualizacao.Name = "groupBoxVisualizacao";
            groupBoxVisualizacao.Size = new Size(780, 576);
            groupBoxVisualizacao.TabIndex = 1;
            groupBoxVisualizacao.TabStop = false;
            groupBoxVisualizacao.Text = "Visualização";
            // 
            // panelHistorico
            // 
            panelHistorico.BackColor = Color.FromArgb(50, 50, 50);
            panelHistorico.Controls.Add(btnCenter);
            panelHistorico.Controls.Add(btnPrevStep);
            panelHistorico.Controls.Add(lblIndicador);
            panelHistorico.Controls.Add(btnNextStep);
            panelHistorico.Location = new Point(16, 30);
            panelHistorico.Name = "panelHistorico";
            panelHistorico.Size = new Size(750, 368);
            panelHistorico.TabIndex = 1;
            panelHistorico.Paint += panelHistorico_Paint;
            panelHistorico.MouseDown += PanelHistorico_MouseDown;
            panelHistorico.MouseEnter += panelHistorico_MouseEnter;
            panelHistorico.MouseMove += PanelHistorico_MouseMove;
            panelHistorico.MouseUp += PanelHistorico_MouseUp;
            panelHistorico.MouseWheel += PanelHistorico_MouseWheel;
            // 
            // btnCenter
            // 
            btnCenter.BackColor = Color.FromArgb(70, 70, 70);
            btnCenter.FlatStyle = FlatStyle.Flat;
            btnCenter.ForeColor = Color.White;
            btnCenter.Location = new Point(0, 207);
            btnCenter.Name = "btnCenter";
            btnCenter.Size = new Size(40, 40);
            btnCenter.TabIndex = 5;
            btnCenter.Text = "x";
            btnCenter.UseVisualStyleBackColor = false;
            btnCenter.Click += btnCenter_Click;
            // 
            // btnPrevStep
            // 
            btnPrevStep.BackColor = Color.FromArgb(70, 70, 70);
            btnPrevStep.FlatStyle = FlatStyle.Flat;
            btnPrevStep.ForeColor = Color.White;
            btnPrevStep.Location = new Point(0, 115);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new Size(40, 40);
            btnPrevStep.TabIndex = 2;
            btnPrevStep.Text = "<";
            btnPrevStep.UseVisualStyleBackColor = false;
            btnPrevStep.Click += btnPrevStep_Click;
            // 
            // lblIndicador
            // 
            lblIndicador.AutoSize = true;
            lblIndicador.ForeColor = Color.White;
            lblIndicador.Location = new Point(350, 5);
            lblIndicador.Name = "lblIndicador";
            lblIndicador.Size = new Size(24, 15);
            lblIndicador.TabIndex = 3;
            lblIndicador.Text = "0/0";
            // 
            // btnNextStep
            // 
            btnNextStep.BackColor = Color.FromArgb(70, 70, 70);
            btnNextStep.FlatStyle = FlatStyle.Flat;
            btnNextStep.ForeColor = Color.White;
            btnNextStep.Location = new Point(0, 161);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new Size(40, 40);
            btnNextStep.TabIndex = 4;
            btnNextStep.Text = ">";
            btnNextStep.UseVisualStyleBackColor = false;
            btnNextStep.Click += btnNextStep_Click;
            // 
            // dataGridViewLog
            // 
            dataGridViewLog.BackgroundColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewLog.Columns.AddRange(new DataGridViewColumn[] { colAcao, colResultado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewLog.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewLog.EnableHeadersVisualStyles = false;
            dataGridViewLog.GridColor = Color.Black;
            dataGridViewLog.Location = new Point(16, 404);
            dataGridViewLog.Name = "dataGridViewLog";
            dataGridViewLog.ReadOnly = true;
            dataGridViewLog.RowTemplate.ReadOnly = true;
            dataGridViewLog.Size = new Size(750, 163);
            dataGridViewLog.TabIndex = 5;
            // 
            // colAcao
            // 
            colAcao.HeaderText = "Ação";
            colAcao.Name = "colAcao";
            colAcao.ReadOnly = true;
            colAcao.Width = 150;
            // 
            // colResultado
            // 
            colResultado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colResultado.HeaderText = "Resultado";
            colResultado.Name = "colResultado";
            colResultado.ReadOnly = true;
            // 
            // panelComandos
            // 
            panelComandos.BackColor = Color.FromArgb(45, 45, 45);
            panelComandos.Controls.Add(txtHistoricoComandos);
            panelComandos.Location = new Point(12, 288);
            panelComandos.Name = "panelComandos";
            panelComandos.Size = new Size(350, 301);
            panelComandos.TabIndex = 2;
            // 
            // txtHistoricoComandos
            // 
            txtHistoricoComandos.Location = new Point(16, 7);
            txtHistoricoComandos.Multiline = true;
            txtHistoricoComandos.Name = "txtHistoricoComandos";
            txtHistoricoComandos.ScrollBars = ScrollBars.Vertical;
            txtHistoricoComandos.Size = new Size(316, 284);
            txtHistoricoComandos.TabIndex = 0;
            txtHistoricoComandos.TextChanged += txtHistoricoComandos_TextChanged;
            // 
            // FormularioPrincipal
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1169, 601);
            Controls.Add(panelComandos);
            Controls.Add(groupBoxOperacoes);
            Controls.Add(groupBoxVisualizacao);
            ForeColor = Color.White;
            MinimumSize = new Size(1185, 640);
            Name = "FormularioPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Árvore AVL";
            groupBoxOperacoes.ResumeLayout(false);
            groupBoxOperacoes.PerformLayout();
            groupBoxVisualizacao.ResumeLayout(false);
            panelHistorico.ResumeLayout(false);
            panelHistorico.PerformLayout();
            ((ISupportInitialize)dataGridViewLog).EndInit();
            panelComandos.ResumeLayout(false);
            panelComandos.PerformLayout();
            ResumeLayout(false);
        }
        private Button btnCenter;
    }
}
