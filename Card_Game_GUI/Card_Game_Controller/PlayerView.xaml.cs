using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Card_Game_GUI.Card_Game_Controller
{
    /// <summary>
    /// Interaction logic for PlayerViewWindow.xaml
    /// </summary>
    /// 

    public partial class PlayerViewWindow : Window
    {
        public string name;
        internal BlackJackUIPlayer bjplayer;
        internal BlackJackUIGame UIGame;
        //internal Card_Game.BlackJack game; //game bjplayer is part of
        internal PlayerViewWindow(BlackJackUIPlayer Bp, BlackJackUIGame g)
        {
            InitializeComponent();
            this.UIGame = g;
            this.bjplayer = Bp;
            this.Title = Bp.player.name;
            this.Hand.IsEnabled = false;
            this.Score.IsEnabled = false;
            this.Hand.Text = Bp.player.hand.ToString();
            this.Score.Text = Bp.player.hand.Score().ToString();
        }
        
        //This should all be implemented in the BlackJack game class

        private void GameHit(object sender, RoutedEventArgs e)
        {
            UIGame.UIHitPressed(bjplayer);
            this.Score.Text = bjplayer.player.hand.Score().ToString();
            this.Hand.Text = bjplayer.player.hand.ToString();
        }

        private void GameStand(object sender, RoutedEventArgs e)
        { 
            UIGame.UIStandPressed(bjplayer);
        }

        private void GameLeave(object sender, RoutedEventArgs e)
        {
            //UIGame.bjplayers
            //UIGame.players.Remove(bjplayer.UID);
            UIGame.UILeavePressed(bjplayer);
            ///UIGame.RemovePlayerFromGame(bjplayer);
            this.Close();
        }

    }

}
