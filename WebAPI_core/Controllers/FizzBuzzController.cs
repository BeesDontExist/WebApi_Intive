using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_core.Models;

namespace WebAPI_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        //GET: api/FizzBuzz/{number}
        [HttpGet("{number}")]
        public FizzBuzzElement GetFizzBuzz(int number)
        {
            FizzBuzzElement fizz = new FizzBuzzElement();
            fizz.Number = number;
            fizz.GenerateResponse();
            return fizz;
        }
    }
}