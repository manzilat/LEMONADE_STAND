using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Product
    {
        string name;
        string unit;
        string recipepart;
        double price;
       
        
        public Product(string name, double price, string unit, string recipepart)
        {
            this.name = name;
            this.unit = unit;
            this.recipepart = recipepart;
            this.price = price;
           
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public string Recipepart
        {
            get { return recipepart; }
            private set { recipepart = value; }
        }

        public string Unit
        {
            get { return unit; }
            private set { unit = value; }
        }
    }
}
