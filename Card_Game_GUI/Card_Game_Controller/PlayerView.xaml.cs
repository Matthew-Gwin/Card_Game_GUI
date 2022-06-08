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
        internal Card_Game.Player player; 
        internal Card_Game.BlackJack game; //game player is part of
        internal PlayerViewWindow(Card_Game.Player p, Card_Game.BlackJack g)
        {
            InitializeComponent();
            this.game = g;
            this.player = p;
            this.Title = p.name;
            this.Hand.IsEnabled = false;
            this.Score.IsEnabled = false;
            this.Hand.Text = p.hand.ToString();
            this.Score.Text = p.hand.Score().ToString();
        }

        private void GameHit(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(player.name + " Hit!");
            game.PlayerHit(player);
            Trace.WriteLine(player.hand);
        }

        private void GameStand(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void GameLeave(object sender, RoutedEventArgs e)
        {
            game.players.Remove(player.UID);
            this.Close();
        }
    }

}
