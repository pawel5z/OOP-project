using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_games
{
    /// <summary>
    /// Interface created for game windows.
    /// 
    /// Each class implementing ISimpleGame have to provide <c>Init()</c> and <c>Reset()</c> methods.
    /// Their task is to initialize game window accordingly at the beginning of the game and after restart.
    /// </summary>
    public interface ISimpleGame
    {
        void Init();
        void Reset();
    }
}
