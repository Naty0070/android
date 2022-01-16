using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp {
    [Activity(Label = "CitiesActivity")]
    public class CitiesActivity : Activity {
        TextView textViewOstrava;
        TextView textViewBruntal;
        TextView textViewHelsinki;
        TextView textViewSingapur;
        TextView textViewOlomouc;

        protected override void OnCreate(Bundle savedInstanceState) {
            SetContentView(Resource.Layout.cities_layout);
            base.OnCreate(savedInstanceState);
            SetupReferences();
            SubscibeEventHandlers();
        }

        private void SubscibeEventHandlers() {
            textViewOstrava.Click += TextViewOstrava_Click;
            textViewBruntal.Click += TextViewBruntal_Click;
            textViewHelsinki.Click += TextViewHelsinki_Click;
            textViewSingapur.Click += TextViewSingapur_Click;
            textViewOlomouc.Click += TextViewOlomouc_Click;
        }
        private void SetupReferences() {
            textViewOstrava = FindViewById<TextView>(Resource.Id.textViewOstrava);
            textViewBruntal = FindViewById<TextView>(Resource.Id.textViewBruntal);
            textViewHelsinki = FindViewById<TextView>(Resource.Id.textViewHelsinki);
            textViewSingapur = FindViewById<TextView>(Resource.Id.textViewSingapur);
            textViewOlomouc = FindViewById<TextView>(Resource.Id.textViewOlomouc);

        }

        private void TextViewOlomouc_Click(object sender, EventArgs e) {
            GoBackWithTheCity("Olomouc");
        }

        private void TextViewSingapur_Click(object sender, EventArgs e) {
            GoBackWithTheCity("Singapur");
        }

        private void TextViewHelsinki_Click(object sender, EventArgs e) {
            GoBackWithTheCity("Helsinki");
        }

        private void TextViewBruntal_Click(object sender, EventArgs e) {
            GoBackWithTheCity("Bruntal");
        }

        private void TextViewOstrava_Click(object sender, EventArgs e) {
            GoBackWithTheCity("Ostrava");
        }
        private void GoBackWithTheCity(string city) {
            Intent intent = new Intent();
            intent.PutExtra("City", city);
            SetResult(Result.Ok, intent);
            Finish();
        }

    }
}