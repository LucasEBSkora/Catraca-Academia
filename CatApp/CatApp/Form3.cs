using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CatApp
{
    public partial class FormEditarAluno : Form
    { 
        private Database_alunosDataSetTableAdapters.TableAdapterManager AlunosTableAdapterManager;
        private System.Windows.Forms.BindingSource AlunosBindingSource;
        Database_alunosDataSet database_alunosDataSet;
        Database_alunosDataSetTableAdapters.AlunosTableAdapter AlunosTableAdapter;
        int index;
        DataRowView Aluno;
        public string CodigoRFID;
        object TravaAPI, TravaAtualizacao;
        private bool UltimoEvento;
        bool setup = true;

       
        public FormEditarAluno(ref Database_alunosDataSetTableAdapters.TableAdapterManager a, ref System.Windows.Forms.BindingSource b, ref Database_alunosDataSet c, ref Database_alunosDataSetTableAdapters.AlunosTableAdapter d,  ref object travaAPI, ref object travaAtualizacao, int row_index = -1)
        {
            InitializeComponent();
            AlunosTableAdapterManager = a;
            AlunosBindingSource = b;
            database_alunosDataSet = c;
            AlunosTableAdapter = d;
            index = row_index;
            TravaAPI = travaAPI;
            TravaAtualizacao = travaAtualizacao;
            RMData.Value = DateTime.Now.Date;
            InicializarRM();
            InicializarHHA();
            if (index != -1) InicializarInformacoes();
            else FormatacaoNovoAluno();
            setup = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        }
        
        private void FormatacaoNovoAluno()
        {
            this.Text = "Adicionar Aluno";
            Cartao.Text = "Verificar Cartão";
            Salvar.Text = "Adicionar";
            Cancelar.Text = "Cancelar";
            CodigoRFID = "-2";
            data.Text = DateTime.Now.ToShortDateString();
            AulasPagas.Enabled = true;
            checkBox1.Checked = true;
            Aviso.Visible = false;
            RMLista = new List<Medicao>();
            HLista = new List<EntradaHistorico>();
            tabPage2.Enabled = false;
            tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(tabControler_Selecting);
        }

        private void tabControler_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex < 0) return;
            e.Cancel = !e.TabPage.Enabled;
            MessageBox.Show("Essa aba só pode ser usada após o aluno ser criado!", "cuidado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InicializarInformacoes()
        {
            Aluno = (DataRowView)AlunosBindingSource.List[index];
            Nome.Text = (string)Aluno[colunas.Nome];
            UltimoEvento = false;
            checkBox1.Checked = (bool)Aluno[colunas.AlunoAtivo];
            Cartao.Enabled = (bool)Aluno[colunas.AlunoAtivo];
            CodigoRFID = (string)Aluno[colunas.CodigoRFID];
            AulasPagas.Text = Aluno[colunas.AulasPagas].ToString();
            historico_med.Text = (string)Aluno[colunas.historicoMedico];
            anotacoes.Text = (string)Aluno[colunas.Anotacoes];
            data.Text = (string)Aluno[colunas.dataInscricao];
            horarios.Text = (string)Aluno[colunas.HorariosAulas];
            NumeroCartao.Text = Aluno[colunas.NumeroCartao].ToString();
            Aniversario.Value = DateTime.Parse((string)Aluno[colunas.Aniversario]);
            Idade.Text = Aluno[colunas.Idade].ToString();
            for (int i = 0; i < 3; i++)
            {
                if ((string)Aluno[colunas.Genero] == utilidades.genero[i]) comboBox1.SelectedIndex = i;
            }
            CarregarHHA();
            CarregarRM();
            email.Text = (string)Aluno[colunas.Email];
            telefone.Text = (string)Aluno[colunas.Telefone];
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (UltimoEvento && index != -1)
            {
                UltimoEvento = false;
                return;
            }
            if (checkBox1.Checked)
            {
                if (index != -1) MessageBox.Show("Agora que ess" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ae) + " alun" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ao) + " foi reativad" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ao) + ", será necessário registrar um novo cartão para el" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ae) + "!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (index == -1) CodigoRFID = "0";
            else if (MessageBox.Show("Se ess" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ae) + " alun" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ao) + " for desativad" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ao) + ", não haverá mais um cartão associado a el" + utilidades.adeq(Aluno, utilidades.adeqSituacoes.ae) + ", e um novo terá de ser registrado. Tem certeza que deseja continuar?", "Aviso!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                UltimoEvento = true;
                checkBox1.Checked = true;
                Cartao.Enabled = true;

            }
            else
            {
                checkBox1.Checked = false;
                Cartao.Enabled = false;
                CodigoRFID = "0";
            }
            Cartao.Enabled = checkBox1.Checked;
        }

        private void AulasPagas_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("esse campo aceita apenas números positivos menores que cem mil!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AulasPagas.ResetText();
        }


        private void Salvar_Click(object sender, EventArgs e)
        {
            string AdicionarAoHistorico = "";
            if (index == -1)
            {
                if (Nome.Text == "")
                {
                    MessageBox.Show("Insira um nome!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (AulasPagas.Text == "")
                {
                    MessageBox.Show("Insira um número de aulas!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((CodigoRFID == "" || CodigoRFID == "0" || CodigoRFID == "-2") && checkBox1.Checked)
                {
                    MessageBox.Show("nenhum cartão foi lido!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int resultado;
                if (!int.TryParse(AulasPagas.Text, out resultado))
                {
                    MessageBox.Show("há algo errado com a formatação do número de aulas! Talvez haja um espaço sobrando entre os caracteres.", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o gênero do(a) aluno(a)!", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(NumeroCartao.Text, out resultado))
                {
                    if (NumeroCartao.Text != "")
                    {
                        MessageBox.Show("há algo errado com a formatação do número do cartão! Talvez haja um espaço sobrando entre os caracteres.", "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else NumeroCartao.Text = "0";
                }
                else if (resultado == 0)
                {
                    if (MessageBox.Show("Deixar o número do cartão do aluno como 0 pode dificultar caso o aluno confuda seu cartão. Certeza que quer deixar assim?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;
                }
            }
            else
            {
                if ((string)Aluno[colunas.Nome] != Nome.Text)
                {
                    AdicionarAoHistorico += "\n\tNome mudado de:\n\t\t" + (string)Aluno[colunas.Nome] + "\n\tpara:\n\t\t" + Nome.Text;
                }
                if ((string)Aluno[colunas.CodigoRFID] != CodigoRFID)
                {
                    AdicionarAoHistorico += "\n\tCartão atualizado";
                }
                if ((bool)Aluno[colunas.AlunoAtivo] != checkBox1.Checked)
                {
                    if (checkBox1.Checked) AdicionarAoHistorico += "\n\tAluno reativado";
                    else AdicionarAoHistorico += "\n\tAluno desativado";
                }
                if ((string)Aluno[colunas.historicoMedico] != historico_med.Text)
                {
                    AdicionarAoHistorico += "\n\tHistórico médico atualizado";
                }
                if ((string)Aluno[colunas.Anotacoes] != anotacoes.Text)
                {
                    AdicionarAoHistorico += "\n\tanotações atualizadas";
                }
                if (data.Text != (string)Aluno[colunas.dataInscricao])
                {
                    AdicionarAoHistorico += "\n\tData de inscrição mudada de " + (string)Aluno[colunas.dataInscricao] + " para " + data.Text;
                }
                if (horarios.Text != (string)Aluno[colunas.HorariosAulas])
                {
                    if ((string)Aluno[colunas.HorariosAulas] == "") AdicionarAoHistorico += "\n\tHorários das aulas adicionados";
                    else AdicionarAoHistorico += "\n\tHorários das aulas mudados de:\n\t\t" + (string)Aluno[colunas.HorariosAulas] + "\n\tpara:\n\t\t" + horarios.Text;
                }
                if ((string)Aluno[colunas.Genero] != utilidades.genero[comboBox1.SelectedIndex])
                {
                    AdicionarAoHistorico += "\n\tGênero do aluno mudado de " + (string)Aluno[colunas.Genero] + " para " + utilidades.genero[comboBox1.SelectedIndex];
                }
                if ((string)Aluno[colunas.Email] != email.Text)
                {
                    if ((string)Aluno[colunas.Email] == "") AdicionarAoHistorico += "\n\tEmail adicionado";
                    else AdicionarAoHistorico += "\n\tEmail mudado de:\n\t\t" + (string)Aluno[colunas.Email] + "\n\tpara:\n\t\t" + email.Text;
                }
                if ((string)Aluno[colunas.Telefone] != telefone.Text)
                {
                    if ((string)Aluno[colunas.Telefone] == "") AdicionarAoHistorico += "\n\tTelefone adicionado";
                    else AdicionarAoHistorico += "\n\tTelefone mudado de:\n\t\t" + (string)Aluno[colunas.Telefone] + "\n\tpara:\n\t\t" + telefone.Text;
                }
                if ((int)Aluno[colunas.NumeroCartao] != int.Parse(NumeroCartao.Text))
                {
                    if ((int)Aluno[colunas.NumeroCartao] == 0) AdicionarAoHistorico += "\n\tNúmero do cartão adicionado!";
                    else AdicionarAoHistorico += "\n\tNúmero do cartão mudado de:\n\t\t" + (string)Aluno[colunas.NumeroCartao] + "\n\tpara:\n\t\t" + NumeroCartao.Text;
                }
                if ((string)Aluno[colunas.Aniversario] != Aniversario.Value.ToShortDateString()) 
                {
                    AdicionarAoHistorico += "\n\tAniversário do aluno mudado de " + (string)Aluno[colunas.Aniversario] + " para " + Aniversario.Text;
                }
            }
            lock (TravaAtualizacao)
            {
                if (index == -1) Aluno = (DataRowView)AlunosBindingSource.AddNew();
                Aluno[colunas.Nome] = Nome.Text;
                Aluno[colunas.CodigoRFID] = CodigoRFID;
                Aluno[colunas.AulasPagas] = int.Parse(AulasPagas.Text);
                Aluno[colunas.AlunoAtivo] = checkBox1.Checked;
                Aluno[colunas.HorariosAulas] = horarios.Text;
                Aluno[colunas.Genero] = utilidades.genero[comboBox1.SelectedIndex];
                Aluno[colunas.historicoMedico] = historico_med.Text;
                Aluno[colunas.Telefone] = telefone.Text;
                Aluno[colunas.Email] = email.Text;
                Aluno[colunas.Anotacoes] = anotacoes.Text;
                Aluno[colunas.dataInscricao] = data.Text;
                Aluno[colunas.UltimaEntrada] = string.Empty;
                if (int.TryParse(NumeroCartao.Text, out int resultado)) {
                    Aluno[colunas.NumeroCartao] = resultado;
                }
                else Aluno[colunas.NumeroCartao] = 0;
                Aluno[colunas.Aniversario] = Aniversario.Value.Date.ToShortDateString();

                bool FezAniversarioEsseAno = false;
                DateTime Hoje = DateTime.Now.Date;
                DateTime aniversario = Aniversario.Value.Date;
                if (Hoje.Month < aniversario.Month) FezAniversarioEsseAno = false;
                else if (Hoje.Month == aniversario.Month)
                {
                    if (Hoje.Day < aniversario.Day) FezAniversarioEsseAno = false;
                    else FezAniversarioEsseAno = true;
                }
                else FezAniversarioEsseAno = true;

                if (FezAniversarioEsseAno) Aluno[colunas.Idade] = Hoje.Year - aniversario.Year;
                else Aluno[colunas.Idade] = Hoje.Year - aniversario.Year - 1;
                if (index == -1)
                {
                    HLista.Add(new EntradaHistorico(DateTime.Now.Date, "Aluno cadastrado no dia " + DateTime.Now.ToShortDateString() + "."));
                    Aluno[colunas.Historico] = JsonConvert.SerializeObject(HLista);
                    Aluno[colunas.HistoricoAulas] = "-";
                    Aluno[colunas.RegistroMedicoes] = "-";
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                    this.Close();
                }
                else
                {
                    int indice = HLista.FindIndex(x => x.Data == DateTime.Now.Date);
                    if (indice == -1)
                    {
                        if (AdicionarAoHistorico != "") HLista.Add(new EntradaHistorico(DateTime.Now.Date, DateTime.Now.ToShortTimeString() + " - aluno editado:" + AdicionarAoHistorico));

                    }
                    else
                    {
                        HLista[indice].Entrada += "\n\n" + DateTime.Now.ToShortTimeString() + "- aluno editado:" + AdicionarAoHistorico;
                    }
                    Aluno[colunas.Historico] = JsonConvert.SerializeObject(HLista);
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    HLista.Sort((x, y) => x.Data.CompareTo(y.Data));
                    HBindingSource.Clear();
                    foreach (EntradaHistorico entrada in HLista)
                    {
                        HBindingSource.Add(entrada.ParaBS());
                    }
                }
            }
            MessageBox.Show(((index == -1) ? "Aluno adicionado" : "Atualização feita") + " com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (index == -1) this.Close();
        }

        private void Cartao_Click(object sender, EventArgs e)
        {
            FormPegarID F = new FormPegarID(ref TravaAPI);
            F.ShowDialog(this);
            if (F.fechar && F.encontrou != -1) return;
            if (F.rfiduid == CodigoRFID)
            {
                MessageBox.Show("esse já é o cartão desse aluno!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Cancelar_Click(object sender, EventArgs e)
        {
            if (index != -1 && MessageBox.Show("Todas as alterações feitas ao aluno vão ser perdidas! Certeza que deseja continuar?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                InicializarInformacoes();
            }
            else if (MessageBox.Show("Todas as informações já salvas do novo aluno serão perdidas! Certeza que deseja continuar?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                this.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void NumeroCartao_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("esse campo aceita apenas números positivos menores que 999!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            NumeroCartao.Text = "0";
        }

        private void Aniversario_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Now.DayOfYear.CompareTo(Aniversario.Value.DayOfYear) >= 0)
            {

                Idade.Text = (DateTime.Now.Year - Aniversario.Value.Year).ToString();
            }
            else Idade.Text = (DateTime.Now.Year - Aniversario.Value.Year - 1).ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
