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
        MainWindow mainWindow;
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "HangmanGameButton")
            {
                mainWindow = new MainWindow();
                Console.WriteLine("WORKS");
                mainWindow.Show();
                Close();
            }
            else if (button.Name == "QuitButton")
            {
                Close();
            }
        }
    }
}
