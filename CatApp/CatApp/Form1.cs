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
using System.Configuration;
using System.Collections.Specialized;
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
            lock (TravaAtualizacao) {
                DataRowView Aluno;
                try { Aluno = (DataRowView)alunosBindingSource.List[IndiceAluno]; }
                catch { return; }
                if (DescontarAula)
                {
                    Aluno[colunas.UltimaEntrada] = DateTime.Now.ToShortDateString();
                    Aluno[colunas.AulasPagas] = (int)Aluno[colunas.AulasPagas] - 1;
                }
                Aluno[colunas.Historico] += AdicionarAoHistorico;
                this.Validate();
                this.alunosBindingSource.EndEdit();
                try
                {
                    
                    this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
                }
                catch { }
                //alunosTableAdapter.Fill(database_alunosDataSet.Alunos);
            }
            IndiceAluno = -1;
            DescontarAula = false;
            AdicionarAoHistorico = string.Empty;
        }
        public Form1()
        {
            InitializeComponent();
            alunosBindingSource.Filter = colunas.AlunoAtivo + "= true";
            atualizar = new atualizaLista(MetodoAtualizarLista);
            tempDataSet = database_alunosDataSet;
            var thread = new Thread(checar_porta);
            thread.Start();
            DescontarAula = false;
            AdicionarAoHistorico = string.Empty;
            IndiceAluno = -1;
            alunosDataGridView.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 30, Screen.PrimaryScreen.Bounds.Height - 150);
        }

         void checar_porta()
        {
            retornoRFID retorno;
            while (!this.IsDisposed)
            {
                if( DateTime.Now.TimeOfDay <= config.hora_abre.TimeOfDay || DateTime.Now.TimeOfDay >= config.hora_fecha.TimeOfDay)
                {
                    if (ClienteREST.makeRequest(Comandos.go_home) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                    Thread.Sleep(5000);
                }
                else
                {

                    try
                    {
                        string ret = "falhou";
                        lock (TravaAPI) {
                            ret = ClienteREST.makeRequest(Comandos.readme);
                        }
                        if (ret == "falhou")
                        {
                            toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                        }
                        else
                        {
                            if (toolStripStatusLabel1.Text == "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.") toolStripStatusLabel1.Text = "";
                            retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ret);
                            if (retorno.variables.rfid_uid != "")
                            {

                                IndiceAluno = alunosBindingSource.Find(colunas.CodigoRFID, retorno.variables.rfid_uid);
                                if (IndiceAluno == -1)
                                {
                                    if (ClienteREST.makeRequest(Comandos.rejeitado) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                                }
                                else
                                {

                                    DataRowView aluno = (DataRowView)alunosBindingSource.List[IndiceAluno];
                                    if((bool)aluno[colunas.AlunoAtivo])
                                    {
                                        if ((string)aluno[colunas.UltimaEntrada] == DateTime.Now.ToShortDateString())
                                        {
                                            if (ClienteREST.makeRequest(Comandos.abrir, (int)aluno[colunas.AulasPagas]) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                                            AdicionarAoHistorico += "\tAluno abriu a porta às " + DateTime.Now.ToShortTimeString() + "\n";
                                            this.Invoke(atualizar);

                                        }
                                        else
                                        {
                                            int Num_aulas = (int)aluno[colunas.AulasPagas];
                                            if (Num_aulas == 0)
                                            {
                                                if (ClienteREST.makeRequest(Comandos.semcredito) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                                                toolStripStatusLabel1.Text = "Aluno " + (string)aluno[colunas.Nome] + " tentou entrar às " + DateTime.Now.ToShortTimeString() + ", mas suas aulas pagas acabaram";
                                            }
                                            else
                                            {
                                                if (ClienteREST.makeRequest(Comandos.abrir, Num_aulas - 1) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
                                                toolStripStatusLabel1.Text = "Aluno " + (string)aluno[colunas.Nome] + " entrou às " + DateTime.Now.ToShortTimeString();
                                                aluno[colunas.UltimaEntrada] = DateTime.Now.ToShortDateString();
                                                AdicionarAoHistorico += DateTime.Now.ToShortTimeString() + ": Aluno entrou na academia\n";
                                                AdicionarAoHistorico += "\tAluno abriu a porta às " + DateTime.Now.ToShortTimeString() + "\n";
                                                DescontarAula = true;
                                                this.Invoke(atualizar);
                                            }
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
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'database_alunosDataSet.Alunos'. Você pode movê-la ou removê-la conforme necessário.
            this.alunosTableAdapter.Fill(this.database_alunosDataSet.Alunos);
        }

        private void alunosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (e.ColumnIndex == adicionar_aulas.Index) { 

                    FormAdicionarAulas f4 = new FormAdicionarAulas(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, e.RowIndex, ref TravaAtualizacao);
                    f4.ShowDialog();
            }
            else if (e.ColumnIndex == editar.Index)
            {
                FormEditarAluno f3 = new FormEditarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, ref TravaAPI, ref TravaAtualizacao, e.RowIndex);
                f3.ShowDialog();
            }
            else if (e.ColumnIndex == deletar.Index)
            {
                if (MessageBox.Show("Você tem certeza que deseja deletar todas as informações desse aluno? Se apenas torná-lo inativo, suas informações não serão deletadas, mas também não poderá entrar na academia.", "Deseja deletar esse aluno?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    lock (TravaAtualizacao)
                    {
                        alunosBindingSource.RemoveAt(e.RowIndex);
                        this.Validate();
                        this.alunosBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    }
                }

            }
        }

        private void botaoadicionar_Click(object sender, EventArgs e)
        {
                FormEditarAluno f2 = new FormEditarAluno(ref tableAdapterManager, ref alunosBindingSource, ref database_alunosDataSet, ref alunosTableAdapter, ref TravaAPI, ref TravaAtualizacao);
                f2.ShowDialog();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrar_alunos_inativos = !mostrar_alunos_inativos;
            if (mostrar_alunos_inativos)
            {
                ts_mostraralunos.Text = "Mostrando alunos inativos";
                dataGridViewCheckBoxColumn1.Visible = true;
                alunosBindingSource.Sort = colunas.AlunoAtivo + " DESC";
                alunosBindingSource.Filter = "";
            }
            else
            {
                ts_mostraralunos.Text = "Escondendo alunos inativos";
                dataGridViewCheckBoxColumn1.Visible = false;
                alunosBindingSource.Filter = colunas.AlunoAtivo + "= true";
            }
        }


        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configurações fc = new Configurações();
            fc.ShowDialog();
        }
    }
}
