using System;
using System.Collections.Generic;
using System.Text;

namespace Shared {
    public interface ISunriseSunsetView {
        void SetWeatherData(WeatherModel weatherModel);
        void SetSunriseSunsetData(SunriseSunsetModel sunriseSunsetModel);
    }
}
