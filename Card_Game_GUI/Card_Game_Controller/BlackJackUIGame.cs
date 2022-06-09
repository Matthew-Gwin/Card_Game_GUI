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
        public List<BlackJackUIPlayer> BpPlayers { get; set; }
        public Card_Game.BlackJack UIGame { get; set; }

        public BlackJackUIGame(BlackJack game)
        {
            this.UIGame = game;
            this.BpPlayers = new List<BlackJackUIPlayer>();
        }


        public void UIPlayPressed()
        {
            Trace.WriteLine("Players in the game: ");
            foreach (Card_Game.Player Bp in UIGame.players.Values)
            {
                Trace.WriteLine(Bp);
            }
        }
        public void UILeavePressed(BlackJackUIPlayer Bp)
        {
      
        }
        public void RemovePlayerFromGame(BlackJackUIPlayer Bp)
        {
            this.BpPlayers.Remove(Bp);
        }

        public void UIHitPressed(BlackJackUIPlayer Bp)
        {
            Trace.WriteLine(Bp.player.name + " Pressed Hit!");
            this.UIGame.PlayerHit(Bp.player);
        }

        public void UIStandPressed(BlackJackUIPlayer Bp)
        {
            Trace.WriteLine(Bp.player.name + " Pressed Stand!");
            Bp.isStanding = false;
        }

        public void UIAddBpPlayer(BlackJackUIPlayer Bp)
        {
            this.BpPlayers.Add(Bp);
            this.UIGame.AddPlayer(Bp.player);
        }
    }
}
