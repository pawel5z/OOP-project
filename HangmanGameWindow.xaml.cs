using System.Windows;
using System.Windows.Controls;

namespace Simple_games
{
    /// <summary>
    /// Interaction logic for class HangmanGameWindow.
    /// </summary>
    public partial class HangmanGameWindow : Window, ISimpleGame
    {
        private Phrase phrase;
        private readonly StatusImageManager statusImageManager;

        public HangmanGameWindow()
        {
            statusImageManager = StatusImageManager.Instance();
            InitializeComponent();
            Reset();
            Init();
        }

        /// <summary>
        /// Handle user input from guessTextBox.
        /// </summary>
        /// <param name="sender">This will always be guessTextBox, because only it can call this method.</param>
        /// <param name="e"></param>
        private void GuessTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
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
                else if (!missesTextBlock.Text.Contains(guessStr[0].ToString()))
                {
                    missesTextBlock.Text += guessStr[0].ToString() + " ";
                    statusImageManager.SetNextImage(StatusImage);
                    if (statusImageManager.IsLastImage())
                    {
                        GameOver("You lose!");
                    }
                }
            }
            textBox.Clear();
            textBox.IsEnabled = true;
        }

        void PlacePhrase(Phrase phrase)
        {
            CategoryTextBlock.Text = phrase.Category;
            PhraseTextBlock.Text = phrase.HiddenPhraseToDisplay;
        }

        void GameOver(string dispString)
        {
            IsEnabled = false;
            GameOverWindow gameOverWindow = new GameOverWindow(dispString, this);
            gameOverWindow.Show();
        }

        /// <summary>
        /// Get random phrase from phrasesContainer.
        /// Place it in the HangManGameWindow.
        /// Set the first image from statusImageManager.
        /// </summary>
        public void Init()
        {
            PhrasesContainer phrasesContainer = PhrasesContainer.Instance();
            phrase = phrasesContainer.RandomPhrase;
            PlacePhrase(phrase);
            statusImageManager.SetNextImage(StatusImage);
        }

        /// <summary>
        /// Clear missedTextBlock.
        /// Set HangmanGameWindow enabled.
        /// </summary>
        public void Reset()
        {
            missesTextBlock.Text = "";
            statusImageManager.Reset();
            IsEnabled = true;
        }
    }
}