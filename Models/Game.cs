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
    public class Game
    {
        List<Round> rounds;
        List<Player> players;
        private Player playerOne;
        private Player playerTwo;
        private int sumGoal;
        Random rand;
        bool active;
        byte winner;
        public Game()
        {
            players = new List<Player>();
            playerOne = new Player();
            playerTwo = new Player();
            rand = new Random();
            active = false;
            sumGoal = rand.Next(42);
            winner = 0;
        }

        public List<Object> ConvertToObject()
        {
            List<Object> list = new List<Object>();
            foreach (Player p in players)
            {
                list.Add(p);
            }

            return list;
        }
        public void Start()
        {
            while (true)
            {
                //rounds.Add(new Round(players));
                //round.Play();

                //if (players[0].Sum >= sumGoal || players[1].Sum >= sumGoal)
                //{


                //    if (player1.Sum > player2.Sum)
                //    {
                //        Console.WriteLine("Player 1 wins!");
                //    }
                //    else if (player2.Sum > player1.Sum)
                //    {
                //        Console.WriteLine("Player 2 wins!");
                //    }
                //    else
                //    {
                //        Console.WriteLine("It's a tie!");
                //    }

                //    break;
                //}
            }
        }

    public void EndGame()
    {

       
    }
    public bool IsGameActive()
    {
        if (playerOne.Sum >= sumGoal || playerTwo.Sum >= sumGoal)
            {
                active = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}