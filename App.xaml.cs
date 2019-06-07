using System;
using System.Windows;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Random rng;
        public App()
        {
            rng = new Random();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occured" + e.Exception.Message);
            e.Handled = true;
        }
    }
}
