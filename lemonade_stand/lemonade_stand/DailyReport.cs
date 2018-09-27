using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class DailyReport
    {
        int actualCustomerCount;
        double EndingBalance;
        double StartingBalance;
        int potentialCustomerCount;
        bool ranOutOfInventory = false;

        public int ActualCustomerCount
        {
            get { return actualCustomerCount; }
            set { actualCustomerCount = value; }
        }

        public double endingBalance
        {
            get { return EndingBalance; }
            set { EndingBalance = value; }
        }

        public double startingBalance
        {
            get { return StartingBalance; }
            set
            { StartingBalance = value; }
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
