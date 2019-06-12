using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Simple_games
{
    public partial class TicTacToeWindow : Window, ISimpleGame
    {
        private readonly List<Player> players = new List<Player>
        {
            new Player("X", Brushes.DarkOrange),
            new Player("O", Brushes.Purple)
        };
        private int curPlrNr = 0;
        private int occupiedFields = 0;

        public TicTacToeWindow()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Handle the one of the board buttons click event.
        /// </summary>
        /// <param name="sender">This will always be one of 9 board buttons.</param>
        /// <param name="e"></param>
        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            Button boardButton = (Button)sender;
            PlaceSymbol(boardButton, players[curPlrNr]);
            occupiedFields++;
            if (CheckForWin(players[curPlrNr].PlayerSymbol, (UniformGrid)boardButton.Parent))
            {
                GameOver("\'" + players[curPlrNr].PlayerSymbol + "\'" + " wins!");
            }
            else if (occupiedFields == 9)
                GameOver("Draw!");
            curPlrNr = (curPlrNr + 1) % players.Count;
            UpdateCurPlrTextBlock(players[curPlrNr].PlayerSymbol, players[curPlrNr].PlayerBrush);
            boardButton.IsEnabled = false; /// deactivate button in order not to take care of it anymore (it has already got 'X' or 'O')
        }

        /// <summary>
        /// Check for three in row/column/diagonal symbols of player who placed his symbols last.
        /// </summary>
        /// <param name="plrSym">Player who placed last symbol on the board i.e. he may be the winner.</param>
        /// <param name="boardGrid"></param>
        /// <returns></returns>
        bool CheckForWin(string plrSym, UniformGrid boardGrid)
        {
            Button[,] boardButtons = new Button[3, 3];

            /// convert list of buttons to 2d array of buttons for more convenient usage
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

        private void GameOver(string dispString)
        {
            IsEnabled = false;
            GameOverWindow gameOverWindow = new GameOverWindow(dispString, this as ISimpleGame);
            gameOverWindow.Show();
        }

        /// <summary>
        /// Update upper text block informing about which player's turn is now.
        /// Set it's content and text color to the one connected with current player.
        /// </summary>
        /// <param name="plrSymbol"></param>
        /// <param name="plrBrush"></param>
        private void UpdateCurPlrTextBlock(string plrSymbol, Brush plrBrush)
        {
            curPlrTextBlock.Text = plrSymbol;
            curPlrTextBlock.Foreground = plrBrush;
        }

        /// <summary>
        /// Places current player's symbol on the board and sets its color to current player's color.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="plr"></param>
        private void PlaceSymbol(Button button, Player plr)
        {
            button.Content = plr.PlayerSymbol;
            button.Foreground = plr.PlayerBrush;
        }

        public void Init()
        {
            UpdateCurPlrTextBlock(players[curPlrNr].PlayerSymbol, players[curPlrNr].PlayerBrush);
        }

        /// <summary>
        /// Clear the board (buttons placed on a grid) and game status (occupiedFields).
        /// </summary>
        public void Reset()
        {
            occupiedFields = 0;
            curPlrNr = 0;
            UIElementCollection boardFields = BoardGrid.Children;
            for (int i = 0; i < boardFields.Count; i++)
            {
                boardFields[i].IsEnabled = true;
                (boardFields[i] as Button).Content = "";

            }
            IsEnabled = true;
        }
    }
}
