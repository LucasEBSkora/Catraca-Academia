using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatApp
{
    public partial class FormAdicionarAluno : Form
    {
        private Database_alunosDataSetTableAdapters.TableAdapterManager AlunosTableAdapterManager;
        private System.Windows.Forms.BindingSource AlunosBindingSource;
        Database_alunosDataSet database_alunosDataSet;
        public FormAdicionarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("esse campo aceita apenas números positivos menores que cem mil!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TextBoxAulas.ResetText();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text == "")
            {
                MessageBox.Show("Insira um nome!");
                return;
            }
            if (TextBoxAulas.Text == "")
            {
                MessageBox.Show("Insira um número!");
                return;
            }
            DataRowView novo_aluno = (DataRowView)AlunosBindingSource.AddNew();
            novo_aluno["Nome"] = textBoxNome.Text;
            novo_aluno["Código RFID"] = 1;
            novo_aluno["Aulas pagas"] = int.Parse(TextBoxAulas.Text);
            novo_aluno["Aluno_ativo"] = checkBoxAtivo.Checked;
            this.Validate();
            this.AlunosBindingSource.EndEdit();
            this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
            this.Close();
            
        }
        
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
