using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    internal class Hand : Deck // Hand extends Deck
    {
        //private List<Card> hand; //might not need this 
        
        public Hand() : base(false) { }        //call deck constructor (hand is basically the same thing as a deck) to create blank Hand

        public int Score()
        {
            int sum = 0;
            foreach (Card c in cards)
            {
                if (c == null) break;
                sum += c.value;
            }
            return sum;
        }
        public override String ToString()
        {
            return String.Join(", ", base.ToString() + " | Score: " + this.Score());
        }

    }
}
