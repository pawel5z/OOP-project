using System.Windows;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy WinWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        private readonly ISimpleGame invokedBy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispString"></param>
        /// <param name="invokedBy">The window implementing ISimpleGame that called this constructor.</param>
        public GameOverWindow(string dispString, ISimpleGame invokedBy)
        {
            this.invokedBy = invokedBy;
            InitializeComponent();
            EndTextBlock.Text = dispString;
        }

        /// <summary>
        /// Close @invokedBy game window, this window and create MainMenuWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            (invokedBy as Window).Close();
            Close();
        }

        /// <summary>
        /// Reset just ended game and initiate it from the beggining.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            invokedBy.Reset();
            invokedBy.Init();
            Close();
        }
    }
}
