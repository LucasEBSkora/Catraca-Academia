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
using Newtonsoft.Json;
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
                    //Aluno[colunas.AulasPagas] = (int)Aluno[colunas.AulasPagas] - 1;
                }
                //Aluno[colunas.Historico] += AdicionarAoHistorico;
                List<EntradaHistorico> HLista = JsonConvert.DeserializeObject<List<EntradaHistorico>>((string)Aluno[colunas.Historico]);
                int indice = HLista.FindIndex(x => x.Data == DateTime.Now.Date);
                if (indice == -1)
                {
                    HLista.Add(new EntradaHistorico(DateTime.Now.Date, AdicionarAoHistorico));

                }
                else
                {
                    HLista[indice].Entrada += AdicionarAoHistorico;
                }
                Aluno[colunas.Historico] = JsonConvert.SerializeObject(HLista);
                this.Validate();
                this.alunosBindingSource.EndEdit();
                try { this.tableAdapterManager.UpdateAll(this.database_alunosDataSet); }
                catch { }


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
            //var thread = new Thread(checar_porta);
            //thread.Start();
            DescontarAula = false;
            AdicionarAoHistorico = string.Empty;
            IndiceAluno = -1;
            alunosDataGridView.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 30, Screen.PrimaryScreen.Bounds.Height - 150);
            horarios_aulas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Servidor.responseGenerator = ListenerPorta;
            Servidor.Start();
        }



        string ListenerPorta(HttpListenerRequest value)
        {
            //o url vem como "/id", entao tiramos na marra o /
            string ID = value.RawUrl.Substring(1);
            if (ID.Length == 0) return "empty";
            IndiceAluno = alunosBindingSource.Find(colunas.CodigoRFID, ID);

            if (IndiceAluno == -1) return "rejeitado";
            else
            {
                DataRowView aluno = (DataRowView)alunosBindingSource.List[IndiceAluno];
                if ((bool)aluno[colunas.AlunoAtivo])
                {
                    if ((string)aluno[colunas.UltimaEntrada] == DateTime.Now.ToShortDateString())
                    {
                        AdicionarAoHistorico += "\n\n" + DateTime.Now.ToShortTimeString() + " - Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " abriu a porta";
                        toolStripStatusLabel1.Text = "Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " " + (string)aluno[colunas.Nome] + " abriu a porta";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " " + (string)aluno[colunas.Nome] + " entrou às " + DateTime.Now.ToShortTimeString();
                        aluno[colunas.UltimaEntrada] = DateTime.Now.ToShortDateString();
                        AdicionarAoHistorico += "\n\n" + DateTime.Now.ToShortTimeString() + " - Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " abriu a porta pela primeira vez no dia";
                    }
                    this.Invoke(atualizar);
                    return "aprovado";
                }
                else return "rejeitado";
            }

        }

        // void checar_porta()
        //{

        //    Servidor.responseGenerator = (HttpListenerRequest value) => value.RawUrl;



        //    while (!this.IsDisposed)
        //    {
        //        if( DateTime.Now.TimeOfDay <= config.hora_abre.TimeOfDay || DateTime.Now.TimeOfDay >= config.hora_fecha.TimeOfDay)
        //        {
        //            if (ClienteREST.makeRequest(Comandos.go_home) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //            Thread.Sleep(5000);
        //        }
        //        else
        //        {

        //            try
        //            {
        //                string ret = "falhou";
        //                lock (TravaAPI) {
        //                    ret = ClienteREST.makeRequest(Comandos.readme);
        //                }
        //                if (ret == "falhou")
        //                {
        //                    toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //                }
        //                else
        //                {
        //                    if (toolStripStatusLabel1.Text == "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.") toolStripStatusLabel1.Text = "";
        //                    retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ret);
        //                    if (retorno.variables.rfid_uid != "")
        //                    {

        //                        IndiceAluno = alunosBindingSource.Find(colunas.CodigoRFID, retorno.variables.rfid_uid);
        //                        if (IndiceAluno == -1)
        //                        {
        //                            if (ClienteREST.makeRequest(Comandos.rejeitado) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //                        }
        //                        else
        //                        {

        //                            DataRowView aluno = (DataRowView)alunosBindingSource.List[IndiceAluno];
        //                            if((bool)aluno[colunas.AlunoAtivo])
        //                            {
        //                                if ((string)aluno[colunas.UltimaEntrada] == DateTime.Now.ToShortDateString())
        //                                {
        //                                    if (ClienteREST.makeRequest(Comandos.abrir, (int)aluno[colunas.AulasPagas]) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //                                    AdicionarAoHistorico += "\n\n" +DateTime.Now.ToShortTimeString() + " - Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " abriu a porta";
        //                                    this.Invoke(atualizar);

        //                                }
        //                                else
        //                                {
        //                                    int Num_aulas = (int)aluno[colunas.AulasPagas];
        //                                    if (Num_aulas == 0)
        //                                    {
        //                                        if (ClienteREST.makeRequest(Comandos.semcredito) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //                                        toolStripStatusLabel1.Text = "Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " " + (string)aluno[colunas.Nome] + " tentou entrar às " + DateTime.Now.ToShortTimeString() + ", mas suas aulas pagas acabaram";
        //                                    }
        //                                    else
        //                                    {
        //                                        if (ClienteREST.makeRequest(Comandos.abrir, Num_aulas - 1) == "falhou") toolStripStatusLabel1.Text = "Erro na comunicação com a porta! O wifi pode não estar funcionando, a porta ter desligado ou desconectado, ou o endereço da porta estar errada.";
        //                                        toolStripStatusLabel1.Text = "Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " " + (string)aluno[colunas.Nome] + " entrou às " + DateTime.Now.ToShortTimeString();
        //                                        aluno[colunas.UltimaEntrada] = DateTime.Now.ToShortDateString();
        //                                        AdicionarAoHistorico += "\n\n" + DateTime.Now.ToShortTimeString() + " - Alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + " abriu a porta pela primeira vez no dia";
        //                                        DescontarAula = true;
        //                                        this.Invoke(atualizar);
        //                                    }
        //                                }
        //                            } 
        //                        }
        //                    }
        //                }
        //                Thread.Sleep(200); //de quanto em quanto tempo o programa deve verificar a porta?
        //            }
        //            catch { }
        //        }
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'database_alunosDataSet.Alunos'. Você pode movê-la ou removê-la conforme necessário.
            this.alunosTableAdapter.Fill(this.database_alunosDataSet.Alunos);
            foreach(DataRowView aluno in alunosBindingSource)
            {
                if ((string)aluno[colunas.Aniversario] == "-") aluno["Idade"] = "0";
                else
                {
                    bool FezAniversarioEsseAno = false;
                    DateTime Hoje = DateTime.Now.Date;
                    DateTime Aniversario = DateTime.Parse((string)aluno[colunas.Aniversario]);
                    if (Hoje.Month < Aniversario.Month) FezAniversarioEsseAno = false;
                    else if (Hoje.Month == Aniversario.Month)
                    {
                        if (Hoje.Month < Aniversario.Month) FezAniversarioEsseAno = false;
                        else if (Hoje.Day == Aniversario.Day)
                        {
                            MessageBox.Show("é o aniversário de " + (string)aluno[colunas.Nome] + " hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FezAniversarioEsseAno = true;
                        }
                        else FezAniversarioEsseAno = true;
                    }
                    else FezAniversarioEsseAno = true;
                    
                    if (FezAniversarioEsseAno) aluno["Idade"] = Hoje.Year - Aniversario.Year;
                    else aluno["Idade"] = Hoje.Year - Aniversario.Year - 1;
                }
            }
            lock (TravaAtualizacao)
            {
                this.Validate();
                this.alunosBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database_alunosDataSet);
            }
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
                DataRowView aluno = (DataRowView)alunosBindingSource[e.RowIndex];
                if (MessageBox.Show("Você tem certeza que deseja deletar todas as informações dess" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ae) + " alun" + utilidades.adeq(aluno, utilidades.adeqSituacoes.ao) + "? Se apenas torná-lo inativo, suas informações não serão deletadas, mas também não poderá entrar na academia.", "Deseja deletar esse aluno?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
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
