﻿using System;
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

namespace Hangman_game
{
    /// <summary>
    /// Logika interakcji dla klasy WinWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        string dispString = "";
        Window toClose;
        MainMenuWindow mainMenuWindow;
        public GameOverWindow(string dispString, Window toClose)
        {
            this.toClose = toClose;
            this.dispString = dispString;
            InitializeComponent();
            EndTextBlock.Text = dispString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "MainMenuButton")
            {
                mainMenuWindow = new MainMenuWindow();
                mainMenuWindow.Show();
                toClose.Close();
                Close();
            }
        }
    }
}