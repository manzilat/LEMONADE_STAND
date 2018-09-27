using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Shopping
    {
        public static void DisplayForecast(List<weather> forecast)
        {
            WriteLine($"{forecast.Count} Day Forecast");
            WriteLine("- - - - - - - - - - - - -\n");
            for (int i = 0; i < forecast.Count; i++)
            {
                string dayLabel = i == 0 ? "TODAY: " : $"{i} DAYS OUT: ";
                WriteLine($"{dayLabel} A high of {forecast[i].HighTemp}°F and will be {forecast[i].Condition}.");
            }
        }
        public static void DisplayPlayerDayResults(Player player, int dayNumber)
        {
            int missedCustomerCount = player.DailyReports[dayNumber].PotentialCustomerCount - player.DailyReports[dayNumber].ActualCustomerCount;
            double totalSales = player.DailyReports[dayNumber].endingBalance - DailyReports[dayNumber].startingBalance;

            WriteLine($"Day {dayNumber + 1} Results for {player.Name}");
            WriteLine("===============================================================================\n");

            WriteLine("CUSTOMERS");
            WriteLine($"Customers Served: {player.DailyReports[dayNumber].ActualCustomerCount}");
            WriteLine($"Customers Missed: {missedCustomerCount:G0}\n");

            WriteLine("CASH FLOW");
            WriteLine($"Beginning Balance: {player.DailyReports[dayNumber].startingBalance:C2}");
            WriteLine($"Total Sales: {totalSales:C2}");
            WriteLine($"Ending Balance: {player.DailyReports[dayNumber].endingBalance:C2}");
            WriteLine($"Running Profit/Loss {player.DailyReports[dayNumber].endingBalance - Player.BeginningBalance}");

            if (player.DailyReports[dayNumber].RanOutOfInventory)
            {
                WriteLine("\n=================================================================================");
                WriteLine("*Your day ended early as you ran out of needed inventory to serve your customers.*");
                WriteLine("==================================================================================");
            }

            WriteLine("");
        }
    }
}
