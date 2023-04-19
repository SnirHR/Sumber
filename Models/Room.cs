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

namespace Bagrot.Models
{
    public class Room
    {
        public List<Object> Players { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumPlayers { get; set; }

        public Room() {
            Players = new List<Object>();
        }
    }
}