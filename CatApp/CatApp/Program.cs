using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
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
        static public string port { get; set; }
        static public DateTime hora_abre { get; set; }
        static public DateTime hora_fecha { get; set; }

    }
    static class utilidades
    {
        public static string[] genero = { "Masculino", "Feminino", "Outro(a)" };
        public enum adeqSituacoes{
            ao,
            ae,
            aaao

        }
        public static string adeq(DataRowView Aluno, adeqSituacoes adeq)
        {
            switch (adeq)
            {
                case adeqSituacoes.ao:
                    if ((string)Aluno[colunas.Genero] == "Feminino") return "a";
                    else return "o";
                case adeqSituacoes.ae:
                    if ((string)Aluno[colunas.Genero] == "Feminino") return "a";
                    else return "e";
                case adeqSituacoes.aaao:
                    if ((string)Aluno[colunas.Genero] == "Feminino") return "à";
                    else return "ao";
                default:
                    return "x";
            }

        }
    }


    public static class colunas
    {
        public const string Codigo           = "Código";
        public const string CodigoRFID       = "Código RFID";
        public const string Nome             = "Nome";
        public const string AulasPagas       = "Aulas pagas";
        public const string AlunoAtivo       = "Aluno_ativo";
        public const string UltimaEntrada    = "ultima_entrada";
        public const string Historico        = "historico";
        public const string historicoMedico  = "historico_medico";
        public const string Anotacoes        = "anotacoes";
        public const string HorariosAulas    = "horarios_aulas";
        public const string dataInscricao    = "data_inscricao";
        public const string Genero           = "Gênero";
        public const string Telefone         = "Telefone";
        public const string Email            = "Email";
        public const string HistoricoAulas   = "Histórico de aulas";
        public const string RegistroMedicoes = "Registro de medições";
        public const string Aniversario      = "Aniversario";
        public const string NumeroCartao     = "NumeroCartao";
        public const string Idade            = "Idade";


    }


    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            config.port = ConfigurationManager.AppSettings.Get("PORT");
            config.hora_abre = DateTime.Parse(ConfigurationManager.AppSettings.Get("abre"));
            config.hora_fecha = DateTime.Parse(ConfigurationManager.AppSettings.Get("fecha"));

            Servidor.Port = config.port;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
