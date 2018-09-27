using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Day
    {
        static int DaysToforecastWeather = 7;

        List<Weather> forecast;
        Random random;
        List<Recipe> recipes;
        List<Player> players;
        List<Customer> customers;
        int dayNumber;

        public Day(Random random, List<Player> players, int dayNumber)
        {
            this.random = random;
            Forecast = new List<weather>();
            CreateForecast();
            recipes = new List<Recipe>();
            customers = new List<Customer>();
            CreateCustomers();
            this.players = players;
            this.dayNumber = dayNumber;
        }

        public Day(Random random, List<Player> players, List<weather> previousforecast, int dayNumber)
        {
            this.random = random;
            Forecast = new List<weather>();
            Forecast.AddRange(previousforecast);
            Forecast.RemoveAt(0);
            Updateforecast();
            recipes = new List<Recipe>();
            customers = new List<Customer>();
            CreateCustomers();
            this.players = players;
            this.dayNumber = dayNumber;
        }

        public List<weather> Forecast
        {
            get { return Forecast; }
            set { Forecast = value; }
        }

        private int CalculateCustomerCount()
        {
            int baseCustomerCount;
            switch (Forecast[0].ConditionIndex)
            {
                case 0:
                    baseCustomerCount = 120;
                    break;
                case 1:
                case 2:
                    baseCustomerCount = 90;
                    break;
                case 3:
                case 4:
                    baseCustomerCount = 56;
                    break;
                default:
                    baseCustomerCount = 25;
                    break;
            }
            return Convert.ToInt16(Convert.ToDouble(baseCustomerCount) * (Convert.ToDouble(Forecast[0].HighTemp) / Convert.ToDouble(weather.MaxHighTemp)) / Convert.ToDouble((Forecast[0].ConditionIndex + 1)));
        }

        private void CreateCustomers()
        {
            int customerCount = CalculateCustomerCount();
            for (int i = 0; i < customerCount; i++)
            {
                customers.Add(new Customer(random, forecast[0]));
            }
        }

        private void CreateForecast()
        {
            while (Forecast.Count != DaysToforecastWeather)
            {
                if (Forecast.Count < DaysToforecastWeather)
                {
                    Forecast.Add(new weather(random));
                }
                else
                {
                    Forecast.RemoveAt(Forecast.Count - 1);
                }
            }
        }

        public void SetPlayerRecipes(List<Product> products)
        {
            for (int i = 0; i < players.Count; i++)
            {
                recipes.Add(new Recipe(products));
                recipes[i].SetRecipe(players[i].Name);
            }
        }

        private void SimulateCustomers(Player player, int playerIndex)
        {
            int cupsRemainingInPitcher = 0;

            foreach (Customer customer in customers)
            {
                if (customer.DoesPurchase(forecast[0], recipes[playerIndex]))
                {
                    if (cupsRemainingInPitcher > 0 && player.Invetory["cup"] > 0 && player.Invetory["ice cube"] >= recipes[playerIndex].IceCubeCount)
                    {
                        player.DailyReports[dayNumber].RecordPurchase(recipes[playerIndex].SellPrice);
                        cupsRemainingInPitcher--;
                        player.Invetory["cup"]--;
                        player.Invetory["ice cube"] -= recipes[playerIndex].IceCubeCount;
                    }
                    else if (player.Invetory["cup"] > 0 && player.Invetory["ice cube"] >= recipes[playerIndex].IceCubeCount)
                    {
                        if (player.MakePitcher(recipes[playerIndex]))
                        {
                            cupsRemainingInPitcher = Recipe.CupsPerPitcher;
                            player.DailyReports[dayNumber].RecordPurchase(recipes[playerIndex].SellPrice);
                            cupsRemainingInPitcher--;
                            player.Invetory["cup"]--;
                            player.Invetory["ice cube"] -= recipes[playerIndex].IceCubeCount;
                        }
                        else
                        {
                            player.DailyReports[dayNumber].RanOutOfInventory = true;
                            break;
                        }
                    }
                    else
                    {
                        player.DailyReports[dayNumber].RanOutOfInventory = true;
                        break;
                    }

                }

            }
        }

        public void SimulateDay()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                player.DailyReports.Insert(dayNumber, new DailyReport());
                player.DailyReports[dayNumber].StartingBalance = player.balance;
                player.DailyReports[dayNumber].EndingBalance = player.balance;
                player.DailyReports[dayNumber].PotentialCustomerCount = customers.Count;

                SimulateCustomers(player, i);

                player.balance = player.DailyReports[dayNumber].EndingBalance;

                Shopping.DisplayPlayerDayResults(player, dayNumber);

            }
        }

        private void Updateforecast()
        {
            for (int i = 0; i < Forecast.Count; i++)
            {
                Forecast[i].AlterForecast();
            }

            CreateForecast();
        }


    }
}
