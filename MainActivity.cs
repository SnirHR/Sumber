using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Bagrot.Actitvites;
using Bagrot.Models;
using Google.Android.Material.TextField;
using System;

namespace Bagrot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText emailInput, passwordInput;
        Button SignInButton,RegisterButton;
        ProgressDialog progressDialog;
        User user;
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
            this.emailInput = this.FindViewById<EditText>(Resource.Id.emailInput);
            this.passwordInput = this.FindViewById<EditText>(Resource.Id.passwordInput);
            this.SignInButton = this.FindViewById<Button>(Resource.Id.buttonSignIn);
            this.RegisterButton = this.FindViewById<Button>(Resource.Id.buttonRegister);
            this.SignInButton.Click += SignInButton_Click;
            this.RegisterButton.Click += RegisterButton_Click;
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            string email = this.emailInput.Text;
            if (email == "")
            {
                Toast.MakeText(this, "Please Enter An Email", ToastLength.Long).Show();
                return;
            }
            string password = this.passwordInput.Text;
            if (password == "")
            {
                Toast.MakeText(this, "Please Enter A Password", ToastLength.Long).Show();
                return;
            }
            this.ShowProgressDialog("Login in...");
            this.user = new User(email, password);
            if (await this.user.Login() == true)
            {
                Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Login Failed :(", ToastLength.Long).Show();
                RegisterButton.Visibility = ViewStates.Visible;
            }
            this.progressDialog.Dismiss();
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            string email = this.emailInput.Text;
            string password = this.passwordInput.Text;
            if (email == "" || password == "")
            {
                Toast.MakeText(this, "Please fill all fields", ToastLength.Short).Show();
                return;
            }
            User user = new User(email, password);
            this.ShowProgressDialog("Registering...");
            if (await user.Register() == true)

            {
                Toast.MakeText(this, "Register Success", ToastLength.Long).Show();
                progressDialog.Dismiss();

            }
            else
            {
                Toast.MakeText(this, "Register Failed", ToastLength.Long).Show();
            }
            progressDialog.Dismiss();

        }

        void ShowProgressDialog(string status)
        {
            this.progressDialog = new ProgressDialog(this);
            progressDialog.SetCancelable(false);
            progressDialog.SetMessage(status);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressDialog.Show();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }
    }
}