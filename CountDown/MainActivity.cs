using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using System;

namespace CountDown {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {
        TextView textViewDays;
        TextView textViewEvent;
        RadioButton radioButtonChristmas;
        RadioButton radioButtonSummer;
        RadioButton radioButtonHalloween;
        RadioButton radioButtonOther;
        TextInputEditText textInputCustomDate;
        Button buttonCountCustom;
        DateTime today;
        DateTime endDate;
        TimeSpan span;
       
        
        int[] images = { Resource.Drawable.halloween, Resource.Drawable.christmas, Resource.Drawable.summer };
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetupReferences();
            SubscribeEventHandlers();
            //today = new DateTime(2021, 12, 31);
            today = DateTime.Today;

        }
        private void SetupReferences() {
            textViewDays = FindViewById<TextView>(Resource.Id.textViewDays);
            textViewEvent = FindViewById<TextView>(Resource.Id.textViewEvent);
            radioButtonChristmas = FindViewById<RadioButton>(Resource.Id.radioButtonChristmas);
            radioButtonSummer = FindViewById<RadioButton>(Resource.Id.radioButtonSummer);
            radioButtonHalloween = FindViewById<RadioButton>(Resource.Id.radioButtonHalloween);
            radioButtonOther = FindViewById<RadioButton>(Resource.Id.radioButtonOther);
            textInputCustomDate = FindViewById<TextInputEditText>(Resource.Id.textInputCustomDate);
            buttonCountCustom = FindViewById<Button>(Resource.Id.buttonCountCustom);
        }

        private void SubscribeEventHandlers() {
            radioButtonChristmas.CheckedChange += RadioButtonChristmas_CheckedChange;
            radioButtonHalloween.CheckedChange += RadioButtonHalloween_CheckedChange;
            radioButtonSummer.CheckedChange += RadioButtonSummer_CheckedChange;
            buttonCountCustom.Click += ButtonCountCustom_Click;
            textInputCustomDate.Click += TextInputCustomDate_Click;

        }

        
        private void TextInputCustomDate_Click(object sender, EventArgs e) {
            radioButtonOther.Checked = true;
         
        }

        private void ButtonCountCustom_Click(object sender, EventArgs e) {
            string[] date = textInputCustomDate.Text.Split('.');
            int day = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int year = int.Parse(date[2]);
            endDate = new DateTime(year, month, day);
            TimeSpan();
            ViewCountsOfDay("Your date");
            
        }

        private void RadioButtonSummer_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (radioButtonSummer.Checked) {
                CountEndDate(today.Year, 6, 21);
                TimeSpan();
                ViewCountsOfDay("Summer");
                radioButtonSummer.SetTextColor(Android.Graphics.Color.Green);                

            } else
                radioButtonSummer.SetTextColor(Android.Graphics.Color.White);
        }

        private void RadioButtonHalloween_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (radioButtonHalloween.Checked) {
                CountEndDate(today.Year, 10, 31);
                TimeSpan();
                ViewCountsOfDay("Halloween");
                radioButtonHalloween.SetTextColor(Android.Graphics.Color.DarkRed);
                
            } else
                radioButtonHalloween.SetTextColor(Android.Graphics.Color.White);
        }
        private void RadioButtonChristmas_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (radioButtonChristmas.Checked) {
                CountEndDate(today.Year, 12, 24);
                TimeSpan();
                ViewCountsOfDay("Christmas");
                radioButtonChristmas.SetTextColor(Android.Graphics.Color.Blue);

            } else
                radioButtonChristmas.SetTextColor(Android.Graphics.Color.White);

        }
        private void CountEndDate(int year, int month, int day) {
            endDate = new DateTime(year, month, day);
            if (today.DayOfYear > endDate.DayOfYear) {
                endDate = endDate.AddYears(1);
            }
        }
        private void ViewCountsOfDay(String s) {
            textViewDays.Text = span.Days.ToString();
            textViewEvent.Text = "Days until " + s;
        }

        private void TimeSpan() {
            span = endDate - today;
        }


    }
}