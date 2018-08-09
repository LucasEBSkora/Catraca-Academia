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
    public partial class FormEditarAluno : Form
    {
        private Database_alunosDataSetTableAdapters.TableAdapterManager AlunosTableAdapterManager;
        private System.Windows.Forms.BindingSource AlunosBindingSource;
        Database_alunosDataSet database_alunosDataSet;
        int index;
        DataRow aluno_editado;
        public FormEditarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, int row_index)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            index = row_index;
            aluno_editado = database_alunosDataSet.Alunos.Rows[index];
            textBox1.Text = (string)aluno_editado["Nome"];
            checkBox1.Checked = (bool)aluno_editado["aluno_ativo"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            aluno_editado["Nome"] = textBox1.Text;
            aluno_editado["Código RFID"] = 1;
            aluno_editado["Aluno_ativo"] = checkBox1.Checked;
            this.Validate();
            this.AlunosBindingSource.EndEdit();
            this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
