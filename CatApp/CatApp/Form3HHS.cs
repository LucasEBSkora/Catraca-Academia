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
    public class EntradaHistorico
    {
        public DateTime Data;
        public string Entrada;
        public EntradaHistorico(DateTime data, string entrada)
        {
            Data = data;
            Entrada = entrada;
        }
        public EntradaHistoricoBS ParaBS()
        {
            return new EntradaHistoricoBS(Data, Entrada);
        }

    }
    public class EntradaHistoricoBS
    {

        string Data, Entrada;
        public EntradaHistoricoBS(DateTime data, string entrada)
        {
            Data = data.ToShortDateString();
            Entrada = entrada;
        }
        public string SData { get => Data; }
        public string SEntrada { get => Entrada; }
    }
    public partial class FormEditarAluno
    {

        List<EntradaHistorico> HLista, HALista;
        BindingSource HBindingSource, HABindingSource;
        private void CarregarHHA()
        {
            if ((string)Aluno[colunas.HistoricoAulas] != "-")
            {
                HALista = JsonConvert.DeserializeObject<List<EntradaHistorico>>((string)Aluno[colunas.HistoricoAulas]);
                HALista.Sort((x, y) => x.Data.CompareTo(y.Data));
                foreach (EntradaHistorico entrada in HALista)
                {
                    HABindingSource.Add(entrada.ParaBS());
                }
            }
            else HALista = new List<EntradaHistorico>();

            if ((string)Aluno[colunas.Historico] != "-")
            {
                HLista = JsonConvert.DeserializeObject<List<EntradaHistorico>>((string)Aluno[colunas.Historico]);
                HLista.Sort((x, y) => x.Data.CompareTo(y.Data));
                foreach (EntradaHistorico entrada in HLista)
                {
                    HBindingSource.Add(entrada.ParaBS());
                }
            }
            else HLista = new List<EntradaHistorico>();
        }

        private void InicializarHHA()
        {
            HBindingSource = new BindingSource();
            HTabela.DataSource = HBindingSource;
            HTabela.AutoGenerateColumns = false;

            DataGridViewColumn HData = new DataGridViewTextBoxColumn();
            HData.DataPropertyName = "SData";
            HData.Width = 70;
            HData.Name = "Data";
            HTabela.Columns.Add(HData);
            

            DataGridViewColumn HEntrada = new DataGridViewTextBoxColumn();
            HEntrada.DataPropertyName = "SEntrada";
            HEntrada.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HEntrada.Name = "Entrada";
            HEntrada.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            HTabela.Columns.Add(HEntrada);

            HABindingSource = new BindingSource();
            HATabela.DataSource = HABindingSource;
            HATabela.AutoGenerateColumns = false;

            DataGridViewColumn HAData = new DataGridViewTextBoxColumn();
            HAData.DataPropertyName = "SData";
            HAData.Width = 70;
            HAData.Name = "Data";
            HATabela.Columns.Add(HAData);

            DataGridViewColumn HAEntrada = new DataGridViewTextBoxColumn();
            HAEntrada.DataPropertyName = "SEntrada";
            HAEntrada.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HAEntrada.Name = "Entrada";
            HAEntrada.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            HATabela.Columns.Add(HAEntrada);
        }

        private void HAData_ValueChanged(object sender, EventArgs e)
        {
            if (setup) return;
            int indice = HALista.FindIndex(x => x.Data == HAData.Value);
            if (indice != -1)
            {
                HARegistro.Text = HALista[indice].Entrada;
            }
        }

        private void HAAdicionar_Click(object sender, EventArgs e)
        {
            if (HARegistro.Text == string.Empty)
            {
                MessageBox.Show("Não é possível adicionar um registro vazio!", "cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            EntradaHistorico entradaNova = new EntradaHistorico(HAData.Value.Date, HARegistro.Text);
            MessageBox.Show(entradaNova.Data.ToLongDateString());
            int indice = HALista.FindIndex(x => x.Data == entradaNova.Data);
            if (indice != -1)
            {
                if (MessageBox.Show("Já existe um registro de aula para esse dia! tem certeza que deseja substitui-lo?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    HALista.RemoveAt(indice);
                }
                else return;
            }
            HALista.Add(entradaNova);
            HABindingSource.Clear();
            HALista.Sort((x, y) => x.Data.CompareTo(y.Data));
            foreach (EntradaHistorico entrada in HALista)
            {
                HABindingSource.Add(entrada.ParaBS());
            }
            lock (TravaAtualizacao)
            {
                Aluno[colunas.HistoricoAulas] = JsonConvert.SerializeObject(HALista);
                this.Validate();
                this.AlunosBindingSource.EndEdit();
                this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
            }
        }

        private void HADeletar_Click(object sender, EventArgs e)
        {
            int indice = HALista.FindIndex(x => x.Data == HAData.Value);
            if (indice != -1)
            {


                if (MessageBox.Show("Tem certeza que deseja remover a medição do dia " + HAData.Value.ToShortDateString() + "?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    HALista.RemoveAt(indice);
                    HABindingSource.Clear();
                    HALista.Sort((x, y) => x.Data.CompareTo(y.Data));
                    foreach (EntradaHistorico entrada in HALista)
                    {
                        HABindingSource.Add(entrada.ParaBS());
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há nenhuma medição registrada nesse dia!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}


