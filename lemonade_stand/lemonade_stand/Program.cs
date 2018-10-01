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
            Game game = new Game();
            do
            {
                game.RunGame();
            }
            while (Shopping.GetInput("Would you like to play again? <yes/no>", "yes/no") == "yes") ;
        }
    }
}

    
