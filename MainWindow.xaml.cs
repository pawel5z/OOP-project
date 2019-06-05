using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Simple_games
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Phrase phrase;
        StatusImageManager statusImageManager;
        
        public MainWindow()
        {
            PhrasesContainer phrasesContainer = new PhrasesContainer();
            statusImageManager = new StatusImageManager();
            do
            {
                phrase = phrasesContainer.RandomPhrase;
            }
            while (phrase.Content == "");
            InitializeComponent();
            statusImageManager.SetCurrentImage(StatusImage);
            PlacePhrase(phrase);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "GuessTextBox")
            {
                string guessStr = textBox.Text;
                textBox.IsEnabled = false;
                if (guessStr.Length == 1)
                {
                    string phraseStr = phrase.Content;
                    if (phraseStr.Contains(guessStr[0].ToString()))
                    {
                        phrase.UncoverCharacters(guessStr[0]);
                        PhraseTextBlock.Text = phrase.HiddenPhraseToDisplay;
                        if (phrase.IsDecrypted())
                        {
                            GameOver("You win!");
                        }
                    }
                    else if (!MissesTextBlock.Text.Contains(guessStr[0].ToString()))
                    {
                        MissesTextBlock.Text += guessStr[0].ToString() + " ";
                        statusImageManager.SetNextImage(StatusImage);
                        if (statusImageManager.GetCurrentImgNr() >= statusImageManager.GetMaxImgNr() - 1)
                        {
                            GameOver("You lose!");
                        }
                    }
                }
                textBox.Clear();
                textBox.IsEnabled = true;
            }
        }

        void PlacePhrase(Phrase phrase)
        {
            CategoryTextBlock.Text = phrase.Category;
            PhraseTextBlock.Text = phrase.HiddenPhraseToDisplay;
        }

        void GameOver(string dispString)
        {
            GuessTextBox.IsReadOnly = true;
            GameOverWindow gameOverWindow = new GameOverWindow(dispString, this);
            gameOverWindow.Show();
        }
    }
}