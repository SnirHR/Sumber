
using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot.Models
{
    public class Round
    {
        private RoundAdapter adapter;
        private ListView GameContainer;
        private int FirstPlayerSubmition, SecondPlayerSubmition;
        private bool isRunning;

        public Round(int FirstPlayerSubmition,int SecondPlayerSubmition, ListView GameContainer)
        {
            this.FirstPlayerSubmition = FirstPlayerSubmition;
            this.SecondPlayerSubmition = SecondPlayerSubmition;
            this.GameContainer = GameContainer;
            this.GameContainer.Adapter = adapter;
            this.isRunning = true;

    }

}
}