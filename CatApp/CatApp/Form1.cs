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
using System.Threading;

namespace CatApp
{
    public partial class Form1 : Form
    {
        bool mostrar_alunos_inativos = false;
        static object Trava = new object();
        public Form1()
        {
            InitializeComponent();
            alunosBindingSource.Filter = "Aluno_ativo= true";
            var thread = new Thread(checar_porta);
            thread.Start();
        }
         void checar_porta()
        {
            retornoRFID retorno;
            while (!this.IsDisposed)
            {
                lock (Trava) {retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ClienteREST.makeRequest(Comandos./*readme*/jsonSim, 0)); }
                if (retorno.variables.rfid_uid != "")
                {
                    //MessageBox.Show(retorno.variables.rfid_uid);
                    if (this.IsDisposed) return;
                    else
                    {
                        int indice = alunosBindingSource.Find("Código RFID", retorno.variables.rfid_uid);
                        if (indice == -1) /*messsagem de cartao nao cadastrado*/;
                        else
                        {
                            DataRowView aluno = (DataRowView)alunosBindingSource.List[indice];
                            //MessageBox.Show((string)aluno["Nome"]);
                            int Num_aulas = (int)aluno["Aulas pagas"];
                            if (Num_aulas == 0) { /*mensagem de aulas pagas acabadas*/}
                            else
                            {
                                toolStripStatusLabel1.Text = "aluno " + (string)aluno["nome"] + " entrou";
                            }
                        }
                    }

                }
                Thread.Sleep(500); //de quanto em quanto tempo o programa deve verificar a porta?
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'database_alunosDataSet.Alunos'. Você pode movê-la ou removê-la conforme necessário.
            this.alunosTableAdapter.Fill(this.database_alunosDataSet.Alunos);
        }

        private void alunosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            //MessageBox.Show(e.ColumnIndex.ToString());
            switch (e.ColumnIndex)
            {
                case 7: //adicionar aulas
                    FormAdicionarAulas f4 = new FormAdicionarAulas(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, e.RowIndex);
                    f4.ShowDialog();
                    break;
                case 8: //editar aluno
                    FormEditarAluno f3 = new FormEditarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, e.RowIndex, ref Trava);
                    f3.ShowDialog();

                    break;
                case 9: //deletar aluno
                    if (MessageBox.Show("Você tem certeza que deseja deletar todas as informações desse aluno? Se apenas torná-lo inativo, suas informações não serão deletadas, mas também não poderá entrar na academia.","Deseja deletar esse aluno?",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        alunosBindingSource.RemoveAt(e.RowIndex);
                        this.Validate();
                        this.alunosBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
                        
                    }
                    break;


            }
        }

        private void botaoadicionar_Click(object sender, EventArgs e)
        {
            FormAdicionarAluno f2 = new FormAdicionarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref Trava);
            f2.ShowDialog();
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
