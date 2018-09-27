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
        }
        public static void WelcomeMessage()
        {
            WriteLine("         LEMONADE STAND GAME");
            WriteLine("=====================================\n");

        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

    
