﻿namespace CatApp
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
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonVerificar = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.TextBoxAulas = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.horarios = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datainscricao = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.anotacoes = new System.Windows.Forms.RichTextBox();
            this.historico_medico = new System.Windows.Forms.RichTextBox();
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
            this.buttonCancelar.Location = new System.Drawing.Point(432, 463);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(82, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonVerificar
            // 
            this.buttonVerificar.Location = new System.Drawing.Point(204, 463);
            this.buttonVerificar.Name = "buttonVerificar";
            this.buttonVerificar.Size = new System.Drawing.Size(99, 46);
            this.buttonVerificar.TabIndex = 2;
            this.buttonVerificar.Text = "Verificar Cartão";
            this.buttonVerificar.UseVisualStyleBackColor = true;
            this.buttonVerificar.Click += new System.EventHandler(this.buttonVerificar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(9, 58);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(171, 22);
            this.textBoxNome.TabIndex = 3;
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Checked = true;
            this.checkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAtivo.Location = new System.Drawing.Point(287, 34);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(139, 21);
            this.checkBoxAtivo.TabIndex = 5;
            this.checkBoxAtivo.Text = "Aluno está ativo?";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // TextBoxAulas
            // 
            this.TextBoxAulas.Location = new System.Drawing.Point(192, 58);
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
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome do aluno";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(186, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de aulas pagas";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(504, 445);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // horarios
            // 
            this.horarios.Location = new System.Drawing.Point(290, 120);
            this.horarios.Name = "horarios";
            this.horarios.Size = new System.Drawing.Size(208, 22);
            this.horarios.TabIndex = 18;
            this.horarios.TextChanged += new System.EventHandler(this.horarios_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 93);
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
            this.label4.Location = new System.Drawing.Point(284, 186);
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
            this.anotacoes.Location = new System.Drawing.Point(287, 206);
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
            // FormAdicionarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonVerificar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAdicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
    }
}