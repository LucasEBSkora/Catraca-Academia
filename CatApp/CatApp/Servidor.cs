using System;
using System.Net;

namespace CatApp
{
    public static class Servidor
    {
        static private string port;
        static bool ligado = false;
        static private string ip;

        static public string Port
        {
            get => port;
            set
            {
                if (port != value)
                {
                    if (listener != null) Stop();
                    listener = new HttpListener();
                    String[] prefixos = { $"http://localhost:{value}/", $"http://{ip}:{value}/", $"http://*:{value}/" };
                    foreach (string s in prefixos) listener.Prefixes.Add(s);

                    if (ligado) Start();
                }

                port = value;
            }
        }
        public static string Ip { get => ip; set {
                if (ip != value)
                {
                    if (listener != null) Stop();
                    listener = new HttpListener();
                    String[] prefixos = { $"http://localhost:{port}/", $"http://{value}:{port}/", $"http://*:{port}/" };
                    foreach (string s in prefixos) listener.Prefixes.Add(s);

                    if (ligado) Start();
                }
                ip = value;
            } }

        public static void setBoth(String Ip, String Port)
        {
            ip = Ip;
            port = Port;

            if (listener != null) Stop();
            listener = new HttpListener();
            String[] prefixos = { $"http://localhost:{port}/", $"http://{ip}:{port}/", $"http://*:{port}/" };
            foreach (string s in prefixos) listener.Prefixes.Add(s);

            if (ligado) Start();


        }


    static HttpListener listener = null;
        public delegate string ResponseGenerator(HttpListenerRequest request);

        static ResponseGenerator _responseGenerator = null;

        public static ResponseGenerator responseGenerator { get => _responseGenerator; set { _responseGenerator = value; } }


        public static void Start()
        {
            if (listener != null && _responseGenerator != null)
            {
                ligado = true;
                listener.Start();
                listener.BeginGetContext(AsyncListener, listener);
            }
        }

        public static void Stop()
        {
            ligado = false;
            listener.Stop();
        }
        public static void AsyncListener(IAsyncResult result)
        {
            
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;
                // Call EndGetContext to complete the asynchronous operation.
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = _responseGenerator(request);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                if (output != null) output.Close();
                listener.BeginGetContext(AsyncListener, listener);
            }
            catch {

            }
            finally
            {
            }
            // You must close the output stream.
        }
    }
}

