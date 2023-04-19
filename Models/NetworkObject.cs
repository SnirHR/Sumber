using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Lang;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagrot.Models
{
    public class NetworkObject
    {
        public const string COLLECTION_NAME = "Leaderboard";
        public string PlayerName { get; set; }
        public long wins{ get; set; }

        public NetworkObject()
        {
        }

        public NetworkObject(string PlayerName, long wins)
        {
            this.PlayerName = PlayerName;
            this.wins = wins;
        }
        public HashMap GetHashMapOfObject()
        {
            HashMap gNoHashMap = new HashMap();
            gNoHashMap.Put(NetworkObjectConstants.Name, this.PlayerName);
            return gNoHashMap;
        }
        public static async Task<NetworkObject> GetNetWorkObject(string PlayerName)
        {
            NetworkObject networkObject = null;
            try
            {
                FirebaseFirestore firebaseFirestore = AppDataHandler.GetFirestore();
                Java.Lang.Object obj = await firebaseFirestore.Collection(COLLECTION_NAME).WhereEqualTo(NetworkObjectConstants.Name, PlayerName).Get();
                QuerySnapshot querySnapshot = (QuerySnapshot)obj;
                networkObject = new NetworkObject();
            }
            catch
            {
                return null;
            }
            return networkObject;
        }

        public static async Task<List<NetworkObject>> GetLeaderboard()
        {
            FirebaseFirestore firestore = AppDataHandler.GetFirestore();
            CollectionReference collectionRef = firestore.Collection("Leaderboard");
            QuerySnapshot querySnapshot = (QuerySnapshot)await collectionRef.Get();

            List<NetworkObject> leaderboard = new List<NetworkObject>();

            foreach (var documentSnapshot in querySnapshot.Documents)
            {
                NetworkObject player = new NetworkObject();
                player.PlayerName = documentSnapshot.GetString("Name");
                player.wins = (long)documentSnapshot.GetLong("Wins");

                leaderboard.Add(player);
            }

            return leaderboard;
        }
    }
}