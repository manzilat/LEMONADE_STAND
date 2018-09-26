using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Player
    {
        public string name;
        public double money;
        public double profit;
        double expenses;
        double drinkCost = .50;
        public Inventory items = new Inventory();
        int CupsSold;
        public int UnusedCups;
        public int Visitors;
        public int Buyers;
        public int days = 0;
        double runningProfit;
        string input = " ";
        public string taste = " ";
    }
}




