using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot
{
    public class Player
    {
        public int Sum { get; set; }
        public int SumBonus { get; set; }

        public Player()
        {
            Sum = 0;
            SumBonus = 0;
            Toast.MakeText(this,"Hello!",ToastLength.Long).Show();
        }

    }

}