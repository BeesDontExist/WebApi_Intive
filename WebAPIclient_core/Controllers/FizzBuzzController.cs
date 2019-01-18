using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIclient_core.Helper;
using System.Net.Http;
using WebAPIclient_core.Models;
using Newtonsoft.Json;

namespace WebAPIclient_core.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly FizzBuzzAPIClient _apiClient = new FizzBuzzAPIClient();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Generate(int number)
        {
            HttpClient client = _apiClient.Init();
            FizzBuzzElement fizzBuzzElement = new FizzBuzzElement();
            HttpResponseMessage response = await client.GetAsync($"api/FizzBuzz/{number}");
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                fizzBuzzElement = JsonConvert.DeserializeObject<FizzBuzzElement>(result);
            }
            return View(fizzBuzzElement);
        }
    }
}