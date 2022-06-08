using System;
using System.Linq;
using System.Collections.Generic;

namespace Card_Game
{
    internal class Setup
    {
        static void Main(string[] args)
        {

            //Deck d = new Deck(true); //creates standard deck of size 52 


            //LINQ in case we would ever need it
            /*
            Console.WriteLine("Daimond cards exclusively selected with LINQ");
            IEnumerable<Card> dmds = from c in d.cards where c.ToString().Contains("Diamonds") select c;

            foreach (Card card in dmds)
            {
                Console.WriteLine(card);
            }*/

            Player matt = new Player("Matt");
            Player yasmeen = new Player("Yasmeen");
            Player feiyang = new Player("Feiyang");
            
            //Game setup
            BlackJack game = new BlackJack();
            
            game.AddPlayer(matt);
            //game.AddPlayer(new Player("Matt")); //test UID work - you can add two players with the same name and they will be Unique in the game
            game.AddPlayer(yasmeen);
            game.AddPlayer(feiyang);

            /*Deck test = new Deck(true);

            Console.WriteLine(test);
            test.Shuffle();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(test); */

            game.PlayGame();
            //game.Automatic_Play(matt);
            //Console.WriteLine("Hello World!");
        }
    }
}
