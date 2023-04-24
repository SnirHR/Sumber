using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Java.Util;

namespace Bagrot.Activities
{
    [Activity(Label = "ActivityGame")]
    public class GameActivity : Activity,GameView
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

        public void Update()
        {
            Invalidate();
        }


    }
}