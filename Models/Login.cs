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
    public class Login
    {
        protected User user;
        protected MainActivity main;
        protected Context instance;
        protected ProgressDialog progressDialog;
        protected string email, password;
        public Login(Context instance, MainActivity main)
        {
            this.instance = instance;
            this.main = main;
        }

        public async Task<dynamic> SignIn()
        {
            if (main.emailInput != null)
            {
                email = main.emailInput.Text;
                if (main.passwordInput != null)
                {
                    password = main.passwordInput.Text;
                    this.user = new User(email, password);
                    this.ShowProgressDialog("Logging in...");
                    if (await this.user.Login() != false)
                    {
                        this.progressDialog.Dismiss();
                        return true;
                    }
                    this.progressDialog.Dismiss();
                    return "Login Failed :(";
                }
                this.progressDialog.Dismiss();
                return "Please Enter Password";
            }
            this.progressDialog.Dismiss();
            return "Please Enter E-mail";
        }
        public async Task<dynamic> Register()
        {
            if (main.emailInput != null)
            {
                email = main.emailInput.Text;
                if (main.passwordInput != null)
                {
                    password = main.passwordInput.Text;
                    this.user = new User(email, password);
                    this.ShowProgressDialog("Registering...");
                    if (await this.user.Register() != false)
                    {
                        this.progressDialog.Dismiss();
                        return true;
                    }
                    this.progressDialog.Dismiss();
                    return "Register Failed :(";
                }
                this.progressDialog.Dismiss();
                return "Please Enter Password";
            }
            this.progressDialog.Dismiss();
            return "Please Enter E-mail";
        }

        void ShowProgressDialog(string status)
        {
            progressDialog = new ProgressDialog(instance);
            progressDialog.SetCancelable(false);
            progressDialog.SetMessage(status);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressDialog.Show();
        }
    }
}