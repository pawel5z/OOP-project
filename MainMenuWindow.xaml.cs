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
using System.Windows.Shapes;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        Window gameWindow;
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void HangmanGameButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow = new HangmanGameWindow();
            gameWindow.Show();
            Close();
        }

        private void TicTacToeButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow = new TicTacToeWindow();
            gameWindow.Show();
            Close();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
