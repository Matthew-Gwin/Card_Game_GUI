using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    internal class BlackJack : Game
    {

        private Deck gamecards;
        private Player dealer;
        public Dictionary<int, Player> out_of_round;
        
        public BlackJack() : base() //Extends game
        {
            out_of_round = new Dictionary<int, Player>();
            dealer = new Player("Dealer"); //Blackjack always has a dealer
            this.AddPlayer(dealer);
            gamecards = new Deck(true);
            //Console.WriteLine(gamecards);
        }

        public virtual void PlayGame()
        {          
            for (int i = 0; i < 52; i++)
            {
                gamecards.Shuffle();
            }

            while (true) // forever
            {
                if (out_of_round.Count == this.players.Count - 1) //only dealer left because we've skipped it this whole time
                {
                    Automatic_Play(dealer);
                    break;
                }
                
                foreach (Player p in this.players.Values)
                {
                    initial_deal(p);
                    if (p.name == "Dealer")
                    {
                        continue;
                    }
                    Console.WriteLine("------------------- " + p.name + " -------------------");
                    Console.WriteLine(p);

                    while (p.isPlaying)
                        {
                            bool won_or_lost = CheckPlayerStatus(p);
                            if (won_or_lost)
                            {
                                out_of_round.Add(p.UID, p);
                                break;
                            }

                            bool ask = AskPlayer(p);
                            if (ask)
                            {
                                this.PlayerHit(p);
                            }
                            else {
                                Console.WriteLine(p.name + " stands.");
                                p.isPlaying = false;
                                out_of_round.Add(p.UID, p); //add bjplayer to out_of_round
                                break;
                            }
                     }
                }
            }
            Console.WriteLine("################# Game Results #################");
            foreach (Player p in out_of_round.Values) //All players should be here when all either stand, bust, or have BlackJack.
            {    
                Console.WriteLine(p.name + " Score: " + p.hand.Score());
            }
        }

        public void initial_deal(Player p)
        {
            if (p.hand.cards.Count == 0)
            {
                for (int dealcount = 1; dealcount <= 2; dealcount++) //deal two cards to each bjplayer
                {
                    p.hand.AddTo(gamecards.Deal());
                }
            }
            else
            {
                return;
            }
        }

        public void Automatic_Play(Player p)
        {
            Console.WriteLine("------------------- " + p.name + " -------------------");
            //Console.WriteLine("To be implemented...");
            while (p.isPlaying)
            {
                if (p.hand.Score() <= 15)
                {
                    this.PlayerHit(p);
                     if (this.CheckPlayerStatus(p))
                    {
                        out_of_round.Add(p.UID, p);
                        break;
                    }
                }
                else
                {
                    out_of_round.Add(p.UID, p);
                    p.isPlaying = false;
                    Console.WriteLine(p.name + " Stands.");
                    break;
                }
            }
        }

        public bool CheckPlayerStatus(Player p) //returns true if a bjplayer has blackjack or busts (no longer playing in the round)
        {
            //Console.WriteLine("CheckPlayerStatus enter");
            bool result = false;
            if (p.hand.Score() == 21)
            {
                Console.WriteLine(p.name + " has BlackJack!");
                //this.players.Remove(p.UID);
                //p.isPlaying = false;
                result = true;
            }
            if (p.hand.Score() > 21)
            {
                Console.WriteLine(p.name + " busts!");
                //this.players.Remove(p.UID);
                //p.isPlaying = false;
                result = true;
            }
            return result;
        }

        public void PlayerHit(Player p)
        {
            p.hand.AddTo(gamecards.Deal());
            Console.WriteLine(p.name + " Hits!");
            Console.WriteLine(p);
            //this.CheckPlayerStatus(p);
            
        }

        public bool AskPlayer(Player p) //Returns true for hit, false for stay
        {
            bool result = false;
            Boolean noResponse = true;
            while (noResponse)
            {
                Console.WriteLine("Would you like to hit or stand? (h/s):");

                // Create a string variable and get user input from the keyboard and store it in the variable
                string takeIn = Console.ReadLine();
                
                if (takeIn.ToLower() == "h")
                {
                    result = true;
                    noResponse = false;
                }
                else if(takeIn.ToLower() == "s"){
                    result = false;
                    noResponse = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            return result;
            
        }

    }
}
