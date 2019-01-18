using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_core.Models
{ 
    public class FizzBuzzElement
    {
        public string Response { get; set; }
        public int Number { get; set; }
        public string GenerateResponse()
        {
            if (Number % 6 == 0)
            {
                Response = "FizzBuzz";
                return Response;
            }
            else if (Number % 2 == 0)
            {
                Response = "Fizz";
                return Response;
            }
            else if (Number % 3 == 0)
            {
                Response = "Buzz";
                return Response;
            }
            else
            {
                Response = "Indivisible";
                return Response;
            }
        }
    }
}
