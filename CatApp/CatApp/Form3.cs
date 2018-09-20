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
        Database_alunosDataSetTableAdapters.AlunosTableAdapter AlunosTableAdapter;
        int index;
        DataRowView aluno_editado;
        public string CodigoRFID;
        object TravaAPI, TravaAtualizacao;
        public FormEditarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref Database_alunosDataSetTableAdapters.AlunosTableAdapter d, int row_index, ref object travaAPI, ref object travaAtualizacao)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            AlunosTableAdapter = d;
            index = row_index;
            aluno_editado = (DataRowView)AlunosBindingSource.List[index];
            Nome.Text = (string)aluno_editado["Nome"];
            checkBox1.Checked = (bool)aluno_editado["aluno_ativo"];
            CodigoRFID = (string)aluno_editado["Código RFID"];
            AulasPagas.Text = aluno_editado["Aulas pagas"].ToString();
            historico.Text = (string)aluno_editado["historico"];
            historico_med.Text = (string)aluno_editado["historico_medico"];
            anotacoes.Text = (string)aluno_editado["anotacoes"];
            data.Text = (string)aluno_editado["data_inscricao"];
            TravaAPI = travaAPI;
            TravaAtualizacao = travaAtualizacao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lock (TravaAtualizacao)
            {
                if (((string)aluno_editado["Nome"] != Nome.Text) || ((string)aluno_editado["Código RFID"] != CodigoRFID) || ((bool)aluno_editado["Aluno_ativo"] != checkBox1.Checked) || ((string)aluno_editado["historico_medico"] != historico_med.Text) || ((string)aluno_editado["anotacoes"] != anotacoes.Text) || (data.Text != (string)aluno_editado["data_inscricao"]))
                {
                    aluno_editado["historico"] += "aluno editado no dia" + DateTime.Now.ToShortDateString() + ":\n";
                    if ((string)aluno_editado["Nome"] != Nome.Text)
                    {
                        aluno_editado["Nome"] = Nome.Text;
                        aluno_editado["historico"] += "\tNome mudado de " + (string)aluno_editado["Nome"] + " para " + Nome.Text + "\n";
                    }
                    if ((string)aluno_editado["Código RFID"] != CodigoRFID)
                    {
                        aluno_editado["Código RFID"] = CodigoRFID;
                        aluno_editado["historico"] += "\tCartão atualizado\n";
                    }
                    if ((bool)aluno_editado["Aluno_ativo"] != checkBox1.Checked)
                    {
                        aluno_editado["Aluno_ativo"] = checkBox1.Checked;
                        if (checkBox1.Checked) aluno_editado["historico"] += "\tAluno reativado\n";
                        else aluno_editado["historico"] += "\tAluno desativado\n";
                    }
                    if ((string)aluno_editado["historico_medico"] != historico_med.Text)
                    {
                        aluno_editado["historico_medico"] = historico_med.Text;
                        aluno_editado["historico"] += "\tHistórico médico atualizado\n";
                    }
                    if ((string)aluno_editado["anotacoes"] != anotacoes.Text)
                    {
                        aluno_editado["anotacoes"] = anotacoes.Text;
                        aluno_editado["historico"] += "\tanotações atualizadas\n";
                    }
                    if (data.Text != (string)aluno_editado["data_inscricao"])
                    {
                        aluno_editado["data_inscricao"] = data.Text;
                        aluno_editado["historico"] += "\tData de inscrição mudada de " + (string)aluno_editado["data_inscricao"] + " para " + data.Text + "\n";
                    }
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    //database_alunosDataSet.AcceptChanges();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nome.Text = (string)aluno_editado["Nome"];
            checkBox1.Checked = (bool)aluno_editado["aluno_ativo"];
            CodigoRFID = (string)aluno_editado["Código RFID"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPegarID F = new FormPegarID(ref TravaAPI);
            F.ShowDialog(this);
            if (F.fechar && F.encontrou != -1) return;
            if (AlunosBindingSource.Find("Código RFID", F.rfiduid) == index)
            {
                MessageBox.Show("esse já é o cartão desse aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (AlunosBindingSource.Find("Código RFID", F.rfiduid) != -1)
            {
                MessageBox.Show("esse cartão já foi cadastrado para outro aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Novo cartão lido com sucesso!", "sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CodigoRFID = F.rfiduid;
            }
        }

    }
}
