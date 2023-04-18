using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bagrot.Activities;
using Bagrot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bagrot.Adapters
{
    public class RoundAdapter : BaseAdapter<NetworkObject> {

        private Context context;
        private List<NetworkObject> playersList;

        public RoundAdapter(Context context, List<NetworkObject> playersList)
        {
            this.context = context;
            this.playersList = playersList;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater = ((GameActivity)this.context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.leaderboardRow, parent, false);
            TextView textViewPlayer = view.FindViewById<TextView>(Resource.Id.textViewPlayerRow);
            TextView textViewScore = view.FindViewById<TextView>(Resource.Id.ScoreTextRow);
            NetworkObject currentNetWorkObject = this.playersList[position];
            if (currentNetWorkObject != null)
            {
                textViewPlayer.Text = currentNetWorkObject.PlayerName;
                textViewScore.Text = currentNetWorkObject.wins.ToString();
            }

            return view;
        }
        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return this.playersList.Count;
            }
        }

        public override NetworkObject this[int position]
        {
            get
            {
                return playersList[position];
            }
        }
    }

    internal class RoundAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}