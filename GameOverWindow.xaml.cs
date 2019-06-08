using System.Windows;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy WinWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        private readonly ISimpleGame invokedBy;

        public GameOverWindow(string dispString, ISimpleGame invokedBy)
        {
            this.invokedBy = invokedBy;
            InitializeComponent();
            EndTextBlock.Text = dispString;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            (invokedBy as Window).Close();
            Close();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            invokedBy.Reset();
            invokedBy.Init();
            Close();
        }
    }
}
