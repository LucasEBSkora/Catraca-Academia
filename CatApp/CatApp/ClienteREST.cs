using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CatApp
{

    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public enum Comandos
    {
        rejeitado,
        abrir,
        semcredito,
        readme,
        go_home
    }
    public static class ClienteREST
    {
        private const bool ModoDebug = false;
        public static string endereco;

        public static string makeRequest(Comandos comando, int AulasPagasRestantes = 0)
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endereco + ((ModoDebug) ? "jsonSim/db" : comando.ToString()) + ((comando == Comandos.abrir) ? ("?command=" + AulasPagasRestantes) : String.Empty));
            request.Method = httpVerb.GET.ToString();
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("error code:" + response.StatusCode.ToString());
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                strResponseValue = "falhou";
            }
            return strResponseValue;
        }
    }
}
