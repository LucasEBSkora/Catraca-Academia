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
        private BindingSource RMBindingSource;
        private List<Medicao> RMLista;
        bool setup = true;
        class Medicao
        {
            public DateTime Data;
            public decimal Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC;

            public Medicao(DateTime data, decimal peso, decimal gorduraCorporal, decimal musculoEsqueletico, decimal gorduraVisceral, decimal iMC)
            {
                Data = data;
                Peso = peso;
                GorduraCorporal = gorduraCorporal;
                MusculoEsqueletico = musculoEsqueletico;
                GorduraVisceral = gorduraVisceral;
                IMC = iMC;
            }

            public MedicaoBS ParaBS()
            {
                return new MedicaoBS(Data, Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC);
            }
        }
        class MedicaoBS
        {
            DateTime Data;
            decimal Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC;

            public MedicaoBS(DateTime data, decimal peso, decimal gorduraCorporal, decimal musculoEsqueletico, decimal gorduraVisceral, decimal iMC)
            {
                Data = data;
                Peso = peso;
                GorduraCorporal = gorduraCorporal;
                MusculoEsqueletico = musculoEsqueletico;
                GorduraVisceral = gorduraVisceral;
                IMC = iMC;
            }

            public string SData { get { return Data.ToShortDateString(); } }

            public string SPeso { get { return Peso.ToString(); } }

            public string SGorduraCorporal { get { return GorduraCorporal.ToString(); } }

            public string SMusculoEsqueletico { get { return MusculoEsqueletico.ToString(); } }

            public string SGorduraVisceral { get { return GorduraVisceral.ToString(); } }

            public string SIMC { get { return IMC.ToString(); } }
        }
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
            if (index != -1) InicializarInformacoes();
            else FormatacaoNovoAluno();
            setup = false;
        }
        private void InicializarRM()
        {
            RMBindingSource = new BindingSource();
            RMTabela.DataSource = RMBindingSource;
            RMTabela.AutoGenerateColumns = false;

            DataGridViewColumn RMDataMedicao = new DataGridViewTextBoxColumn();
            RMDataMedicao.DataPropertyName = "SData";
            RMDataMedicao.Name = "Data da Medição";
            RMDataMedicao.FillWeight = 1.6F;
            RMTabela.Columns.Add(RMDataMedicao);

            DataGridViewColumn RMPeso = new DataGridViewTextBoxColumn();
            RMPeso.DataPropertyName = "SPeso";
            RMPeso.Name = "Peso (Kg)";
            RMPeso.FillWeight = 1;
            RMTabela.Columns.Add(RMPeso);

            DataGridViewColumn RMGorduraCorporal = new DataGridViewTextBoxColumn();
            RMGorduraCorporal.DataPropertyName = "SGorduraCorporal";
            RMGorduraCorporal.Name = "Gordura corporal";
            RMGorduraCorporal.FillWeight = 1.1F;
            RMTabela.Columns.Add(RMGorduraCorporal);

            DataGridViewColumn RMMusculoEsqueletico = new DataGridViewTextBoxColumn();
            RMMusculoEsqueletico.DataPropertyName = "SMusculoEsqueletico";
            RMMusculoEsqueletico.Name = "Músculo esquelético";
            RMMusculoEsqueletico.FillWeight = 1.4F;
            RMTabela.Columns.Add(RMMusculoEsqueletico);

            DataGridViewColumn RMGorduraVisceral = new DataGridViewTextBoxColumn();
            RMGorduraVisceral.DataPropertyName = "SGorduraVisceral";
            RMGorduraVisceral.Name = "Gordura Visceral";
            RMGorduraVisceral.FillWeight = 1.1F;
            RMTabela.Columns.Add(RMGorduraVisceral);

            DataGridViewColumn RMIMC = new DataGridViewTextBoxColumn();
            RMIMC.DataPropertyName = "SIMC";
            RMIMC.Name = "IMC";
            RMIMC.FillWeight = 1;
            RMTabela.Columns.Add(RMIMC);

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
        }
        private void InicializarInformacoes()
        {
            Aluno = (DataRowView)AlunosBindingSource.List[index];
            Nome.Text = (string)Aluno[colunas.Nome];
            UltimoEvento = true;
            checkBox1.Checked = (bool)Aluno[colunas.AlunoAtivo];
            CodigoRFID = (string)Aluno[colunas.CodigoRFID];
            AulasPagas.Text = Aluno[colunas.AulasPagas].ToString();
            historico.Text = (string)Aluno[colunas.Historico];
            historico_med.Text = (string)Aluno[colunas.historicoMedico];
            anotacoes.Text = (string)Aluno[colunas.Anotacoes];
            data.Text = (string)Aluno[colunas.dataInscricao];
            horarios.Text = (string)Aluno[colunas.HorariosAulas];
            HistoricoAulas.Text = (string)Aluno[colunas.HistoricoAulas];
            for (int i = 0; i < 3; i++)
            {
                if ((string)Aluno[colunas.Genero] == valores.genero[i]) comboBox1.SelectedIndex = i;
            }
            email.Text = (string)Aluno[colunas.Email];
            telefone.Text = (string)Aluno[colunas.Telefone];

            RMLista = JsonConvert.DeserializeObject<List<Medicao>>((string)Aluno[colunas.RegistroMedicoes]);
            RMLista.Sort((x, y) => x.Data.CompareTo(y.Data));
            foreach (Medicao medicao in RMLista)
            {
                RMBindingSource.Add(medicao.ParaBS());
            }

            HistoricoAulas.Text = (string)Aluno[colunas.HistoricoAulas];
        }
        private void button1_Click(object sender, EventArgs e)
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
                if (CodigoRFID == "")
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
            }
            else
            {
                if ((string)Aluno[colunas.Nome] != Nome.Text)
                {
                    AdicionarAoHistorico += "\tNome mudado de " + (string)Aluno[colunas.Nome] + " para " + Nome.Text + "\n";
                }
                if ((string)Aluno[colunas.CodigoRFID] != CodigoRFID)
                {
                    AdicionarAoHistorico += "\tCartão atualizado\n";
                }
                if ((bool)Aluno[colunas.AlunoAtivo] != checkBox1.Checked)
                {
                    if (checkBox1.Checked) AdicionarAoHistorico += "\tAluno reativado\n";
                    else AdicionarAoHistorico += "\tAluno desativado\n";
                }
                if ((string)Aluno[colunas.historicoMedico] != historico_med.Text)
                {
                    AdicionarAoHistorico += "\tHistórico médico atualizado\n";
                }
                if ((string)Aluno[colunas.Anotacoes] != anotacoes.Text)
                {
                    AdicionarAoHistorico += "\tanotações atualizadas\n";
                }
                if (data.Text != (string)Aluno[colunas.dataInscricao])
                {
                    AdicionarAoHistorico += "\tData de inscrição mudada de " + (string)Aluno[colunas.dataInscricao] + " para " + data.Text + "\n";
                }
                if (horarios.Text != (string)Aluno[colunas.HorariosAulas])
                {
                    AdicionarAoHistorico += "\tHorários das aulas mudados de " + (string)Aluno[colunas.HorariosAulas] + " para " + horarios.Text + "\n";
                }
                if ((string)Aluno[colunas.Genero] != valores.genero[comboBox1.SelectedIndex])
                {
                    AdicionarAoHistorico += "\tGênero do aluno mudado de " + (string)Aluno[colunas.Genero] + " para " + valores.genero[comboBox1.SelectedIndex] + "\n";
                }
                if ((string)Aluno[colunas.Email] != email.Text)
                {
                    AdicionarAoHistorico += "\tEmail mudado de " + (string)Aluno[colunas.Email] + " para " + email.Text + "\n";
                }
                if ((string)Aluno[colunas.Telefone] != telefone.Text)
                {
                    AdicionarAoHistorico += "\tTelefone mudado de " + (string)Aluno[colunas.Telefone] + " para " + telefone.Text + "\n";
                }
                if ((string)Aluno[colunas.HistoricoAulas] != HistoricoAulas.Text)
                {
                    AdicionarAoHistorico += "\tHistórico de aulas atualizado\n";
                }
            }
            lock (TravaAtualizacao)
            {
                if (index == -1) Aluno = (DataRowView)AlunosBindingSource.AddNew();
                Aluno["Nome"] = Nome.Text;
                Aluno["Código RFID"] = CodigoRFID;
                Aluno["Aulas pagas"] = int.Parse(AulasPagas.Text);
                Aluno["Aluno_ativo"] = checkBox1.Checked;
                Aluno["horarios_aulas"] = horarios.Text;
                Aluno["Gênero"] = valores.genero[comboBox1.SelectedIndex];
                Aluno["historico_medico"] = historico_med.Text;
                Aluno["Telefone"] = telefone.Text;
                Aluno["Email"] = email.Text;
                Aluno["Histórico de aulas"] = HistoricoAulas.Text;
                Aluno["Registro de medições"] =  JsonConvert.SerializeObject(RMLista);
                Aluno["anotacoes"] = anotacoes.Text;
                Aluno["data_inscricao"] = data.Text;
                Aluno["historico"] = "Aluno cadastrado no dia " + DateTime.Now.ToShortDateString() + "\n";
                Aluno["ultima_entrada"] = string.Empty;
                if (index == -1)
                {
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                    AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                    this.Close();
                }
                else 
                {
                    if (AdicionarAoHistorico != "") Aluno[colunas.Historico] += DateTime.Now.ToShortDateString() + ": aluno editado :\n" + AdicionarAoHistorico;
                    this.Validate();
                    this.AlunosBindingSource.EndEdit();
                    this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
                }
            }        
            MessageBox.Show(((index == -1) ? "Aluno adicionado" : "Atualização feita") + " com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (index == -1) this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (index != -1 &&MessageBox.Show("Todas as alterações feitas ao aluno vão ser perdidas! Certeza que deseja continuar?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                    InicializarInformacoes();
            }
            else if (MessageBox.Show("Todas as informações já salvas do novo aluno serão perdidas! Certeza que deseja continuar?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                    AlunosTableAdapter.Fill(database_alunosDataSet.Alunos);
                    this.Close();
            }         
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
                if (index != -1) MessageBox.Show("Agora que esse aluno foi reativado, será necessário registrar um novo cartão para ele!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else return;
            }
            else if (index == -1) CodigoRFID = "0";
            else if (MessageBox.Show("Se esse aluno for desativado, não haverá mais um cartão associado a ele, e um novo terá de ser registrado. Tem certeza que deseja continuar?", "Aviso!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
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

        private void button2_Click(object sender, EventArgs e)
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RMPeso_TextChanged(object sender, EventArgs e)
        {
            if (RMPeso.Text == string.Empty) return;
            if (decimal.TryParse(RMPeso.Text, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMPeso.Text = "";
            }
        }

        private void RMGorduraCorporal_TextChanged(object sender, EventArgs e)
        {
            if (RMGorduraCorporal.Text == string.Empty) return;
            if (decimal.TryParse(RMGorduraCorporal.Text, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMGorduraCorporal.Text = "";
            }
        }

        private void RMMusculoEsqueletico_TextChanged(object sender, EventArgs e)
        {
            if (RMMusculoEsqueletico.Text == string.Empty) return;
            if (decimal.TryParse(RMMusculoEsqueletico.Text, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMMusculoEsqueletico.Text = "";
            }
        }

        private void RMGorduraVisceral_TextChanged(object sender, EventArgs e)
        {
            if (RMGorduraVisceral.Text == string.Empty) return;
            if (decimal.TryParse(RMGorduraVisceral.Text, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMGorduraVisceral.Text = "";
            }
        }

        private void RMIMC_TextChanged(object sender, EventArgs e)
        {
            if (RMIMC.Text == string.Empty) return;
            if (decimal.TryParse(RMIMC.Text, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMIMC.Text = "";
            }
        }

        private void RMDeletar_Click(object sender, EventArgs e)
        {
            int indice = RMLista.FindIndex(x => x.Data == RMData.Value);
            if (indice != -1)
            {
                if (MessageBox.Show("Tem certeza que deseja remover a medição do dia " + RMData.Value.ToShortDateString() + "?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    RMLista.RemoveAt(indice);
                    RMBindingSource.Clear();
                    RMLista.Sort((x, y) => x.Data.CompareTo(y.Data));
                    foreach (Medicao medicao in RMLista)
                    {
                        RMBindingSource.Add(medicao.ParaBS());
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há nenhuma medição registrada nesse dia!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RMData_ValueChanged(object sender, EventArgs e)
        {
            if (setup) return;
            int indice = RMLista.FindIndex(x => x.Data == RMData.Value);
            if (indice != -1)
            {
                MedicaoBS medicao = RMLista[indice].ParaBS();
                RMPeso.Text = medicao.SPeso;
                RMGorduraCorporal.Text = medicao.SGorduraCorporal;
                RMMusculoEsqueletico.Text = medicao.SMusculoEsqueletico;
                RMGorduraVisceral.Text = medicao.SGorduraVisceral;
                RMIMC.Text = medicao.SIMC;
            }
        }

        private void RMAdicionar_Click(object sender, EventArgs e)
        {
            decimal Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC;

            if (!decimal.TryParse(RMPeso.Text, out Peso)) 
            {
                MessageBox.Show("O campo Peso precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(RMGorduraCorporal.Text, out GorduraCorporal)) 
            {
                MessageBox.Show("O campo Gordura corporal precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(RMMusculoEsqueletico.Text, out MusculoEsqueletico)) 
            {
                MessageBox.Show("O campo Musculo esquelético precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(RMGorduraVisceral.Text, out GorduraVisceral)) 
            {
                MessageBox.Show("O campo Gordura visceral precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(RMIMC.Text, out IMC)) 
            {
                MessageBox.Show("O campo IMC precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Medicao MedicaoNova = new Medicao(RMData.Value, Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC);
            int indice = RMLista.FindIndex(x => x.Data == MedicaoNova.Data);
            if (indice != -1)
            {
                if (MessageBox.Show("Já existe uma medição para esse dia! tem certeza que deseja substitui-la?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    RMLista.RemoveAt(indice);
                }
                else return;
            }
            RMLista.Add(MedicaoNova);
            RMBindingSource.Clear();
            RMLista.Sort((x, y) => x.Data.CompareTo(y.Data));
            foreach (Medicao medicao in RMLista)
            {
                RMBindingSource.Add(medicao.ParaBS());
            }
            RMPeso.Text = string.Empty;
            RMGorduraCorporal.Text = string.Empty;
            RMMusculoEsqueletico.Text = string.Empty;
            RMGorduraVisceral.Text = string.Empty;
            RMIMC.Text = string.Empty;
        }
    }
}
