using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;

namespace MVCAuto.Monitoring
{
    public class CustomWebEvents : Page, IHttpModule
    {

        public override void Dispose()
        {
        }

        // Add event handlers to the HttpApplication.
        public new void Init(HttpApplication httpApp)
        {
            httpApp.BeginRequest +=
                new EventHandler(OnBeginRequest);

            httpApp.EndRequest +=
                new EventHandler(OnEndRequest);

        }

        // Issues a custom begin request event.
        public void OnBeginRequest(Object sender, EventArgs e)
        {

            HttpApplication httpApp = sender as HttpApplication;

            try
            {
                // Make sure to be outside the forbidden range.
                System.Int32 myCode = WebEventCodes.WebExtendedBase + 30;
                SampleWebRequestEvent swre =
                  new SampleWebRequestEvent(
                  "SampleWebRequestEvent Start", this, myCode);
                // Raise the event.
                swre.Raise();
            }
            catch (Exception ex)
            {
                httpApp.Context.Response.Output.WriteLine(
                    ex.ToString());
            }

        }

        // Issues a custom end request event.
        public void OnEndRequest(Object sender, EventArgs e)
        {
            HttpApplication httpApp = sender as HttpApplication;

            try
            {
                // Make sure to be outside the forbidden range.
                System.Int32 myCode = WebEventCodes.WebExtendedBase + 40;
                SampleWebRequestEvent swre =
                  new SampleWebRequestEvent(
                  "SampleWebRequestEvent End", this, myCode);
                // Raise the event.
                swre.Raise();
            }
            catch (Exception ex)
            {
                httpApp.Context.Response.Output.WriteLine(
                    ex.ToString());
            }

        }
    }
}