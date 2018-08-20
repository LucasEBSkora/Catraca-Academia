using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
namespace CatApp
{
    public partial class FormAdicionarAluno : Form
    {
        private Database_alunosDataSetTableAdapters.TableAdapterManager AlunosTableAdapterManager;
        private System.Windows.Forms.BindingSource AlunosBindingSource;
        Database_alunosDataSet database_alunosDataSet;
        ClienteREST cliente;
        public string CodigoRFID;

        public FormAdicionarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref ClienteREST Cliente)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            cliente = Cliente;
            CodigoRFID = string.Empty;
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
                MessageBox.Show("Insira um nome!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TextBoxAulas.Text == "")
            {
                MessageBox.Show("Insira um número!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CodigoRFID == "")
            {
                MessageBox.Show("nenhum cartão foi lido!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRowView novo_aluno = (DataRowView)AlunosBindingSource.AddNew();
            novo_aluno["Nome"] = textBoxNome.Text;
            novo_aluno["Código RFID"] = CodigoRFID;
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

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            retornoRFID retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(cliente.makeRequest(Comandos.readme));
            if (AlunosBindingSource.Find("Código RFID", retorno.variables.rfid_uid) != -1) {
                MessageBox.Show("esse cartão já foi cadastrado!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Novo cartão lido com sucesso!","sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CodigoRFID = retorno.variables.rfid_uid;
            }   
        }
    }
}
