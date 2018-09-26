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
            pictureBox1.Load("..\\..\\..\\spinner0.png");
            var thread = new Thread(() => procurar());
            thread.Start();
        }

        private void procurar()
        {

            lock (trava)
            {
                while (encontrou != -1 && !fechar && !IsDisposed)
                {
                    string ret = ClienteREST.makeRequest(Comandos.readme);
                    if (ret == "falhou")
                    {
                        toolStripStatusLabel1.Text = "Erro na comunicação com a porta!";
                    }
                    else
                    {
                        retornoRFID retorno = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<retornoRFID>(ret);

                        if (retorno.variables.rfid_uid != "")
                        {
                            encontrou = -1;
                            rfiduid = retorno.variables.rfid_uid;
                        }
                        else
                        {
                            Thread.Sleep(50);
                            spinner_imagem = ((spinner_imagem == 11) ? 0 : spinner_imagem + 1);
                            pictureBox1.Load("..\\..\\..\\spinner" + spinner_imagem + ".png");
                            toolStripStatusLabel1.Text = "tentativa número " + encontrou++;
                        }
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

        private void FormPegarID_Load(object sender, EventArgs e)
        {

        }
    }
}
