using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    internal class Game
    {
        public Dictionary<int,Player> players;

        public Game()
        {
            players = new Dictionary<int,Player>();
        }

        public void AddPlayer(Player p)
        {

            int UID = this.GenerateID();
            if (players.ContainsKey(UID)){
                while (players.ContainsKey(UID))
                {
                    UID = this.GenerateID();
                }
            }
            p.game = this; //player needs to know what game it's part of
            p.UID = UID; //set player's UID
            players.Add(UID, p); 
        }
        private int GenerateID() //just here in case someone would ever try to add two people with the same name to the game
        {
            Random rnd = new Random();
            return rnd.Next(0, 99999);
        }
    }
}
