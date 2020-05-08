using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EmbedIO;
using WebSocketSharp.Server;

namespace FSXWebService
{
    /// <summary> 监听 WebSocket </summary>
    class WSFSUIPC : WebSocketBehavior
    {

    }

    /// <summary> Web Service </summary>
    class LocalWebServer
    {
        public LocalWebServer(int port, String serviceDirectory)
        {
            Port = port;
            ServingFromDirectory = serviceDirectory;
        }

        public void StartWebService()
        {
            Task t = new Task(ServiceThreadProc);
            t.Start();
        }

        private void ServiceThreadProc()
        {
            using (WebServer server = new WebServer("http://*:" + Port + "/"))
            {
                server.WithLocalSessionManager()
                    .WithStaticFolder("/", ServingFromDirectory, true, m =>
                    {
                        m.ClearCache();
                        m.ContentCaching = false;
                        m.DefaultExtension = ".html";
                        m.DefaultDocument = "index.html";
                    });

                server.RunAsync();
                Thread.Sleep(Timeout.Infinite);
            }
        }

        public int Port
        {
            get;
            set;
        }

        public String ServingFromDirectory
        {
            get;
            set;
        }
    }
}
