using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using core.Models;
using core.Services;


namespace core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        public WeatherService _ws = new WeatherService();
        
        public IActionResult Index()
        {
            string query = "https://api.openweathermap.org/data/2.5/weather?q=trondheim&appid=0442feadee67c41faa51ec591951bc61";
            WeatherResponse results = _ws.GetWeatherData(query).Result;

            var viewModel = new WeatherViewModel {Weather = results };
            return View(viewModel);


            //client.BaseAddress = new Uri("http://api.openweathermap.org");
            //var response = await client.GetAsync($"/data/2.5/weather?q=trondheim&appid=0442feadee67c41faa51ec591951bc61");
            //response.EnsureSuccessStatusCode();

            //var stringResult = await response.Content.ReadAsStringAsync();
            //var viewModel = new WeatherViewModel {Weather = response };
            //return View(viewModel);



        }
    }
}
