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

namespace Card_Game_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Card_Game_Controller.GameSetupWindow nextWindow = new Card_Game_Controller.GameSetupWindow();
            nextWindow.Show();
            //Card_Game.BlackJack game = Card_Game_Controller.BlackJackController.new_game();
            //Trace.WriteLine(game);
            //Trace.WriteLine("text");


        }
    }
}
