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
        protected int score;
        protected int points;
        protected int turn;

        public Player()
        {

        }
        public int GetScore()
        {
            return score;
        }

        public void AddScore(int score)
        {
            this.score = score;
        }

        public void AddPoint()
        {
            points++;
        }
    }
}