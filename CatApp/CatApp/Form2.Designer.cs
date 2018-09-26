namespace CatApp
{
    partial class FormAdicionarAluno
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
            this.components = new System.ComponentModel.Container();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonVerificar = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.TextBoxAulas = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.telefone = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.medicoes = new System.Windows.Forms.RichTextBox();
            this.historicoAulas = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.horarios = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datainscricao = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.anotacoes = new System.Windows.Forms.RichTextBox();
            this.historico_medico = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.buttonAdicionar.Location = new System.Drawing.Point(10, 463);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(88, 23);
            this.buttonAdicionar.TabIndex = 0;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(774, 463);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(82, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonVerificar
            // 
            this.buttonVerificar.Location = new System.Drawing.Point(392, 463);
            this.buttonVerificar.Name = "buttonVerificar";
            this.buttonVerificar.Size = new System.Drawing.Size(99, 46);
            this.buttonVerificar.TabIndex = 2;
            this.buttonVerificar.Text = "Verificar Cartão";
            this.buttonVerificar.UseVisualStyleBackColor = true;
            this.buttonVerificar.Click += new System.EventHandler(this.buttonVerificar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(9, 49);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(171, 22);
            this.textBoxNome.TabIndex = 3;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Checked = true;
            this.checkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAtivo.Location = new System.Drawing.Point(287, 26);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(139, 21);
            this.checkBoxAtivo.TabIndex = 5;
            this.checkBoxAtivo.Text = "Aluno está ativo?";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            this.checkBoxAtivo.CheckedChanged += new System.EventHandler(this.checkBoxAtivo_CheckedChanged);
            // 
            // TextBoxAulas
            // 
            this.TextBoxAulas.Location = new System.Drawing.Point(186, 50);
            this.TextBoxAulas.Mask = "00000";
            this.TextBoxAulas.Name = "TextBoxAulas";
            this.TextBoxAulas.Size = new System.Drawing.Size(43, 22);
            this.TextBoxAulas.TabIndex = 6;
            this.TextBoxAulas.Text = "0";
            this.TextBoxAulas.ValidatingType = typeof(int);
            this.TextBoxAulas.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome do aluno";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(181, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de aulas pagas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.telefone);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.medicoes);
            this.groupBox1.Controls.Add(this.historicoAulas);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.horarios);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.datainscricao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.anotacoes);
            this.groupBox1.Controls.Add(this.historico_medico);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBoxAulas);
            this.groupBox1.Controls.Add(this.checkBoxAtivo);
            this.groupBox1.Controls.Add(this.textBoxNome);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 445);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Outro(a)"});
            this.comboBox1.Location = new System.Drawing.Point(432, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // telefone
            // 
            this.telefone.Location = new System.Drawing.Point(607, 121);
            this.telefone.Name = "telefone";
            this.telefone.Size = new System.Drawing.Size(173, 22);
            this.telefone.TabIndex = 28;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(607, 49);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(173, 22);
            this.email.TabIndex = 27;
            // 
            // medicoes
            // 
            this.medicoes.Location = new System.Drawing.Point(218, 206);
            this.medicoes.Name = "medicoes";
            this.medicoes.Size = new System.Drawing.Size(208, 233);
            this.medicoes.TabIndex = 26;
            this.medicoes.Text = "";
            this.medicoes.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // historicoAulas
            // 
            this.historicoAulas.Location = new System.Drawing.Point(432, 206);
            this.historicoAulas.Name = "historicoAulas";
            this.historicoAulas.Size = new System.Drawing.Size(195, 233);
            this.historicoAulas.TabIndex = 25;
            this.historicoAulas.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(432, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "Gênero";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(429, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Histórico de aulas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Registro de Medições";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Telefone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(604, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Email";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 19;
            // 
            // horarios
            // 
            this.horarios.Location = new System.Drawing.Point(184, 121);
            this.horarios.Name = "horarios";
            this.horarios.Size = new System.Drawing.Size(208, 22);
            this.horarios.TabIndex = 18;
            this.horarios.TextChanged += new System.EventHandler(this.horarios_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "horários das aulas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data da inscrição";
            // 
            // datainscricao
            // 
            this.datainscricao.Location = new System.Drawing.Point(9, 121);
            this.datainscricao.Mask = "00/00/0000";
            this.datainscricao.Name = "datainscricao";
            this.datainscricao.Size = new System.Drawing.Size(101, 22);
            this.datainscricao.TabIndex = 14;
            this.datainscricao.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Anotações Extras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Histórico médico";
            // 
            // anotacoes
            // 
            this.anotacoes.Location = new System.Drawing.Point(633, 206);
            this.anotacoes.Name = "anotacoes";
            this.anotacoes.Size = new System.Drawing.Size(211, 233);
            this.anotacoes.TabIndex = 11;
            this.anotacoes.Text = "";
            // 
            // historico_medico
            // 
            this.historico_medico.Location = new System.Drawing.Point(9, 206);
            this.historico_medico.Name = "historico_medico";
            this.historico_medico.Size = new System.Drawing.Size(203, 233);
            this.historico_medico.TabIndex = 10;
            this.historico_medico.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormAdicionarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonVerificar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAdicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdicionarAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Aluno";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAdicionarAluno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonVerificar;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.CheckBox checkBoxAtivo;
        private System.Windows.Forms.MaskedTextBox TextBoxAulas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox historico_medico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox anotacoes;
        private System.Windows.Forms.MaskedTextBox datainscricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox horarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox telefone;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.RichTextBox medicoes;
        private System.Windows.Forms.RichTextBox historicoAulas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}