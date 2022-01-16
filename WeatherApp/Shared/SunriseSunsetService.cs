using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Shared {
    public class SunriseSunsetService {
        public ISunriseSunsetView sunriseSunsetView;
        public SunriseSunsetService(ISunriseSunsetView sunriseSunsetView) {
            this.sunriseSunsetView = sunriseSunsetView;
        }
        public async void GetSunriseSunriseForCityAsync(string lat,string log) {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://api.sunrise-sunset.org/json?lat={lat}lng={log}");
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                SunriseSunsetModel sunriseSunsetModel = JsonConvert.DeserializeObject<SunriseSunsetModel>(content);
                sunriseSunsetView.SetSunriseSunsetData(sunriseSunsetModel);
            }
        }
    }
}
