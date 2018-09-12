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
        int index;
        DataRowView aluno_editado;
        object TravaAtualizar;
        public FormAdicionarAulas(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, int row_index, ref object travaAtualizar)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            index = row_index;
            aluno_editado = (DataRowView)AlunosBindingSource.List[index];
            TextBoxAulasTotais.Text = aluno_editado["Aulas pagas"].ToString();
            TravaAtualizar = travaAtualizar;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            if (TextBoxAulasAdicionadas.Text == "") {
                MessageBox.Show("escreva quantas aulas você deseja adicionar à esse aluno!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int valor = Int32.Parse(TextBoxAulasAdicionadas.Text);
            if (valor > 0)
            {
                if (MessageBox.Show("Você deseja adicionar " + TextBoxAulasAdicionadas.Text + " aulas ao aluno " + (string)aluno_editado["Nome"] + "?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = true;
                }
            }
            else if (valor < 0)
            {
                if (MessageBox.Show("Você deseja remover " + (-valor) + " aulas do aluno " + (string)aluno_editado["Nome"] + "?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = true;
                }

            }
            else
            {
                if (MessageBox.Show("Tem certeza que quer fechar o diálogo sem adicionar aulas?", "Adicionar aulas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (resultado)
            {
                aluno_editado["aulas pagas"] = Int32.Parse(TextBoxAulasTotais.Text);
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
            
            if(Int32.TryParse(TextBoxAulasAdicionadas.Text,out int valor))
            {
                TextBoxAulasTotais.Text = (valor + (int)aluno_editado["Aulas pagas"]).ToString();
            }
            
            else if (TextBoxAulasAdicionadas.Text == "")
            {
                TextBoxAulasTotais.Text = aluno_editado["Aulas pagas"].ToString();
            }
            else
            {
                MessageBox.Show("esse campo aceita apenas números positivos menores que cem mil!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxAulasAdicionadas.ResetText();
            }
        }

    }
}
