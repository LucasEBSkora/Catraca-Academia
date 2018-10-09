using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CatApp
{
    public partial class FormAdicionarAulas : Form
    {
        private Database_alunosDataSetTableAdapters.TableAdapterManager AlunosTableAdapterManager;
        private System.Windows.Forms.BindingSource AlunosBindingSource;
        Database_alunosDataSet database_alunosDataSet;
        Database_alunosDataSetTableAdapters.AlunosTableAdapter AlunosTableAdapter;
        int index;
        DataRowView aluno_editado;
        object TravaAtualizar;
        public FormAdicionarAulas(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref Database_alunosDataSetTableAdapters.AlunosTableAdapter d, int row_index, ref object travaAtualizar)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            AlunosTableAdapter = d;
            index = row_index;
            aluno_editado = (DataRowView)AlunosBindingSource.List[index];
            TextBoxAulasTotais.Text = aluno_editado[colunas.AulasPagas].ToString();
            TravaAtualizar = travaAtualizar;
            label1.Text = "Número total de aulas d" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao) + " alun" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            if (TextBoxAulasAdicionadas.Text == "" || TextBoxAulasAdicionadas.Text == "-") {
                MessageBox.Show("escreva quantas aulas você deseja adicionar à ess" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ae) + " alun" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao) + "!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int valor = Int32.Parse(TextBoxAulasAdicionadas.Text);
            if (valor > 0)
            {
                if (MessageBox.Show("Você deseja adicionar " + TextBoxAulasAdicionadas.Text + " aula" + (valor > 1 ? "s " : string.Empty) + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.aaao) + " alun" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao) + " " + (string)aluno_editado[colunas.Nome] + "?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = true;
                }
            }
            else if (valor < 0)
            {
                if (MessageBox.Show("Você deseja remover " + (-valor) + " aula" + (valor < -1 ? "s" : string.Empty) + " d" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao) + " alun" + utilidades.adeq(aluno_editado, utilidades.adeqSituacoes.ao) + " " + (string)aluno_editado[colunas.Nome] + " ?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = true;
                }

            }
            else
            {
                if (MessageBox.Show("Tem certeza que quer fechar o formulário sem adicionar aulas?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (resultado)
            {
                aluno_editado[colunas.AulasPagas] = Int32.Parse(TextBoxAulasTotais.Text);
                lock (TravaAtualizar)
                {
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                }
                this.Close();
            }
        }
        
        private void TextBoxAulasAdicionadas_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxAulasAdicionadas.Text == "-") return;
            if(Int32.TryParse(TextBoxAulasAdicionadas.Text,out int valor))
            {
                TextBoxAulasTotais.Text = (valor + (int)aluno_editado[colunas.AulasPagas]).ToString();
            }
            else if (TextBoxAulasAdicionadas.Text == "")
            {
                TextBoxAulasTotais.Text = aluno_editado[colunas.AulasPagas].ToString();
            }
            else
            {
                MessageBox.Show("esse campo aceita apenas números menores que cem mil!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxAulasAdicionadas.ResetText();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextBoxAulasAdicionadas.Text == "" || TextBoxAulasAdicionadas.Text == "-")
            {
                TextBoxAulasAdicionadas.Text = "10";
                TextBoxAulasTotais.Text = (10 + (int)aluno_editado[colunas.AulasPagas]).ToString();
            }
            else
            {
                TextBoxAulasAdicionadas.Text = (10 + Int32.Parse(TextBoxAulasAdicionadas.Text)).ToString();
                TextBoxAulasTotais.Text = (Int32.Parse(TextBoxAulasAdicionadas.Text) + (int)aluno_editado[colunas.AulasPagas]).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBoxAulasAdicionadas.Text = "-1";
            TextBoxAulasTotais.Text = ((int)aluno_editado[colunas.AulasPagas] - 1).ToString();
        }
    }
}
