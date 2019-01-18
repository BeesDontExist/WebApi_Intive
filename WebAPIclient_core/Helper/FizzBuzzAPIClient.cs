using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPIclient_core.Helper
{
    public class FizzBuzzAPIClient
    {
        public HttpClient Init()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44320/");
            return Client;
        }
    }
}
