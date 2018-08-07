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
    public partial class Form1 : Form
    {
        bool mostrar_alunos_inativos = false;

        public Form1()
        {
            InitializeComponent();
            alunosBindingSource.Filter = "Aluno_ativo= true";
        }

        private void alunosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.alunosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'database_alunosDataSet.Alunos'. Você pode movê-la ou removê-la conforme necessário.
            this.alunosTableAdapter.Fill(this.database_alunosDataSet.Alunos);

        }

        private void alunosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5: //adicionar aulas
                    MessageBox.Show("diálogo para adicionar aulas");
                    break;
                case 6: //deletar aluno
                    if (MessageBox.Show("Você tem certeza que deseja deletar todas as informações desse aluno? Se apenas torná-lo inativo, suas informações não serão deletadas, mas também não poderá entrar na academia.","Deseja deletar esse aluno?",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        alunosBindingSource.RemoveAt(e.RowIndex);
                        this.Validate();
                        this.alunosBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    }
                    break;
                case 7: //editar aluno
                    MessageBox.Show("diálogo para editar os dados do aluno");
                    break;

            }
        }

        private void botaoadicionar_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet);
            f2.ShowDialog();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrar_alunos_inativos = !mostrar_alunos_inativos;
            if (mostrar_alunos_inativos)
            {
                ts_mostraralunos.Text = "Mostrando alunos inativos";
                dataGridViewCheckBoxColumn1.Visible = true;
                alunosBindingSource.Sort = "Aluno_ativo DESC";
                alunosBindingSource.Filter = "";
            }
            else
            {
                ts_mostraralunos.Text = "Escondendo alunos inativos";
                dataGridViewCheckBoxColumn1.Visible = false;
                alunosBindingSource.Filter = "Aluno_ativo= true";
            }
        }
    }
}
