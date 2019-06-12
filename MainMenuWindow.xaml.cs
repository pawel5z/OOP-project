using System.Windows;

namespace Simple_games
{
    public partial class MainMenuWindow : Window
    {
        private Window gameWindow;
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
