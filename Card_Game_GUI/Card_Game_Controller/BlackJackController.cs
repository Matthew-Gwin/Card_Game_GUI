using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game_GUI.Card_Game_Controller
{
    internal class BlackJackController
    {
        public BlackJackController()
        {
            Console.WriteLine("Hello World");
        }

        public static Card_Game.BlackJack init()
        {
            return new Card_Game.BlackJack();
        }
    }
}
