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
        Database_alunosDataSetTableAdapters.AlunosTableAdapter AlunosTableAdapter;
        public string CodigoRFID;
        object TravaAPI, TravaAtualizacao;
        public FormAdicionarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref Database_alunosDataSetTableAdapters.AlunosTableAdapter d, ref object travaAPI, ref object travaAtualizacao)
        {

            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            AlunosTableAdapter = d;
            CodigoRFID = string.Empty;
            datainscricao.Text = DateTime.Now.ToShortDateString();
            TravaAPI = travaAPI;
            TravaAtualizacao = travaAtualizacao;
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
                MessageBox.Show("Insira um número de aulas!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CodigoRFID == "")
            {
                MessageBox.Show("nenhum cartão foi lido!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int resultado;
            if (!int.TryParse(TextBoxAulas.Text, out resultado))
            {
                MessageBox.Show("há algo errado com a formatação do número de aulas! Talvez haja um espaço sobrando entre os caracteres.", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o gênero do(a) aluno(a)!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lock (TravaAtualizacao)
            {
                DataRowView novo_aluno = (DataRowView)AlunosBindingSource.AddNew();
                novo_aluno["Nome"] = textBoxNome.Text;
                novo_aluno["Código RFID"] = CodigoRFID;
                novo_aluno["Aulas pagas"] = resultado;
                novo_aluno["Aluno_ativo"] = checkBoxAtivo.Checked;
                novo_aluno["horarios_aulas"] = horarios.Text;
                novo_aluno["Gênero"] = valores.genero[comboBox1.SelectedIndex];
                novo_aluno["historico_medico"] = historico_medico.Text;
                novo_aluno["Telefone"] = telefone.Text;
                novo_aluno["Email"] = email.Text;
                novo_aluno["Histórico de aulas"] = historicoAulas.Text;
                novo_aluno["Registro de medições"] = medicoes.Text;
                novo_aluno["anotacoes"] = anotacoes.Text;
                novo_aluno["data_inscricao"] = datainscricao.Text;
                novo_aluno["historico"] = "Aluno cadastrado no dia " + DateTime.Now.ToShortDateString() + "\n";
                novo_aluno["ultima_entrada"] = string.Empty;
                this.Validate();
                this.AlunosBindingSource.EndEdit();
                this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                this.Close();
            }

            
        }
      

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            FormPegarID F = new FormPegarID(ref TravaAPI);
            F.ShowDialog(this);
            if (F.fechar && F.encontrou != -1) return;
            if (AlunosBindingSource.Find("Código RFID", F.rfiduid) != -1) {
                MessageBox.Show("esse cartão já foi cadastrado!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Novo cartão lido com sucesso!","sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoRFID = F.rfiduid;
            }   
        }

        private void horarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAtivo_CheckedChanged(object sender, EventArgs e)
        {
            buttonVerificar.Enabled = checkBoxAtivo.Checked;
            if (checkBoxAtivo.Checked) return;
            else
            {
                CodigoRFID = "0";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAdicionarAluno_Load(object sender, EventArgs e)
        {

        }

    }
}
