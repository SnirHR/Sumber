using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util;
using System;
using System.Threading.Tasks;

namespace Bagrot.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        FirebaseAuth firebaseAuthentication;
        FirebaseFirestore database;

        public const string COLLECTION_NAME = "users";
        public const string CURRENT_USER_FILE = "currentUserFile";

        public User()
        {
            this.firebaseAuthentication = AppDataHandler.GetFirebaseAuthentication();
            this.database = AppDataHandler.GetFirestore();
        }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
            this.firebaseAuthentication = AppDataHandler.GetFirebaseAuthentication();
            this.database = AppDataHandler.GetFirestore();
        }

        public async Task<bool> Login()
        {
            try
            {
                await this.firebaseAuthentication.SignInWithEmailAndPassword(this.Email, this.Password);
                var editor = Application.Context.GetSharedPreferences(CURRENT_USER_FILE, FileCreationMode.Private).Edit();
                editor.PutString("Email", this.Email);
                editor.PutString("Password", this.Password);
                editor.Apply();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }
        public async Task<bool> Logout()
        {
            try
            {
                var editor = Application.Context.GetSharedPreferences(User.CURRENT_USER_FILE, FileCreationMode.Private).Edit();
                editor.PutString("Email", "");
                editor.PutString("Password", "");
                editor.Apply();
                firebaseAuthentication.SignOut();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<bool> Register()
        {
            try
            {
                await this.firebaseAuthentication.CreateUserWithEmailAndPassword(this.Email, this.Password);
            }
            catch (Exception e)
            {
                return false; ;
            }
            try
            {
                HashMap userMap = new HashMap();
                userMap.Put("Email", this.Email);
                DocumentReference userReference = this.database.Collection(COLLECTION_NAME).Document(this.firebaseAuthentication.CurrentUser.Uid);
                await userReference.Set(userMap);
            }
            catch
            {

                return false;
            }
            return true;
        }


    }
}