using Microsoft.Owin;
using MVCAuto.Models;
using Owin;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(MVCAuto.Startup))]
namespace MVCAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

          //  HttpConfiguration httpConfig = new HttpConfiguration();

           // ConfigureOAuthTokenGeneration(app);

          //  ConfigureWebApi(httpConfig);

            ConfigureAuth(app);

          //  app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

         //   app.UseWebApi(httpConfig);


        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            ////форматирует первую букву  в именах полей json файле с маленькой буквы return-json-with-lower-case-first-letter-of-property-names
            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //    jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            ////форматирует первую букву  в именах полей json файле с большой буквы return-json-with-lower-case-first-letter-of-property-names
            //var jsonFormatter = new JsonMediaTypeFormatter();
            //httpConfiguration.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
           // jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


        }
    }
}
