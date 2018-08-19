﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CatApp
{
    
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
            cliente.makeRequest(Comandos.ledOn);
            Application.Run(new Form1());
        }
    }
}
