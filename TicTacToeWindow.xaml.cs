using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Simple_games
{
    /// <summary>
    /// Interaction logic for TicTacToeWindow.xaml
    /// </summary>
    public partial class TicTacToeWindow : Window
    {
        private readonly List<string> playerSymbols = new List<string>
            {
                "X",
                "O"
            };
        private int curPlrSymNr = 0;

        public TicTacToeWindow()
        {
            InitializeComponent();
        }

        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            Button boardButton = (Button)sender;
            boardButton.Content = playerSymbols[curPlrSymNr];
            if (CheckForWin(playerSymbols[curPlrSymNr], (UniformGrid)boardButton.Parent))
            {
                GameOver(playerSymbols[curPlrSymNr] + " wins!");
            }
            curPlrSymNr = (curPlrSymNr + 1) % playerSymbols.Count;
            boardButton.IsEnabled = false; /// deactivate button in order not to take care of it anymore (it has already got 'X' or 'O')
        }

        bool CheckForWin(string plrSym, UniformGrid boardGrid)
        {
            Console.WriteLine("HERE I AM");

            Button[,] boardButtons = new Button[3, 3];
            for (int i = 0, j = 0, k = 0; k < boardGrid.Children.Count; k++)
            {
                boardButtons[i, j] = (Button)boardGrid.Children[k];
                if ((k + 1) % 3 == 0)
                {
                    i = 0;
                    j += 1;
                }
                else
                    i++;
            }

            /// check by columns
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((boardButtons[i, j].Content as string) != plrSym)
                        break;
                    else if (j == 2)
                        return true;
                }
            }

            /// check by rows
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((boardButtons[j, i].Content as string) != plrSym)
                        break;
                    else if (j == 2)
                        return true;
                }
            }

            /// check by diagonal (from upper-left corner to lower-right)
            for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
            {
                if ((boardButtons[i, j].Content as string) != plrSym)
                    break;
                else if (i == 2 && j == 2)
                    return true;
            }

            /// check by diagonal (from upper-right corner to lower-left)
            for (int i = 2, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if ((boardButtons[i, j].Content as string) != plrSym)
                    break;
                else if (i == 0 && j == 2)
                    return true;
            }

            return false;
        }
        void GameOver(string dispString)
        {
            GameOverWindow gameOverWindow = new GameOverWindow(dispString, this);
            gameOverWindow.Show();
        }
    }
}
