using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
     internal class Player
    {
        public string name { get; }
        public int UID { get; set; }
        public bool isPlaying { get; set; }
        public Hand hand { get; set; }
        public Game game { get; set; } //game that the player is part of 
        
        public Player(string playerName)
        {
            this.isPlaying = true;
            this.hand = new Hand();
            this.name = playerName;
        }
        public override String ToString()
        {
            return this.name + "'s Cards: " + this.hand.ToString();
        }
    }
}
