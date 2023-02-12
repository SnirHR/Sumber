using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Views;
using Android.Widget;
using Bagrot.Activities;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util;
using System;
using System.Threading.Tasks;

namespace Bagrot.Models
{
    public class Login: MainActivity
    {
        public async void SignIn()
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
                Intent intent = new Intent(this, typeof(ActivityGame));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Login Failed :(", ToastLength.Long).Show();
                RegisterButton.Visibility = ViewStates.Visible;
            }
            this.progressDialog.Dismiss();
        }

        public async Task<bool> Register()
        {
            string email = this.emailInput.Text;
            string password = this.passwordInput.Text;
            if (email == "" || password == "")
            {
                Toast.MakeText(this, "Please fill all fields", ToastLength.Short).Show();
                return false;
            }
            User user = new User(email, password);
            this.ShowProgressDialog("Registering...");
            if (await user.Register())
            {
                Toast.MakeText(this, "Register Success", ToastLength.Long).Show();
                progressDialog.Dismiss();
                return true;
            }
            else
            {
                Toast.MakeText(this, "Register Failed", ToastLength.Long).Show();
                return false;
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
    }
}