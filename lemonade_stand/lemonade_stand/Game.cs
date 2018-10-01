﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Game
    {
            List<Player> players;
            Dictionary<int, double> finalScores;
            List<Day> days;
            int numberOfDaysToPlay;
            Random random;
            Store store;
            
            public Game()
            {
                days = new List<Day>();
                random = new Random();
                players = new List<Player>();
                
                numberOfDaysToPlay = 7;
                store = new Store();

            }

            public void RunGame()                   
            {



                SetupPlayers();

                for (int i = 0; i < numberOfDaysToPlay; i++)
                {
                    if (i != 0)
                    {
                        days.Add(new Day(random, players, days[i - 1].Forecast, i));
                    }
                    else
                    {
                        days.Add(new Day(random, players, i));
                    }
                    Shopping.DisplayForecast(days[i].Forecast);
                    SendPlayersToStore();
                    days[i].SetPlayerRecipes(store.Products);
                    days[i].SimulateDay();
                }

                GetFinalScores();
                Shopping.DisplayFinalScores(players, finalScores);

            }

       
        private void GetFinalScores()
            {
                finalScores = new Dictionary<int, double>();
                for (int i = 0; i < players.Count; i++)
                {
                    finalScores.Add(i, players[i].Balance);

                }
            }



        private void SendPlayersToStore()
            {
                foreach (Player player in players)
                {
                    player.GoShopping(store);
                }
            }

           
            private void SetupHumanPlayers()
            {
                int playerCount;

                playerCount = int.Parse(Shopping.GetInput("select number of players?", "integer greater than 0"));

                for (int i = 0; i < playerCount; i++)
                {
                    players.Add(new Human(store));
                    players[i].SetPlayerName($"Player {i + 1}");
                }
            }

           
            private void SetupPlayers()
            {

                SetupHumanPlayers();

            }
        }
}









































