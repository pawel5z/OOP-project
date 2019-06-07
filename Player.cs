using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simple_games
{
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
