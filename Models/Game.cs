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
        Player playerOne, playerTwo;
        Random rand;
        bool active;
        int goal;
        byte winner;

        public Game()
        {
            playerOne = new Player();
            playerTwo = new Player();
            rand = new Random();
            active = false;
            goal = rand.Next(42);
            winner = 0;
        }

        public void StartRound()
        {
            while (active)
            {
                int p1 = int.Parse(Console.ReadLine());
                int p2 = int.Parse(Console.ReadLine());
                playerOne.AddScore(p1);
                playerTwo.AddScore(p2);

                if (p1 < p2)
                {
                    playerOne.AddPoint();
                }
                else
                {
                    playerOne.AddPoint();
                }
                IsGameActive();
            }
            EndGame();

        }
        public void EndGame()
        {

        }
        public bool IsGameActive()
        {
            if (playerOne.GetScore() >= goal || playerTwo.GetScore() >= goal)
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