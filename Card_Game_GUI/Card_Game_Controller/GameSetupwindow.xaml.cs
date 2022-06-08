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

        private List<Player> playerList;
        private BlackJack game;

        public GameSetupWindow()
        {
            playerList = new List<Player>();
            game = new BlackJack();
            InitializeComponent();
        }
        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                //Trace.WriteLine("Testing output");
                lstNames.Items.Add(txtName.Text);
                Trace.WriteLine("Adding " + txtName.Text + " to the game.");
                playerList.Add(new Player(txtName.Text));
                txtName.Clear();
            }

        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            if (playerList.Count == 0)
            {
                string warning = "You need at least one player in the Game!";
                createWarningMsgBox(warning);
                Trace.WriteLine(warning);
                return;
            }
            //Card_Game.BlackJack game = Card_Game_Controller.BlackJackController.new_game();
            //Card_Game.BlackJack game = new Card_Game.BlackJack();
            foreach (Player player in playerList)
            {
                game.AddPlayer(player);
            }
            Trace.WriteLine(game);
            //BlackJackGameWindow nextStep = new BlackJackGameWindow(game);
            this.Close();
            display_players();
            //nextStep.Show();

        }
        private void display_players()
        {
            foreach (Player p in this.playerList)
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
