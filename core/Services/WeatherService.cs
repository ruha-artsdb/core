using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using core.Models;
using Newtonsoft.Json;

namespace core.Services
{
    public class WeatherService
    {
        HttpClient _client;


        public WeatherService()
        {
            _client = new HttpClient();
        }
        public async Task<WeatherResponse> GetWeatherData(string query)
        {
            WeatherResponse weatherData = null;
           
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherResponse>(content);
                }
            
            

            return weatherData;
        }
    }




}


