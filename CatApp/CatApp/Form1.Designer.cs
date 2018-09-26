namespace CatApp
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.alunosDataGridView = new System.Windows.Forms.DataGridView();
            this.alunosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database_alunosDataSet = new CatApp.Database_alunosDataSet();
            this.botaoadicionar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_mostraralunos = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.alunosTableAdapter = new CatApp.Database_alunosDataSetTableAdapters.AlunosTableAdapter();
            this.tableAdapterManager = new CatApp.Database_alunosDataSetTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gênero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horarios_aulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultima_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_inscricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adicionar_aulas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deletar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.alunosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alunosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database_alunosDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // alunosDataGridView
            // 
            this.alunosDataGridView.AllowUserToAddRows = false;
            this.alunosDataGridView.AllowUserToDeleteRows = false;
            this.alunosDataGridView.AutoGenerateColumns = false;
            this.alunosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.alunosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alunosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Gênero,
            this.dataGridViewTextBoxColumn4,
            this.horarios_aulas,
            this.ultima_entrada,
            this.data_inscricao,
            this.Telefone,
            this.Email,
            this.dataGridViewCheckBoxColumn1,
            this.adicionar_aulas,
            this.editar,
            this.deletar});
            this.alunosDataGridView.DataSource = this.alunosBindingSource;
            this.alunosDataGridView.Location = new System.Drawing.Point(12, 80);
            this.alunosDataGridView.Name = "alunosDataGridView";
            this.alunosDataGridView.RowTemplate.Height = 24;
            this.alunosDataGridView.Size = new System.Drawing.Size(1144, 200);
            this.alunosDataGridView.TabIndex = 1;
            this.alunosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.alunosDataGridView_CellContentClick);
            // 
            // alunosBindingSource
            // 
            this.alunosBindingSource.DataMember = "Alunos";
            this.alunosBindingSource.DataSource = this.database_alunosDataSet;
            // 
            // database_alunosDataSet
            // 
            this.database_alunosDataSet.DataSetName = "Database_alunosDataSet";
            this.database_alunosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // botaoadicionar
            // 
            this.botaoadicionar.Location = new System.Drawing.Point(12, 31);
            this.botaoadicionar.Name = "botaoadicionar";
            this.botaoadicionar.Size = new System.Drawing.Size(80, 43);
            this.botaoadicionar.TabIndex = 3;
            this.botaoadicionar.Text = "adicionar aluno";
            this.botaoadicionar.UseVisualStyleBackColor = true;
            this.botaoadicionar.Click += new System.EventHandler(this.botaoadicionar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_mostraralunos,
            this.configuraçõesToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // ts_mostraralunos
            // 
            this.ts_mostraralunos.Name = "ts_mostraralunos";
            this.ts_mostraralunos.Size = new System.Drawing.Size(269, 26);
            this.ts_mostraralunos.Text = "Escondendo Alunos Inativos";
            this.ts_mostraralunos.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 632);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1225, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // alunosTableAdapter
            // 
            this.alunosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AlunosTableAdapter = this.alunosTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = CatApp.Database_alunosDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Código";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Código RFID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código RFID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn3.FillWeight = 30.83827F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Gênero
            // 
            this.Gênero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Gênero.DataPropertyName = "Gênero";
            this.Gênero.FillWeight = 30.83827F;
            this.Gênero.HeaderText = "Gênero";
            this.Gênero.Name = "Gênero";
            this.Gênero.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Gênero.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Aulas pagas";
            this.dataGridViewTextBoxColumn4.FillWeight = 15F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Aulas pagas";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // horarios_aulas
            // 
            this.horarios_aulas.DataPropertyName = "horarios_aulas";
            this.horarios_aulas.FillWeight = 30.83827F;
            this.horarios_aulas.HeaderText = "Horários das aulas";
            this.horarios_aulas.Name = "horarios_aulas";
            // 
            // ultima_entrada
            // 
            this.ultima_entrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ultima_entrada.DataPropertyName = "ultima_entrada";
            this.ultima_entrada.FillWeight = 30.83827F;
            this.ultima_entrada.HeaderText = "Última entrada";
            this.ultima_entrada.Name = "ultima_entrada";
            this.ultima_entrada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ultima_entrada.Width = 70;
            // 
            // data_inscricao
            // 
            this.data_inscricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.data_inscricao.DataPropertyName = "data_inscricao";
            this.data_inscricao.HeaderText = "Data de inscrição";
            this.data_inscricao.Name = "data_inscricao";
            this.data_inscricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.data_inscricao.Width = 70;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.FillWeight = 30.83827F;
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.FillWeight = 30.83827F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Aluno_ativo";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Aluno ativo";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // adicionar_aulas
            // 
            this.adicionar_aulas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.adicionar_aulas.FillWeight = 151.7346F;
            this.adicionar_aulas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.adicionar_aulas.HeaderText = "adicionar aulas";
            this.adicionar_aulas.Name = "adicionar_aulas";
            this.adicionar_aulas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.adicionar_aulas.Width = 55;
            // 
            // editar
            // 
            this.editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.editar.FillWeight = 161.2811F;
            this.editar.HeaderText = "Ver dados";
            this.editar.Name = "editar";
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editar.Width = 55;
            // 
            // deletar
            // 
            this.deletar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deletar.FillWeight = 218.4093F;
            this.deletar.HeaderText = "Deletar aluno";
            this.deletar.Name = "deletar";
            this.deletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deletar.Width = 55;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 654);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.botaoadicionar);
            this.Controls.Add(this.alunosDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CatApp V0.9";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alunosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alunosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database_alunosDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database_alunosDataSet database_alunosDataSet;
        private System.Windows.Forms.BindingSource alunosBindingSource;
        private Database_alunosDataSetTableAdapters.AlunosTableAdapter alunosTableAdapter;
        private Database_alunosDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView alunosDataGridView;
        private System.Windows.Forms.Button botaoadicionar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_mostraralunos;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gênero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn horarios_aulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultima_entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_inscricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn adicionar_aulas;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn deletar;
    }
}

