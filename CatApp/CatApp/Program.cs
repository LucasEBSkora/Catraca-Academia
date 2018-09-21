using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

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
    static class config {
        static public string endereco { get; set; }
        static public DateTime hora_abre { get; set; }
        static public DateTime hora_fecha { get; set; }

    }

    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            config.endereco = ConfigurationManager.AppSettings.Get("IP");
            config.hora_abre = DateTime.Parse(ConfigurationManager.AppSettings.Get("abre"));
            config.hora_fecha = DateTime.Parse(ConfigurationManager.AppSettings.Get("fecha"));
            ClienteREST.endereco = config.endereco;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //cliente.makeRequest(Comandos.ledOn);
            Application.Run(new Form1());
        }
    }
}
