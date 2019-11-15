using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using APIDatabaseServer.ObjectTypes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace APIDatabaseServer
{
    public class Program
    {
        //Should be contained in config file i guess
        static HttpClient client = new HttpClient();
        public static void Main(string[] args)
        {
            //GetDataFromSkivePortalen().GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        static async Task GetDataFromSkivePortalen()
        {
            client.BaseAddress = new Uri("https://www.flyttilskive.dk/umbraco/surface/Search/GetActivity");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            //Foreach
            try
            {
                RequestBody requestBody = new RequestBody("natur", "ball");
                List<ServerBasedSportsObject> sportsObjectTodisplay = await APITools.GetSportsObjectAsync("https://www.flyttilskive.dk/umbraco/surface/Search/GetActivity", client, requestBody);
                foreach (ServerBasedSportsObject item in sportsObjectTodisplay)
                {
                    Console.WriteLine(item.title);
                    DAL dal = new DAL();
                    dal.InsertActivityToDb(item);
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
