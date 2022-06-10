using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Card_Game;

namespace Card_Game_GUI.Card_Game_Controller
{
    internal class BlackJackUIGame 
    {
        public List<BlackJackUIPlayer> bjplayers { get; set; }
        public Card_Game.BlackJack UIGame { get; set; }

        public BlackJackUIGame(BlackJack game)
        {
            this.UIGame = game;
            this.bjplayers = new List<BlackJackUIPlayer>();
        }


        public void UIPlayPressed()
        {
            
            Trace.WriteLine("Players in the game: ");
            foreach (Card_Game.Player Bp in UIGame.players.Values)
            {
                //UIGame.AddPlayer(Bp);
                Trace.WriteLine("Dealing two cards to " + Bp.name);
                UIGame.initial_deal(Bp);
                Trace.WriteLine(Bp);
            }
        }
        public void UILeavePressed(BlackJackUIPlayer Bp)
        {
            Trace.WriteLine(Bp.player.name + " left the game.");
        }
        public void RemovePlayerFromGame(BlackJackUIPlayer Bp)
        {
            this.bjplayers.Remove(Bp);
        }

        public void UIHitPressed(BlackJackUIPlayer Bp)
        {
            Trace.WriteLine(Bp.player.name + " Pressed Hit! Deck: " + Bp.player.hand + " Score: " + Bp.player.hand.Score());
            this.UIGame.PlayerHit(Bp.player);
            //Trace.WriteLine(Bp.player.hand.ToString());
        }

        public void UIStandPressed(BlackJackUIPlayer Bp)
        {
            Trace.WriteLine(Bp.player.name + " Pressed Stand!");
            Bp.isStanding = false;
        }

        public void UIAddBpPlayer(BlackJackUIPlayer Bp)
        {
            this.bjplayers.Add(Bp);
            this.UIGame.AddPlayer(Bp.player);
        }
        public override string ToString()
        {
            return String.Join(",", bjplayers);
        }
    }
}
