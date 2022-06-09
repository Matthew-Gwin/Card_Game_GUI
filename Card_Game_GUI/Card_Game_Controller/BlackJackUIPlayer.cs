using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game_GUI.Card_Game_Controller
{
    internal class BlackJackUIPlayer
    {
        public Card_Game.Player player { get; set; }
        public bool isStanding { get; set; }
        public BlackJackUIPlayer(string name)
        {
            this.isStanding = false;
            player = new Card_Game.Player(name);
        }
    }
}
