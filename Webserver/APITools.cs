using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webserver.ObjectTypes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
namespace Webserver
{
    public class APITools
    {
        public static void ShowSportsObject(ServerBasedSportsObject sportsObjectToDisplay)
        {
            Console.WriteLine($"Name: {sportsObjectToDisplay.title}");
        }

        public static async Task<List<ServerBasedSportsObject>> GetSportsObject(string path, HttpClient client)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(path),
            };
            List<ServerBasedSportsObject> objectsToDownload = null;
            //HttpResponseMessage response = await client.SendAsync(request);
            HttpResponseMessage response =  await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                //jsonString.Wait();
                objectsToDownload = JsonConvert.DeserializeObject<List<ServerBasedSportsObject>>(jsonString);
                // objectsToDownload = await response.Content.ReadAsAsync<ServerBasedSportsObject>();               
            }
            return objectsToDownload;
        }
    }
}