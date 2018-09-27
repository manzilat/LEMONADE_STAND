using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    abstract public class Player
    {
        static double beginningBalance = 25 ;

        double Balance;
        string name;
        Dictionary<string, int> inventory;
        List<DailyReport> DailyReport;


        public double balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public static double BeginningBalance
        {
            get { return beginningBalance; }
            private set { beginningBalance = value; }
        }

        public List<DailyReport> DailyReports
        {
            get { return DailyReports; }
            set { DailyReports = value; }
        }

        public Dictionary<string, int> Invetory
        {
            get { return inventory; }
            private set { inventory = value; }
        }

        public string Name
        {
            get { return name.ToUpper(); }

            set { name = value.ToUpper(); }
        }

        public Player(Store store)
        {
            Balance = beginningBalance;
            name = "";
            inventory = new Dictionary<string, int>();
            DailyReports = new List<DailyReport>();
            for (int i = 0; i < store.Products.Count; i++)
            {
                inventory.Add(store.Products[i].Name, 0);
            }
            DailyReports = new List<DailyReport>();
        }

        public int AdjustInventory(string item, int quanityIncrementer)
        {
            int currentQuanity;

            if (inventory.TryGetValue(item, out currentQuanity))
            {
                if (int.MaxValue - currentQuanity >= quanityIncrementer)
                {
                    inventory[item] = currentQuanity + quanityIncrementer;
                }
                else
                {
                    throw new OverflowException();
                }
            }
            else
            {
                inventory[item] = quanityIncrementer > 0 ? quanityIncrementer : 0;
            }

            return inventory[item];
        }

        public void DisplayBalance()
        {
            Shopping.DisplayPlayerBalance(this);
        }

        public void GoShopping(Store store)
        {
            if (Shopping.GetInput($"{name} would you like to visit the store for supplies? <yes/no>", "yes/no") == "yes")
            {
                Shopping.GoShopping(this, store);
            }
        }

        private bool IsSufficentInventoryPitcher(Recipe recipe)
        {
            for (int i = 0; i < recipe.Pitcher.Count; i++)
            {
                if (recipe.Pitcher[i].Measurement > inventory[recipe.Pitcher[i].Name])
                {
                    return false;
                }
            }
            return true;
        }

        public bool MakePitcher(Recipe recipe)
        {
            if (IsSufficentInventoryPitcher(recipe))
            {
                for (int i = 0; i < recipe.Pitcher.Count; i++)
                {
                    UseInventory(recipe.Pitcher[i].Name, recipe.Pitcher[i].Measurement);
                }

                return true;
            }

            return false;
        }

        public double ProcessBankTransaction(double increaseBalanceBy)
        {
            if (double.MaxValue - Balance <= increaseBalanceBy) { throw new OverflowException(); }
            if (double.MinValue + Balance >= increaseBalanceBy) { throw new OverflowException(); }
            return Balance += increaseBalanceBy;
        }

        public void SetPlayerName(string playerLabel)
        {
            Name = Shopping.GetInput($"Enter {playerLabel}'s name:", "string");
        }

        private void UseInventory(string item, int quanity)
        {
            inventory[item] -= quanity;
        }
    }
    }
