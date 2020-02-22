using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCAuto.Monitoring
{
    public class LoginModule:IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(App_BeginRequest);
            app.EndRequest += new EventHandler(App_EndRequest);
        }

        public void App_BeginRequest(object source, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\workspace\requestLog.txt", true);
            sw.WriteLine("Begin request called at " + DateTime.Now.ToString());
            sw.Close();
        }

        public void App_EndRequest(object source, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\workspace\requestLog.txt", true);
            sw.WriteLine("End request called at " + DateTime.Now.ToString());
            sw.Close();
        }

        public void Dispose()
        {
        }
    }
}