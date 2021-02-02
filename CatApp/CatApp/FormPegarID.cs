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
using System.Net;

namespace CatApp
{
    public partial class FormPegarID : Form
    {
        public string rfiduid;
        public int encontrou;
        int spinner_imagem;
        public bool fechar;
        readonly object trava;
        private Servidor.ResponseGenerator outra;
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
            var thread = new Thread(() => spinner());
            thread.Start();
            outra = Servidor.responseGenerator;
            Servidor.responseGenerator = procurar;
        }

        private string procurar(HttpListenerRequest value)
        {
            string ID = value.RawUrl.Substring(1);
            if (ID.Length == 0) return "empty\n";
            else
            {
                encontrou = -1;
                rfiduid = ID;
                return "lido\n";
            }
        }


        private void spinner()
        {

            while (encontrou != -1 && !fechar && !IsDisposed)
            {
                Thread.Sleep(50);
                spinner_imagem = ((spinner_imagem == 11) ? 0 : spinner_imagem + 1);
                pictureBox1.Load("..\\..\\..\\spinner" + spinner_imagem + ".png"); 
            }
            Servidor.responseGenerator = outra;
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
