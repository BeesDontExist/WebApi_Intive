using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebClient_core.Models;
using WebClient_core.Helper;
namespace WebClient_core
{
    class Program
    {   
        static HttpClient client= new HttpClient();
        static void ShowFizzBuzz(FizzBuzzElement element)
        {
            Console.WriteLine($"FizzBuzz: Number: {element.Number}, Response: {element.Response}");
        }
        static async Task<FizzBuzzElement> GetFizzBuzzAsync(int number)
        {
            //HttpClient client = _apiClient.Init(); 
            FizzBuzzElement fizzBuzzResult = null;
            HttpResponseMessage response = await client.GetAsync($"api/fizzbuzz/{number}");
            if (response.IsSuccessStatusCode)
            {
                fizzBuzzResult = await response.Content.ReadAsAsync<FizzBuzzElement>();
            }
            return fizzBuzzResult;
        }
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            FizzBuzzElement element = new FizzBuzzElement();
            element = await GetFizzBuzzAsync(6);
            ShowFizzBuzz(element);
        }
    }
}
