namespace CatApp
{
    partial class Configurações
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
            this.porta = new System.Windows.Forms.TextBox();
            this.HoraAbre = new System.Windows.Forms.DateTimePicker();
            this.HoraFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Confirma = new System.Windows.Forms.Button();
            this.Cancela = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // porta
            // 
            this.porta.Location = new System.Drawing.Point(40, 49);
            this.porta.Name = "porta";
            this.porta.Size = new System.Drawing.Size(102, 22);
            this.porta.TabIndex = 0;
            // 
            // HoraAbre
            // 
            this.HoraAbre.CustomFormat = "HH:mm";
            this.HoraAbre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HoraAbre.Location = new System.Drawing.Point(253, 47);
            this.HoraAbre.Name = "HoraAbre";
            this.HoraAbre.ShowUpDown = true;
            this.HoraAbre.Size = new System.Drawing.Size(69, 22);
            this.HoraAbre.TabIndex = 1;
            this.HoraAbre.Value = new System.DateTime(2018, 9, 20, 21, 31, 0, 0);
            // 
            // HoraFecha
            // 
            this.HoraFecha.CustomFormat = "HH:mm";
            this.HoraFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HoraFecha.Location = new System.Drawing.Point(253, 118);
            this.HoraFecha.Name = "HoraFecha";
            this.HoraFecha.ShowUpDown = true;
            this.HoraFecha.Size = new System.Drawing.Size(69, 22);
            this.HoraFecha.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Porta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Horário de abertura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Horário de fechamento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Confirma);
            this.groupBox1.Controls.Add(this.Cancela);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.porta);
            this.groupBox1.Controls.Add(this.HoraFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.HoraAbre);
            this.groupBox1.Location = new System.Drawing.Point(31, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 215);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Confirma
            // 
            this.Confirma.Location = new System.Drawing.Point(12, 143);
            this.Confirma.Name = "Confirma";
            this.Confirma.Size = new System.Drawing.Size(102, 50);
            this.Confirma.TabIndex = 7;
            this.Confirma.Text = "Confirmar mudanças";
            this.Confirma.UseVisualStyleBackColor = true;
            this.Confirma.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cancela
            // 
            this.Cancela.Location = new System.Drawing.Point(120, 146);
            this.Cancela.Name = "Cancela";
            this.Cancela.Size = new System.Drawing.Size(102, 47);
            this.Cancela.TabIndex = 6;
            this.Cancela.Text = "Rejeitar mudanças";
            this.Cancela.UseVisualStyleBackColor = true;
            this.Cancela.Click += new System.EventHandler(this.Cancela_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ip";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(40, 110);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 22);
            this.textBoxIP.TabIndex = 9;
            // 
            // Configurações
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 260);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configurações";
            this.Text = "configuracoes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox porta;
        private System.Windows.Forms.DateTimePicker HoraAbre;
        private System.Windows.Forms.DateTimePicker HoraFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Confirma;
        private System.Windows.Forms.Button Cancela;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}