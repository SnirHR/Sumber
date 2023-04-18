
using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot.Activities;
using Bagrot.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot.Models
{
    public class Round
    {
        private GameActivity gameActivity;
        private RoundAdapter adapter;
        private ListView gameContainer;
        private EditText numberInput;
        private int firstPlayerSubmition, secondPlayerSubmition;
        private bool isRunning;

        public Round(GameActivity gameActivity, ListView gameContainer,EditText numberInput, int firstPlayerSubmition, int secondPlayerSubmition)
        {
            this.gameActivity = gameActivity;
            this.firstPlayerSubmition = firstPlayerSubmition;
            this.secondPlayerSubmition = secondPlayerSubmition;
            this.gameContainer = gameContainer;
            this.gameContainer.Adapter = adapter;
            this.numberInput = numberInput;
            this.isRunning = true;
            this.numberInput.Text = "";

    }

}
}