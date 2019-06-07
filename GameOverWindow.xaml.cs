using System.Windows;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy WinWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        private readonly ISimpleGame toClose;

        public GameOverWindow(string dispString, ISimpleGame toClose)
        {
            this.toClose = toClose;
            InitializeComponent();
            EndTextBlock.Text = dispString;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            (toClose as Window).Close();
            Close();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            toClose.Reset();
            Close();
        }
    }
}
