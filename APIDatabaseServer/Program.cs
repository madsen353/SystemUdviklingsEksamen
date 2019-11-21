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

        static List<string> GetAllCategories()
        {
            List<string> allCategories = new List<string>();
            allCategories.Add("outdoor");
            allCategories.Add("sportsboth");
            allCategories.Add("sportcompetition");
            allCategories.Add("ball");
            allCategories.Add("team");
            allCategories.Add("teamboth");
            allCategories.Add("indoor");
            allCategories.Add("gym");
            allCategories.Add("fitness");
            allCategories.Add("single");
            allCategories.Add("typeother");
            allCategories.Add("water");
            allCategories.Add("cycling");
            allCategories.Add("sportnature");
            allCategories.Add("sportboth sportcompetition");
            allCategories.Add("ride");
            allCategories.Add("running");
            return allCategories;
        }
        static async Task GetDataFromSkivePortalen()
        {
            client.BaseAddress = new Uri("https://www.flyttilskive.dk/umbraco/surface/Search/GetActivity");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> categories = GetAllCategories();
            foreach (string category in categories)
            {
                try
                {
                    RequestBody requestBody = new RequestBody("natur", category);
                    List<ServerBasedSportsObject> sportsObjectTodisplay = await APITools.GetSportsObjectAsync("https://www.flyttilskive.dk/umbraco/surface/Search/GetActivity", client, requestBody);
                    foreach (ServerBasedSportsObject item in sportsObjectTodisplay)
                    {
                        Console.WriteLine(item.title);
                        DAL dal = new DAL();
                        dal.InsertActivityToDb(item);
                    }
                }
                catch (Exception e)
                {
                }
            }        
        }
    }
}
