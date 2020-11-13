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
            porta.Text = config.port;
            textBoxIP.Text = config.ip;
            HoraAbre.Value = config.hora_abre;
            HoraFecha.Value = config.hora_fecha;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration("CatApp.exe");
            if (porta.Text != config.port)
            {
                configFile.AppSettings.Settings["PORT"].Value = porta.Text;
                config.port = porta.Text;
                Servidor.Port = porta.Text;
            }
            if (textBoxIP.Text != config.ip)
            {
                configFile.AppSettings.Settings["IP"].Value = textBoxIP.Text;
                config.ip = textBoxIP.Text;
                Servidor.Ip = textBoxIP.Text;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
