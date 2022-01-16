using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Shared;
using Android.Graphics;

namespace WeatherApp {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IWeatherView, ISunriseSunsetView {
        ImageView imageView;
        TextView textViewCity;
        TextView textViewWeather;
        TextView textViewTemperature;
        TextView textViewWind;
        TextView textViewHumidity;
        TextView textViewLocalTime;
        TextView Sunrise;
        TextView Sunset;
        Button buttonChange;
        WeatherService weatherService;
        SunriseSunsetService sunriseSunsetService;


        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetupReferences();
            SubscribeEventHandlers();

        }
        private void SetupReferences() {
            imageView = FindViewById<ImageView>(Resource.Id.imageViewPicture);
            textViewCity = FindViewById<TextView>(Resource.Id.textViewCity);
            textViewWeather = FindViewById<TextView>(Resource.Id.textViewWetText);
            textViewTemperature = FindViewById<TextView>(Resource.Id.textViewTempText);
            textViewWind = FindViewById<TextView>(Resource.Id.textViewWindText);
            textViewHumidity = FindViewById<TextView>(Resource.Id.textViewHumText);
            textViewLocalTime = FindViewById<TextView>(Resource.Id.textViewTimeText);
            buttonChange = FindViewById<Button>(Resource.Id.buttonChange);
            Sunrise = FindViewById<TextView>(Resource.Id.textViewSunriseText);
            Sunset = FindViewById<TextView>(Resource.Id.textViewSunsetText);
            
            weatherService = new WeatherService(this);
            sunriseSunsetService = new SunriseSunsetService(this);
        }

        private void ButtonChange_Click(object sender, EventArgs e) {
            Intent intent = new Intent(this, typeof(CitiesActivity));
            StartActivityForResult(intent, 1);
        }
        private void SubscribeEventHandlers() {
            buttonChange.Click += ButtonChange_Click;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
            if (requestCode == 1 && resultCode == Result.Ok) {
                string city = data.GetStringExtra("City");
                textViewCity.Text = city;
                weatherService.GetWeatherForCityAsync(city);
            }
        }

        public void SetWeatherData(WeatherModel weatherModel) {
            textViewCity.Text = weatherModel.location.name;
            textViewWeather.Text = weatherModel.current.weather_descriptions[0];
            textViewHumidity.Text = weatherModel.current.humidity.ToString() + "%";
            textViewLocalTime.Text = weatherModel.location.localtime;
            textViewTemperature.Text = weatherModel.current.temperature.ToString() + " C";
            textViewWind.Text = $"{weatherModel.current.wind_speed} km/h {weatherModel.current.wind_dir}";
            imageView.SetImageBitmap(GetImageBitmapFromUrl(weatherModel.current.weather_icons[0]));
            sunriseSunsetService.GetSunriseSunriseForCityAsync(weatherModel.location.lat, weatherModel.location.lon);
        }
        private Bitmap GetImageBitmapFromUrl(string url) {
            Bitmap imageBitmap = null;
            using (var webClient = new System.Net.WebClient()) {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }

        public void SetSunriseSunsetData(SunriseSunsetModel sunriseSunsetModel) {
            Sunrise.Text = sunriseSunsetModel.results.sunrise;
            Sunset.Text = sunriseSunsetModel.results.sunset;
        }
    }
}