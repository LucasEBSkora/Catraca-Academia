using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace CatApp
{
    public partial class Configurações : Form
    {
        public Configurações()
        {
            InitializeComponent();
            endereco.Text = config.endereco;
            HoraAbre.Value = config.hora_abre;
            HoraFecha.Value = config.hora_fecha;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration("CatApp.exe");
            if (endereco.Text != config.endereco)
            {
                configFile.AppSettings.Settings["IP"].Value = endereco.Text;
                config.endereco = endereco.Text;
                ClienteREST.endereco = endereco.Text;
            }
            if (HoraAbre.Value.ToShortTimeString() != config.hora_abre.ToShortTimeString())
            {
                configFile.AppSettings.Settings["abre"].Value = HoraAbre.Value.ToShortTimeString();
                config.hora_abre = HoraAbre.Value;
            }
            if (HoraFecha.Value.ToShortTimeString() != config.hora_fecha.ToShortTimeString())
            {
                configFile.AppSettings.Settings["fecha"].Value = HoraFecha.Value.ToShortTimeString();
                config.hora_fecha = HoraFecha.Value;
            }
            configFile.Save();
            MessageBox.Show("As novas configurações foram salvas corretamente!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void Cancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
