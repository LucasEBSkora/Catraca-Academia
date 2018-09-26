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
        bool UltimoEvento;
        public FormEditarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref Database_alunosDataSetTableAdapters.AlunosTableAdapter d, int row_index, ref object travaAPI, ref object travaAtualizacao)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            AlunosTableAdapter = d;
            index = row_index;
            TravaAPI = travaAPI;
            TravaAtualizacao = travaAtualizacao;
            InicializarInformacoes();
        }
        private void InicializarInformacoes()
        {
            aluno_editado = (DataRowView)AlunosBindingSource.List[index];
            Nome.Text = (string)aluno_editado[colunas.Nome];
            UltimoEvento = true;
            checkBox1.Checked = (bool)aluno_editado[colunas.AlunoAtivo];
            CodigoRFID = (string)aluno_editado[colunas.CodigoRFID];
            AulasPagas.Text = aluno_editado[colunas.AulasPagas].ToString();
            historico.Text = (string)aluno_editado[colunas.Historico];
            historico_med.Text = (string)aluno_editado[colunas.historicoMedico];
            anotacoes.Text = (string)aluno_editado[colunas.Anotacoes];
            data.Text = (string)aluno_editado[colunas.dataInscricao];
            horarios.Text = (string)aluno_editado[colunas.HorariosAulas];
            HistoricoAulas.Text = (string)aluno_editado[colunas.HistoricoAulas];
            for (int i = 0; i < 3; i++)
            {
                if ((string)aluno_editado[colunas.Genero] == valores.genero[i]) comboBox1.SelectedIndex = i;
            }
            email.Text = (string)aluno_editado[colunas.Email];
            telefone.Text = (string)aluno_editado[colunas.Telefone];
            medicoes.Text = (string)aluno_editado[colunas.RegistroMedicoes];
            HistoricoAulas.Text = (string)aluno_editado[colunas.HistoricoAulas];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lock (TravaAtualizacao)
            {
                string AdicionarAoHistorico = ""; 

                if ((string)aluno_editado[colunas.Nome] != Nome.Text)
                {
                    AdicionarAoHistorico += "\tNome mudado de " + (string)aluno_editado[colunas.Nome] + " para " + Nome.Text + "\n";
                    aluno_editado[colunas.Nome] = Nome.Text;
                }
                if ((string)aluno_editado[colunas.CodigoRFID] != CodigoRFID)
                {
                    AdicionarAoHistorico += "\tCartão atualizado\n";
                    aluno_editado[colunas.CodigoRFID] = CodigoRFID;
                }
                if ((bool)aluno_editado[colunas.AlunoAtivo] != checkBox1.Checked)
                {
                    if (checkBox1.Checked) AdicionarAoHistorico += "\tAluno reativado\n";
                    else AdicionarAoHistorico += "\tAluno desativado\n";
                    aluno_editado[colunas.AlunoAtivo] = checkBox1.Checked;
                }
                if ((string)aluno_editado[colunas.historicoMedico] != historico_med.Text)
                {
                    AdicionarAoHistorico += "\tHistórico médico atualizado\n";
                    aluno_editado[colunas.historicoMedico] = historico_med.Text;
                }
                if ((string)aluno_editado[colunas.Anotacoes] != anotacoes.Text)
                {
                    AdicionarAoHistorico += "\tanotações atualizadas\n";
                    aluno_editado[colunas.Anotacoes] = anotacoes.Text;
                }
                if (data.Text != (string)aluno_editado[colunas.dataInscricao])
                {
                    AdicionarAoHistorico += "\tData de inscrição mudada de " + (string)aluno_editado[colunas.dataInscricao] + " para " + data.Text + "\n";
                    aluno_editado[colunas.dataInscricao] = data.Text;
                }
                if (horarios.Text != (string)aluno_editado[colunas.HorariosAulas])
                {
                    AdicionarAoHistorico += "\tHorários das aulas mudados de " + (string)aluno_editado[colunas.HorariosAulas] + " para " + horarios.Text + "\n";
                    aluno_editado[colunas.HorariosAulas] = horarios.Text;
                }
                if ((string)aluno_editado[colunas.Genero] != valores.genero[comboBox1.SelectedIndex])
                {
                    AdicionarAoHistorico += "\tGênero do aluno mudado de " + (string)aluno_editado[colunas.Genero] + " para " + valores.genero[comboBox1.SelectedIndex] + "\n";
                    aluno_editado[colunas.Genero] = valores.genero[comboBox1.SelectedIndex];
                }
                if ((string)aluno_editado[colunas.Email] != email.Text)
                {
                    AdicionarAoHistorico += "\tEmail mudado de " + (string)aluno_editado[colunas.Email] + " para " + email.Text + "\n";
                    aluno_editado[colunas.Email] = email.Text;
                }
                if ((string)aluno_editado[colunas.Telefone] != telefone.Text)
                {
                    AdicionarAoHistorico += "\tTelefone mudado de " + (string)aluno_editado[colunas.Telefone] + " para " + telefone.Text + "\n";
                    aluno_editado[colunas.Telefone] = telefone.Text;
                }
                if ((string)aluno_editado[colunas.RegistroMedicoes] != medicoes.Text)
                {
                    AdicionarAoHistorico += "\tMedições atualizadas\n";
                    aluno_editado[colunas.RegistroMedicoes] = medicoes.Text;
                }
                if ((string)aluno_editado[colunas.HistoricoAulas] != HistoricoAulas.Text)
                {
                    AdicionarAoHistorico += "\tHistórico de aulas atualizado\n";
                    aluno_editado[colunas.HistoricoAulas] = HistoricoAulas.Text;
                }
                if (AdicionarAoHistorico != "")
                {
                    aluno_editado[colunas.Historico] += "aluno editado no dia" + DateTime.Now.ToShortDateString() + ":\n" + AdicionarAoHistorico;
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                }
                
            }        
                MessageBox.Show("Atualização feita com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Todas as alterações feitas ao aluno vão ser perdidas! Certeza que deseja continuar?","Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                InicializarInformacoes();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (UltimoEvento)
            {
                UltimoEvento = false;
                return;
            }
            if (checkBox1.Checked)
            {
                MessageBox.Show("Agora que esse aluno foi reativado, será necessário registrar um novo cartão para ele!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (MessageBox.Show("Se esse aluno for desativado, não haverá mais um cartão associado a ele, e um novo terá de ser registrado. Tem certeza que deseja continuar?", "Aviso!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                UltimoEvento = true;
                checkBox1.Checked = true;
                button2.Enabled = true;
                
            }
            else
            {
                checkBox1.Checked = false;
                button2.Enabled = false;
                CodigoRFID = "0";
            }
            button2.Enabled = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPegarID F = new FormPegarID(ref TravaAPI);
            F.ShowDialog(this);
            if (F.fechar && F.encontrou != -1) return;
            if (F.rfiduid == CodigoRFID)
            {
                MessageBox.Show("esse já é o cartão desse aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (AlunosBindingSource.Find(colunas.CodigoRFID, F.rfiduid) != -1 && AlunosBindingSource.Find(colunas.CodigoRFID, F.rfiduid) != index)
            {
                MessageBox.Show("esse cartão já foi cadastrado para outro aluno!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Novo cartão lido com sucesso!", "sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoRFID = F.rfiduid;
            }
        }

    }
}
