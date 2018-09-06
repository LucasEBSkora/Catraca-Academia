using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CatApp
{
    public class Variables
    {
       public string rfid_uid { get; set;}
    }
    public class retornoRFID
    {
        public Variables variables { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string hardware { get; set; }
        public string connected { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static ClienteREST cliente = new ClienteREST();
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cliente.endereco = "http://192.168.0.26/";
            //cliente.makeRequest(Comandos.ledOn);
            Application.Run(new Form1(ref cliente));
        }
    }
}
