using Microsoft.Owin;
using Owin;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Webserver.ObjectTypes;

[assembly: OwinStartupAttribute(typeof(Webserver.Startup))]
namespace Webserver
{
    public partial class Startup
    {
        static HttpClient client = new HttpClient();
        public void Configuration(IAppBuilder app)
        {
            GetDataFromSkivePortalen();
            //ConfigureAuth(app);
        }

        static async Task GetDataFromSkivePortalen()
        {
            client.BaseAddress = new Uri("https://localhost:44396/sportsactivity");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    List<ServerBasedSportsObject> sportsObjectTodisplay = await APITools.GetSportsObjectAsync("https://localhost:44396/sportsactivity", client);
                    foreach (ServerBasedSportsObject item in sportsObjectTodisplay)
                    {
                        Console.WriteLine(item.title);
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
        }
    }
}
