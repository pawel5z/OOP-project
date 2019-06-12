using System.Windows.Media;

namespace Simple_games
{
    /// <summary>
    /// Class designed for TicTacToeWindow.
    /// </summary>
    class Player
    {
        private readonly string playerSymbol;
        private readonly Brush playerBrush;

        public Player(string symbol, Brush brush)
        {
            playerSymbol = symbol;
            playerBrush = brush;
        }

        public string PlayerSymbol
        { get { return playerSymbol; } }

        public Brush PlayerBrush
        { get { return playerBrush; } }
    }
}
