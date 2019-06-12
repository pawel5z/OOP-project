using System;
using System.Windows;

namespace Simple_games
{
    public partial class App : Application
    {
        public static Random rng;
        public App()
        {
            rng = new Random();
        }

        /// <summary>
        /// Display message about unhandled exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occured" + e.Exception.Message);
            e.Handled = true;
        }
    }
}
