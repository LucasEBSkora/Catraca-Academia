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
        static object TravaAPI = new object();
        static object TravaAtualizacao = new object();
        Database_alunosDataSet tempDataSet;
        delegate void atualizaLista();
        atualizaLista atualizar;
        string AdicionarAoHistorico;
        bool DescontarAula;
        int IndiceAluno;
        void MetodoAtualizarLista()
        {
           
            DataRowView aluno = (DataRowView)alunosBindingSource.List[IndiceAluno];
            if (DescontarAula)
            {
                aluno["ultima_entrada"] = DateTime.Now.ToShortDateString();
                aluno["Aulas pagas"] = (int)aluno["Aulas pagas"] - 1;
            }
            aluno["historico"] += AdicionarAoHistorico;
            this.Validate();
            this.alunosBindingSource.EndEdit();
            try {
                
                this.tableAdapterManager.UpdateAll(this.database_alunosDataSet); }
            catch { }
            //alunosTableAdapter.Fill(database_alunosDataSet.Alunos);
            IndiceAluno = -1;
            DescontarAula = false;
            AdicionarAoHistorico = string.Empty;
        }
        public Form1()
        {
            InitializeComponent();
            alunosBindingSource.Filter = "Aluno_ativo= true";
            atualizar = new atualizaLista(MetodoAtualizarLista);
            tempDataSet = database_alunosDataSet;
            var thread = new Thread(checar_porta);
            thread.Start();
            DescontarAula = false;
            AdicionarAoHistorico = string.Empty;
            IndiceAluno = -1;
        }

         void checar_porta()
        {
            retornoRFID retorno;
            while (!this.IsDisposed)
            {
                try
                {
                    lock (TravaAPI) { retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ClienteREST.makeRequest(Comandos./*readme*/jsonSim)); }

                    if (retorno.variables.rfid_uid != "")
                    {

                        //tempDataSet = database_alunosDataSet;
                        lock (TravaAtualizacao)
                        {
                            IndiceAluno = alunosBindingSource.Find("Código RFID", retorno.variables.rfid_uid);
                            if (IndiceAluno == -1)
                            {
                                //ClienteREST.makeRequest(Comandos.rejeitado, 0);
                            }
                            else
                            {

                                DataRowView aluno = (DataRowView)alunosBindingSource.List[IndiceAluno];
                                if ((string)aluno["ultima_entrada"] == DateTime.Now.ToShortDateString())
                                {
                                    //ClienteREST.makeRequest(Comandos.abrir, porta);
                                    AdicionarAoHistorico += "\tAluno abriu a porta às " + DateTime.Now.ToShortTimeString() + "\n";
                                    this.Invoke(atualizar);

                                }
                                else
                                {
                                    int Num_aulas = (int)aluno["Aulas pagas"];
                                    if (Num_aulas == 0)
                                    {
                                        //ClienteREST.makeRequest(Comandos.semcredito, porta);
                                        toolStripStatusLabel1.Text = "Aluno " + (string)aluno["nome"] + " tentou entrar às " + DateTime.Now.ToShortTimeString() + ", mas suas aulas pagas acabaram";
                                    }
                                    else
                                    {
                                        //ClienteREST.makeRequest(Comandos.abrir, porta);
                                        toolStripStatusLabel1.Text = "Aluno " + (string)aluno["nome"] + " entrou às " + DateTime.Now.ToShortDateString();
                                        aluno["ultima_entrada"] = DateTime.Now.ToShortDateString();
                                        AdicionarAoHistorico += "Aluno " + (string)aluno["nome"] + " entrou às " + DateTime.Now.ToShortTimeString() + "\n";
                                        AdicionarAoHistorico += "\tAluno abriu a porta às " + DateTime.Now.ToShortTimeString() + "\n";
                                        DescontarAula = true;
                                        this.Invoke(atualizar);
                                    }
                                }

                            }
                        }
                    }
                    Thread.Sleep(200); //de quanto em quanto tempo o programa deve verificar a porta?
                }
                catch { }
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
                    FormAdicionarAulas f4 = new FormAdicionarAulas(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, e.RowIndex, ref TravaAtualizacao);
                    f4.ShowDialog();
                    break;
                case 8: //editar aluno
                    FormEditarAluno f3 = new FormEditarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, e.RowIndex, ref TravaAPI, ref TravaAtualizacao);
                    f3.ShowDialog();

                    break;
                case 9: //deletar aluno
                    if (MessageBox.Show("Você tem certeza que deseja deletar todas as informações desse aluno? Se apenas torná-lo inativo, suas informações não serão deletadas, mas também não poderá entrar na academia.","Deseja deletar esse aluno?",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        lock (TravaAtualizacao)
                        {
                            //database_alunosDataSet.AcceptChanges();
                            alunosBindingSource.RemoveAt(e.RowIndex);
                            this.Validate();
                            this.alunosBindingSource.EndEdit();
                            this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
                            //database_alunosDataSet.AcceptChanges();
                            alunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                        }
                    }
                    break;
            }
        }

        private void botaoadicionar_Click(object sender, EventArgs e)
        {
                FormAdicionarAluno f2 = new FormAdicionarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, ref TravaAPI, ref TravaAtualizacao);
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
