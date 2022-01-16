using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace TryApp1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button ButtonIncrement;
        Button ButtonDecrement;
        TextView TextViewCount;
        int Count;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //ShowMessage("OnCreate");
            SetupReferences();
            SubscribeEventHandlers();
        }

        private void SubscribeEventHandlers() {
            ButtonIncrement.Click += ButtonIncrement_Click;
            ButtonDecrement.Click += ButtonDecrement_Click;
            ButtonIncrement.LongClick += ButtonIncrement_LongClick;
        }

        private void SetupReferences() {
            TextViewCount = FindViewById<TextView>(Resource.Id.textViewCount);
            ButtonIncrement = FindViewById<Button>(Resource.Id.buttonIncrement);
            ButtonDecrement = FindViewById<Button>(Resource.Id.buttonDecrement);
        }

        private void ButtonIncrement_LongClick(object sender, Android.Views.View.LongClickEventArgs e) {
                Count++;
                TextViewCount.Text = Count.ToString();
            
            
        }

        private void ButtonIncrement_Click(object sender, System.EventArgs e) {
            Count++;
            TextViewCount.Text = Count.ToString();
        }

        private void ButtonDecrement_Click(object sender, System.EventArgs e) {
            Count--;
            TextViewCount.Text = Count.ToString();
        }

        //private void ShowMessage(string message) {
        //    Toast.MakeText(this, message, ToastLength.Short).Show();
        //}

        //protected override void OnStart() {
        //    base.OnStart();
        //    ShowMessage("OnStart");

        //}
        //protected override void OnResume() {
        //    base.OnResume();
        //    ShowMessage("OnResume");

        //}
        //protected override void OnPause() {
        //    base.OnPause();
        //    ShowMessage("OnPause");

        //}
        //protected override void OnStop() {
        //    base.OnStop();
        //    ShowMessage("OnStop");

        //}
        //protected override void OnRestart() {
        //    base.OnRestart();
        //    ShowMessage("OnRestart");

        //}
        //protected override void OnDestroy() {
        //    base.OnDestroy();
        //    ShowMessage("OnDestroy");

        //}
    }
}