using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using APIDatabaseServer.ObjectTypes;
using System.Net;

namespace APIDatabaseServer
{
    public class APITools
    {

        public static void ShowSportsObject(ServerBasedSportsObject sportsObjectToDisplay)
        {
            Console.WriteLine($"Name: {sportsObjectToDisplay.title}");
        }

        public static async Task<List<ServerBasedSportsObject>> GetSportsObjectAsync(string path, HttpClient client, RequestBody requestBody)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(path),
                Content = new StringContent(requestBody.Syntax),
            };
            List<ServerBasedSportsObject> objectsToDownload = null;
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                //var jsonString = await response.Content.
                var jsonString = await response.Content.ReadAsStringAsync();
                //jsonString.Wait();
                objectsToDownload = JsonConvert.DeserializeObject<List<ServerBasedSportsObject>>(jsonString);
                // objectsToDownload = await response.Content.ReadAsAsync<ServerBasedSportsObject>();               
            }
            return objectsToDownload;
        }

    }
}
