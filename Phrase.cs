namespace Simple_games
{
    class Phrase
    {
        private readonly string content = "";
        private readonly string category = "";
        private string hiddenContentToDisplay = "";
        private string hiddenContent = "";

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

        public void UncoverCharacters(char c)
        {
            char[] hiddenPhraseChars = hiddenContent.ToCharArray();
            for (int i = 0; i < hiddenContent.Length; i++)
                if (content[i] == c)
                    hiddenPhraseChars[i] = c;
            hiddenContent = new string(hiddenPhraseChars);
            hiddenContentToDisplay = ConvertToDisplayFormat(hiddenContent);
        }

        public bool IsDecrypted()
        {
            for (int i = 0; i < hiddenContent.Length; i++)
                if (hiddenContent[i] == '_')
                    return false;
            return true;
        }
    }
}
