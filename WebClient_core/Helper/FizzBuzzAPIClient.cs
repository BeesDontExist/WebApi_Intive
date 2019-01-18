using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebClient_core.Helper
{
    public class FizzBuzzAPIClient
    {
        public HttpClient Init()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
    }
}
