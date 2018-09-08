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
        ledOn,
        ledOff,
        readme,
        jsonSim //usado para desenvolvimento apenas
    }
    public class ClienteREST
    {
        public string endereco { get; set; }
        public httpVerb httpMethod { get; set; }

        public ClienteREST()
        {
            endereco = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest(Comandos comando)
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endereco + comando.ToString() + ((comando == Comandos.jsonSim) ? "/db" : string.Empty));
            request.Method = httpMethod.ToString();

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code:" + response.StatusCode.ToString());
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            } 
            return strResponseValue;
        }
    }
}
