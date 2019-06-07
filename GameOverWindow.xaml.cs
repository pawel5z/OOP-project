using System.Windows;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy WinWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        private readonly Window toClose;
        MainMenuWindow mainMenuWindow;
        public GameOverWindow(string dispString, Window toClose)
        {
            this.toClose = toClose;
            InitializeComponent();
            EndTextBlock.Text = dispString;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            toClose.Close();
            Close();
        }
    }
}
