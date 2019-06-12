namespace Simple_games
{
    class Phrase
    {
        private readonly string content = "";
        private readonly string category = "";

        /// <summary>
        /// @content with each non-whitespace character replaced by '_'.
        /// </summary>
        private string hiddenContent = "";

        /// <summary>
        /// @hiddenContent with additional space character inserted between each pair of '_'.
        /// Made for easier and clearer display.
        /// </summary>
        private string hiddenContentToDisplay = "";

        public Phrase(string phrase, string category)
        {
            this.content = phrase;
            this.category = category;
            GenerateHiddenPhrase();
        }

        public string Content
        {
            get { return content; }
        }

        public string Category
        {
            get { return category; }
        }

        public string HiddenPhraseToDisplay
        {
            get { return hiddenContentToDisplay; }
        }

        void GenerateHiddenPhrase()
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == ' ')
                    hiddenContent += ' ';
                else
                    hiddenContent += '_';
            }
            hiddenContentToDisplay = ConvertToDisplayFormat(hiddenContent);
        }

        /// <summary>
        /// Insert space between each pair of '_' in s string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>s string with '_' inserted between each pair of '_'.</returns>
        string ConvertToDisplayFormat(string s)
        {
            string retVal = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    retVal += " ";
                else
                    retVal += s[i] + " ";
            }
            return retVal;
        }

        /// <summary>
        /// Find positions in @hiddenContent which represent c character in @content and set them to this character.
        /// Using char[], because there isn't possibility to modify single string characters. :(
        /// </summary>
        /// <param name="c"></param>
        public void UncoverCharacters(char c)
        {
            char[] hiddenPhraseChars = hiddenContent.ToCharArray();
            for (int i = 0; i < hiddenContent.Length; i++)
                if (content[i] == c)
                    hiddenPhraseChars[i] = c;
            hiddenContent = new string(hiddenPhraseChars);
            hiddenContentToDisplay = ConvertToDisplayFormat(hiddenContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if @hiddenContent doesn't contain any '_' characters. False in other case.</returns>
        public bool IsDecrypted()
        {
            for (int i = 0; i < hiddenContent.Length; i++)
                if (hiddenContent[i] == '_')
                    return false;
            return true;
        }
    }
}
