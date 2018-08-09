namespace CatApp
{
    partial class FormAdicionarAulas
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
            this.botaoAdicionar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxAulasTotais = new System.Windows.Forms.TextBox();
            this.TextBoxAulasAdicionadas = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botaoAdicionar
            // 
            this.botaoAdicionar.Location = new System.Drawing.Point(37, 121);
            this.botaoAdicionar.Name = "botaoAdicionar";
            this.botaoAdicionar.Size = new System.Drawing.Size(117, 23);
            this.botaoAdicionar.TabIndex = 0;
            this.botaoAdicionar.Text = "Adicionar Aulas";
            this.botaoAdicionar.UseVisualStyleBackColor = true;
            this.botaoAdicionar.Click += new System.EventHandler(this.botaoAdicionar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(234, 121);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxAulasAdicionadas);
            this.groupBox1.Controls.Add(this.TextBoxAulasTotais);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(37, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(156, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número de aulas adicionadas";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número total de aulas do aluno";
            // 
            // TextBoxAulasTotais
            // 
            this.TextBoxAulasTotais.Enabled = false;
            this.TextBoxAulasTotais.Location = new System.Drawing.Point(18, 64);
            this.TextBoxAulasTotais.Name = "TextBoxAulasTotais";
            this.TextBoxAulasTotais.Size = new System.Drawing.Size(43, 22);
            this.TextBoxAulasTotais.TabIndex = 4;
            // 
            // TextBoxAulasAdicionadas
            // 
            this.TextBoxAulasAdicionadas.Location = new System.Drawing.Point(159, 63);
            this.TextBoxAulasAdicionadas.Name = "TextBoxAulasAdicionadas";
            this.TextBoxAulasAdicionadas.Size = new System.Drawing.Size(43, 22);
            this.TextBoxAulasAdicionadas.TabIndex = 5;
            this.TextBoxAulasAdicionadas.TextChanged += new System.EventHandler(this.TextBoxAulasAdicionadas_TextChanged);
            // 
            // FormAdicionarAulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 156);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.botaoAdicionar);
            this.Name = "FormAdicionarAulas";
            this.Text = "Adicionar Aulas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botaoAdicionar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxAulasTotais;
        private System.Windows.Forms.TextBox TextBoxAulasAdicionadas;
    }
}