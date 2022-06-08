using System;
using System.Collections;
using System.Collections.Generic;
using Card_Game;
using System.Text;

namespace Card_Game
{
    internal class Deck {

        public List<Card> cards { get; }
        private int size { get; set;  }

        public Deck(bool init, bool ace_val = false)
        {
            this.cards = new List<Card>();
            if (init)
            {
                this.create(ace_val);
            }
            this.size = this.cards.Count;
        }
        public Deck() { this.size = 0; }


        public void Shuffle()
        {
            if (this.cards.Count == 0)
            {
                return; //can't shuffle empty Deck
            }
            Random rand = new Random();
            int r = rand.Next(0, this.cards.Count);
            for (int i = 0; i < this.cards.Count; i++)
            {
                Card temp = this.cards[i];
                this.cards[i] = this.cards[r]; //swap with random card
                this.cards[r] = temp;
            }
        }
        public Card Deal()
        {
            if (cards.Count == 0) return null; 
            int last = cards.Count - 1;
            Card ret = cards[last];
            this.cards.RemoveAt(last);
            this.size = this.cards.Count;
            return ret;

        }

        //Not sure if this belongs here
        private void create(bool ace) //if ace is true, it gets set to 1
        {
            string[] facecards = { "A", "J", "Q", "K" }; 
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            Card c = null;
            int faceCardValue = 10; //default

            foreach (string s in suits)
            {
                for (int j = 2; j <= 10; j++) //card and value
                {
                    this.AddTo(new Card(Convert.ToString(j), s, j));
                }
                //for (int k = 0; k < facecards.Length; k++)
                foreach (String fc in facecards)
                {
                    if (fc == "A")
                    {
                        if (ace) this.AddTo(new Card(fc, s, 1));
                        else this.AddTo(new Card(fc, s, 11));
                    }
                    else this.AddTo(new Card(fc, s, faceCardValue)); //assign facecards with 10 value to start


                }
            }


        }

        public void AddTo(Card c)
        {
            this.cards.Add(c);
            this.size = this.cards.Count;
        }

        public override string ToString()
        {
            return String.Join(", ", this.cards);
        }
    }
}
