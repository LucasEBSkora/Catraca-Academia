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
        go_home,
        jsonSim //usado para desenvolvimento apenas
    }
    public static class ClienteREST
    {
        public static string endereco = "https://my-json-server.typicode.com/LucasEBSkora/" /*"http://192.168.0.59/"*/;

        public static string makeRequest(Comandos comando)
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endereco + comando.ToString() + ((comando == Comandos.jsonSim) ? "/db" : string.Empty));
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
