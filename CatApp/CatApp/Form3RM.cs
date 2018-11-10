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
using System.Globalization;
namespace CatApp
{
    public partial class FormEditarAluno
    {
        private BindingSource RMBindingSource;
        private List<Medicao> RMLista;
        NumberStyles RMEstilo = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
        CultureInfo RMCultura = CultureInfo.CreateSpecificCulture("pt-BR");
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

        private void CarregarRM()
        {
            if ((string)Aluno[colunas.RegistroMedicoes] != "-")
            {
                RMLista = JsonConvert.DeserializeObject<List<Medicao>>((string)Aluno[colunas.RegistroMedicoes]);
                RMLista.Sort((x, y) => x.Data.CompareTo(y.Data));
                foreach (Medicao medicao in RMLista)
                {
                    RMBindingSource.Add(medicao.ParaBS());
                }
            }
            else RMLista = new List<Medicao>();
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
        private void RMPeso_TextChanged(object sender, EventArgs e)
        {
            if (RMPeso.Text == string.Empty) return;
            if (decimal.TryParse(RMPeso.Text, RMEstilo, RMCultura, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMPeso.Text = "";
            }
        }

        private void RMGorduraCorporal_TextChanged(object sender, EventArgs e)
        {
            if (RMGorduraCorporal.Text == string.Empty) return;
            if (decimal.TryParse(RMGorduraCorporal.Text, RMEstilo, RMCultura, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMGorduraCorporal.Text = "";
            }
        }

        private void RMMusculoEsqueletico_TextChanged(object sender, EventArgs e)
        {
            if (RMMusculoEsqueletico.Text == string.Empty) return;
            if (decimal.TryParse(RMMusculoEsqueletico.Text, RMEstilo, RMCultura, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMMusculoEsqueletico.Text = "";
            }
        }

        private void RMGorduraVisceral_TextChanged(object sender, EventArgs e)
        {
            if (RMGorduraVisceral.Text == string.Empty) return;
            if (decimal.TryParse(RMGorduraVisceral.Text, RMEstilo, RMCultura, out decimal resultado)) return;
            else
            {
                MessageBox.Show("Esse campo só aceita números inteiros ou decimais!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RMGorduraVisceral.Text = "";
            }
        }

        private void RMIMC_TextChanged(object sender, EventArgs e)
        {
            if (RMIMC.Text == string.Empty) return;
            if (decimal.TryParse(RMIMC.Text, RMEstilo, RMCultura, out decimal resultado)) return;
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
            if (!decimal.TryParse(RMPeso.Text, RMEstilo, RMCultura, out Peso))
            {
                MessageBox.Show("O campo Peso precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(RMGorduraCorporal.Text, RMEstilo, RMCultura, out GorduraCorporal))
            {
                MessageBox.Show("O campo Gordura corporal precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(RMMusculoEsqueletico.Text, RMEstilo, RMCultura, out MusculoEsqueletico))
            {
                MessageBox.Show("O campo Musculo esquelético precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(RMGorduraVisceral.Text, RMEstilo, RMCultura, out GorduraVisceral))
            {
                MessageBox.Show("O campo Gordura visceral precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(RMIMC.Text, RMEstilo, RMCultura, out IMC))
            {
                MessageBox.Show("O campo IMC precisa conter um número decimal!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Medicao MedicaoNova = new Medicao(RMData.Value.Date, Peso, GorduraCorporal, MusculoEsqueletico, GorduraVisceral, IMC);
            int indice;
            if (RMLista.Count == 0) indice = -1;
            else indice = RMLista.FindIndex(x => x.Data == MedicaoNova.Data);
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
            lock (TravaAtualizacao)
            {
                Aluno["Registro de medições"] = JsonConvert.SerializeObject(RMLista);
                this.Validate();
                this.AlunosBindingSource.EndEdit();
                this.AlunosTableAdapterManager.UpdateAll(this.database_alunosDataSet);
            }
            RMPeso.Text = string.Empty;
            RMGorduraCorporal.Text = string.Empty;
            RMMusculoEsqueletico.Text = string.Empty;
            RMGorduraVisceral.Text = string.Empty;
            RMIMC.Text = string.Empty;
        }
    }

}
