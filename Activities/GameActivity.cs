﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot.Activities
{
    [Activity(Label = "ActivityGame")]
    public class GameActivity : Activity
    {
        bool playersConnected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutGame);
            initiallize();
        }

        public void initiallize()
        {
            playersConnected = true;
        }


    }
}