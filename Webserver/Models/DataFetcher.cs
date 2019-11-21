using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Webserver.ObjectTypes;

namespace Webserver.Models
{
    
    public static class DataFetcher
    {
        static HttpClient client = new HttpClient();
    
        public static async Task<List<ServerBasedSportsObject>> GetDataFromSkivePortalen(string url= "https://localhost:44396/sportsactivity")
        {
            //client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            List<ServerBasedSportsObject> sportsObjectTodisplay = new List<ServerBasedSportsObject>();
            try
            {
                sportsObjectTodisplay = await APITools.GetSportsObject(url, client);
            }
            catch (Exception e)
            {
            }
            return sportsObjectTodisplay;
        }
    }
    
}