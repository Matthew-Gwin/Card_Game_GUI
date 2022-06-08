using System;
using System.Collections;
using System.Text;

namespace Card_Game
{
    internal class Card
    {
        public int value { get; set; }
        public string suit { get; set; }
        public String rank { get; set; }

        public Card(string rank, string suit, int value )
        {
            this.value = value;
            this.suit = suit;
            this.rank = rank;
        }
        public override String ToString()
        {
            return this.rank + " of " + this.suit + " " + this.value;
        }


    }


}
