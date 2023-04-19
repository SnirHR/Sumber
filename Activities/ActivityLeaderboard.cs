using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot;
using Bagrot.Adapters;
using Bagrot.Models;
using Firebase.Firestore;
using Firebase.Firestore.Auth;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bagrot.Activities
{
    [Activity(Label = "ActivityLeaderboard")]
    public class ActivityLeaderboard : Activity
    {
        LeaderboardAdapter LeaderboardAdapter;
        List<NetworkObject> playersList;
        ListView listPlayers;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutLeaderboard);
            Init();
        }
        public async void Init()
        {
            playersList = await NetworkObject.GetLeaderboard();
            LeaderboardAdapter = new LeaderboardAdapter(ApplicationContext, playersList);
            listPlayers = FindViewById<ListView>(Resource.Id.leaderboardView);
            listPlayers.Adapter = LeaderboardAdapter;
        }

    }
}
