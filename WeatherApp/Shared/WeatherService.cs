using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shared {
    public class WeatherService {
        const string apiKey = "I wont tell you! :D";
        public IWeatherView weatherView;
        public WeatherService(IWeatherView weatherView) {
            this.weatherView = weatherView;
        }
        public async void GetWeatherForCityAsync(string city) {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://api.weatherstack.com/current?access_key={apiKey}&query={city}");
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(content);
                weatherView.SetWeatherData(weatherModel);
            }
        }
    }
}
