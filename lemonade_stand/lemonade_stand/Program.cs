using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonade_stand
{
    class Program
    {

        static void Main(string[] args)
        {

            string Instructions = "Lemonade Stand instructions:\n";
            Instructions = Instructions + " it is multi player game\n";
            Instructions = Instructions + " Your goal is to make as much money as you can in 7 days by selling lemonade at your lemonade stand.\n";
            Instructions = Instructions + "Buy cups, lemons, sugar, and ice cubes, then set your recipe based on the weather and conditions. Start with the basic recipe, but try to vary the recipe and see if you can do better.\n";
            Instructions = Instructions + "Make sure you buy enough of all your ingredients, or you won’t be able to sell!\n";
            Instructions = Instructions + "You’ll also have to deal with the weather, which will play a big part when customers are deciding whether or not to buy your lemonade.\n";
            Instructions = Instructions + "Read the weather report every day! When the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly. \n";
            Instructions = Instructions + " Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade.\n";
            Instructions = Instructions + "Lastly, set your price and sell your lemonade at the stand. Try changing up the price based on the weather conditions as well.\n";
            Instructions = Instructions + "At the end of the game, you'll see how much money you made. Write it down and play again to try and beat your score!\n\n";

           
            Console.WriteLine(Instructions);
            Game game = new Game();
            do
            {
                game.RunGame();
            }
            while (Shopping.GetInput("Would you like to play again? <yes/no>", "yes/no") == "yes") ;
        }
    }
}

    
