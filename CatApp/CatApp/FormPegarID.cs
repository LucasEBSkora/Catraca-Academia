using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace CatApp
{
    public partial class FormPegarID : Form
    {
        public string rfiduid;
        public int encontrou;
        int spinner_imagem;
        public bool fechar;
        object trava;
        private void button1_Click(object sender, EventArgs e)
        {
            fechar = true;
        }

        public FormPegarID(ref object Trava)
        {

            InitializeComponent();
            ControlBox = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            trava = Trava;
            rfiduid = "";
            encontrou = 0;
            spinner_imagem = 0;
            fechar = false;
            var thread = new Thread(() => procurar());
            thread.Start();
        }

        private void procurar()
        {
            lock (trava)
            {
                while (encontrou != -1 && !fechar && !IsDisposed)
                {
                    retornoRFID retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ClienteREST.makeRequest(Comandos./*readme*/jsonSim, 0));
                    //MessageBox.Show(retorno.variables.rfid_uid);
                    if (retorno.variables.rfid_uid != "")
                    {
                        encontrou = -1;
                        rfiduid = retorno.variables.rfid_uid;
                    }
                    else
                    {
                        Thread.Sleep(100);
                        spinner_imagem = ((spinner_imagem == 11) ? 0 : spinner_imagem + 1);
                        pictureBox1.ImageLocation = "C:\\Users\\skora\\OneDrive\\Catraca Academia\\CatApp\\spinner" + spinner_imagem + ".png";
                        toolStripStatusLabel1.Text = "tentativa número " + encontrou++;
                    }
                }
            }
            if (!IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate
                {
                   this.Close();
                });
            }
        }
    }
}
