using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Bagrot.Models;
using Google.Android.Material.TextField;
using System;
using System.Threading.Tasks;

namespace Bagrot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected EditText emailInput, passwordInput;
        protected Button SignInButton,RegisterButton;
        protected ProgressDialog progressDialog;
        protected User user;
        Login login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            SupportActionBar.Hide();
            Initiallize();
        }
        public void Initiallize()
        {
            this.login = new Login();
            this.emailInput = this.FindViewById<EditText>(Resource.Id.emailInput);
            this.passwordInput = this.FindViewById<EditText>(Resource.Id.passwordInput);
            this.SignInButton = this.FindViewById<Button>(Resource.Id.buttonSignIn);
            this.RegisterButton = this.FindViewById<Button>(Resource.Id.buttonRegister);
            this.SignInButton.Click += SignInButton_Click;
            this.RegisterButton.Click += RegisterButton_Click;
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            login.SignIn();
        }

        private async Task<bool> RegisterButton_Click(object sender, EventArgs e)
        {
             return await login.Register();
        }

     


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }
    }
}