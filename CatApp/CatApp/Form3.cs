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
        DataRowView aluno_editado;
        ClienteREST cliente;
        public string CodigoRFID;

        public FormEditarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, int row_index, ref ClienteREST Cliente)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            index = row_index;
            aluno_editado = (DataRowView)AlunosBindingSource.List[index];
            textBox1.Text = (string)aluno_editado["Nome"];
            checkBox1.Checked = (bool)aluno_editado["aluno_ativo"];
            cliente = Cliente;
            CodigoRFID = (string)aluno_editado["Código RFID"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aluno_editado["Nome"] = textBox1.Text;
            aluno_editado["Código RFID"] = CodigoRFID;
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
            retornoRFID retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(cliente.makeRequest(Comandos.readme));

            if (AlunosBindingSource.Find("Código RFID", retorno.variables.rfid_uid) == index)
            {
                MessageBox.Show("esse já é o cartão desse aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (AlunosBindingSource.Find("Código RFID", retorno.variables.rfid_uid) != -1)
            {
                MessageBox.Show("esse cartão já foi cadastrado para outro aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Novo cartão lido com sucesso!", "sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CodigoRFID = retorno.variables.rfid_uid;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
