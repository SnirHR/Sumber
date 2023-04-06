using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Bagrot.Activities;
using Bagrot.Models;
using Google.Android.Material.TextField;
using System;
using System.Threading.Tasks;

namespace Bagrot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public EditText emailInput, passwordInput;
        public Button SignInButton,RegisterButton;
        protected ProgressDialog progressDialog;
        protected User user;
        protected Login login;
        protected bool Registering;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Initiallize();
        }
        public void Initiallize()
        {
            this.emailInput = this.FindViewById<EditText>(Resource.Id.emailInput);
            this.passwordInput = this.FindViewById<EditText>(Resource.Id.passwordInput);
            this.SignInButton = this.FindViewById<Button>(Resource.Id.buttonSignIn);
            this.RegisterButton = this.FindViewById<Button>(Resource.Id.buttonRegister);
            this.SignInButton.Click += SignInButton_Click;
            this.RegisterButton.Click += RegisterButton_Click1;
            Registering = false;
            login = new Login(this,this);
        }

        private async void RegisterButton_Click1(object sender, EventArgs e)
        {
            dynamic SignedIn = await login.Register();
            Registering = true;
            try
            {
                if ((bool)SignedIn == true)
                {
                    Toast.MakeText(this, "Register Successful!", ToastLength.Long);
                    Intent intent = new Intent(this, typeof(ActivityGame));
                    StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, SignedIn, ToastLength.Long).Show();
            }
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            dynamic SignedIn = await login.SignIn();
            try
            {
                if((bool)SignedIn == true)
                {
                    Toast.MakeText(this, "Login In Successful!", ToastLength.Long);
                    Intent intent = new Intent(this, typeof(ActivityGame));
                    StartActivity(intent);
                }
            } catch (Exception ex)
            {
                Toast.MakeText(this, SignedIn, ToastLength.Long).Show();
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }
    }
}