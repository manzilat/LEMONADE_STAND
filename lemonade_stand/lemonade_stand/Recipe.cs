﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
   public class Recipe
    {

        static string[] tasteProfiles = new string[] { "sour", "balanced", "sweet" };
        static int cupsPerPitcher = 10;

        private List<Ingredient> cup;
        List<Ingredient> pitcher;
        double sellPrice;
        
        
        public Recipe(List<Product> products)
        {
            cup = new List<Ingredient>();
            pitcher = new List<Ingredient>();
            foreach (Product product in products)
            {
                switch (product.recipePart)
                {
                    case "pitcher":
                        pitcher.Add(new Ingredient(product.Name, product.Unit));
                        break;

                    case "cup":
                    default:
                        cup.Add(new Ingredient(product.Name, product.Unit));
                        break;
                }
            }
        }

        public List<Ingredient> Cup
        {
            get { return cup; }
            set { cup = value; }
        }

        public static int CupsPerPitcher
        {
            get { return cupsPerPitcher; }
            set { cupsPerPitcher = value; }
        }

        public int IceCubeCount
        {
            get { return cup.Where(i => i.Name == "ice cube").First().Measurement; }
        }

        public List<Ingredient> Pitcher
        {
            get { return pitcher; }
            set { pitcher = value; }
        }

        public double SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }

        public string TasteProfile
        {
            get
            {
                Ingredient lemon = pitcher.Where(i => i.Name == "lemon").First();
                Ingredient sugar = pitcher.Where(i => i.Name == "sugar").First();

                int index = Convert.ToInt16(Math.Floor(Convert.ToDouble(lemon.Measurement) / Convert.ToDouble(sugar.Measurement)));

                if (index >= tasteProfiles.Length)
                {
                    index = tasteProfiles.Length - 1;
                }

                return tasteProfiles[index];

            }
        }

        public static string[] TasteProfiles
        {
            get { return tasteProfiles; }
        }

        public void SetRecipe(string playerName)
        {
            Shopping.SetRecipe(this, playerName);
        }
    }
}
