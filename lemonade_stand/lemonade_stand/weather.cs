using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
   public class weather
    {
        Random random;
        int highTemp;
        int condition;
        static List<string> conditions;
        static int percentageDivisor = 100;
        static int maxTempChangePercent = 5; 
        static int minHighTemp = -10;
        static int maxHighTemp = 98;

        public weather(Random random)
        {
            this.random = random;
            conditions = new List<string>();
            highTemp = random.Next(minHighTemp, maxHighTemp);
            if (conditions.Count == 0)
            {
                CreateConditionsList();
            }
            DetermineCondition();
        }
        private void CreateConditionsList()
        {
            conditions.Add("snow");
            conditions.Add("rainy");
            conditions.Add("mostly sunny");
            conditions.Add("partly sunny");
            conditions.Add("partly cloudy");
            conditions.Add("mostly cloudy");
            conditions.Add("partly cloudy with  rain showers");
            conditions.Add("mostly cloudy with rain showers");
            conditions.Add("thunder storms");
        }
        public string Condition
        {
            get { return conditions[condition]; }
            private set
            {
                if (conditions.IndexOf(value) >= 0)
                {
                    condition = conditions.IndexOf(value);
                }
                else
                {
                    condition = 0;
                }
            }
        }

        public static List<string> Conditions
        {
            get { return conditions; }
            private set { conditions = value; }
        }

        public int ConditionIndex
        {
            get { return condition; }
            private set { condition = value; }
        }

        public static int MaxHighTemp
        {
            get { return maxHighTemp; }
            private set { maxHighTemp = value; }
        }

        public static int MinHighTemp
        {
            get { return minHighTemp; }
            private set { minHighTemp = value; }
        }

        public int HighTemp
        {
            get { return highTemp; }
            private set { highTemp = value; }
        }

        

        private void DetermineCondition()
        {
            SetCondition(random.Next(conditions.Count));
        }

        private void SetCondition(int indexCondition)
        {
            Condition = conditions[indexCondition];
        }

        public void ChangeForecast()
        {
            int conditionChange;

            HighTemp = HighTemp + (HighTemp * (random.Next(maxTempChangePercent) / percentageDivisor));

            conditionChange = random.Next(-1, 1);
            if (condition + conditionChange >= 0 && condition + conditionChange < conditions.Count)
            {
                condition += conditionChange;
            }
        }
    }
}


