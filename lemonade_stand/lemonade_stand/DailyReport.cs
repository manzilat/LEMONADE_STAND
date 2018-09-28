using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    public class DailyReport
    {
        int actualCustomerCount;
        double endingBalance;
        double initialBalance;
        int potentialCustomerCount;
        bool ranOutOfInventory = false;

        public int ActualCustomerCount
        {
            get { return actualCustomerCount; }
            set { actualCustomerCount = value; }
        }

        public double EndingBalance
        {
            get { return endingBalance; }
            set { endingBalance = value; }
        }

        public double InitialBalance
        {
            get { return initialBalance; }
            set
            { initialBalance = value; }
        }

        public int PotentialCustomerCount
        {
            get { return potentialCustomerCount; }
            set { potentialCustomerCount = value; }
        }

        public bool RanOutOfInventory
        {
            get { return ranOutOfInventory; }
            set { ranOutOfInventory = value; }
        }

        public void RecordPurchase(double price)
        {
            actualCustomerCount++;
            EndingBalance += price;
        }

    }
}
