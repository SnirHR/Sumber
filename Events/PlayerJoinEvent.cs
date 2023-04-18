using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot.Events;
using Bagrot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot.Events
{
    public delegate void PlayerJoinEventHandler(object sender, PlayerJoinEventArgs args);
    public class PlayerJoinEventArgs : EventArgs
    {
        public User user {get; }
        
    }
    public class PlayerJoinEvent : EventArgs
    {
        public event PlayerJoinEventHandler JoinEvent;

        public void DoSomething()
        {
            // raise the event
            JoinEvent?.Invoke(this, new PlayerJoinEventArgs());
        }
    }

    public class CustomEventListener
    {
        public void HandleCustomEvent(object sender, PlayerJoinEventArgs args)
        {
            // handle the event
        }
    
    }
}