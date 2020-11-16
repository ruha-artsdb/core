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
using Microsoft.Extensions.Configuration;


namespace core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {

        private static IConfiguration _configuration;

        public WeatherService weatherService = new WeatherService();

        public WeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string key = _configuration["weather"];
            string query = $"https://api.openweathermap.org/data/2.5/weather?q=trondheim&appid={key}&units=metric";
            WeatherResponse results = weatherService.GetWeatherData(query).Result;
            
            

            var viewModel = new WeatherViewModel {Weather = results };
            return View(viewModel);




        }

    }
}
