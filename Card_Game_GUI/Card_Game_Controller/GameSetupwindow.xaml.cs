using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Card_Game;

namespace Card_Game_GUI.Card_Game_Controller
{
    /// <summary>
    /// Interaction logic for GameSetupWindow.xaml
    /// </summary>
    public partial class GameSetupWindow : Window
    {

        private List<BlackJackUIPlayer> playerList;
        private BlackJackUIGame game;

        public GameSetupWindow()
        {
            playerList = new List<BlackJackUIPlayer>();
            game = new BlackJackUIGame(new BlackJack());
            InitializeComponent();
        }
        private void Button_Add_To_Game(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                //Trace.WriteLine("Testing output");
                lstNames.Items.Add(txtName.Text);
                Trace.WriteLine("Adding " + txtName.Text + " to the game.");
                playerList.Add(new BlackJackUIPlayer(txtName.Text));
                txtName.Clear();
            }

        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            
            if (playerList.Count == 0)
            {
                string warning = "You need at least one bjplayer in the Game!";
                createWarningMsgBox(warning);
                Trace.WriteLine(warning);
                return;
            }
            

            foreach (BlackJackUIPlayer Bp in playerList)
            {
                //game.bjplayers.Add(Bp);
                Trace.WriteLine("Adding: " + Bp.player.name + " To the game");
                game.UIGame.AddPlayer(Bp.player);
                Trace.WriteLine(game.UIGame.ToString());
                
            }
            this.game.UIPlayPressed();
            //Trace.WriteLine(game);
            //BlackJackGameWindow nextStep = new BlackJackGameWindow(game);
            this.Close();
            display_players();

            //nextStep.Show();

        }
        private void display_players()
        {
            foreach (BlackJackUIPlayer p in this.playerList)
            {
                PlayerViewWindow pvw = new PlayerViewWindow(p, game);
                pvw.Show();
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void createWarningMsgBox(string content, string label = "BlackJack")
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(content, label, button, icon, MessageBoxResult.Yes);
            //return result;
        }
    }
}
