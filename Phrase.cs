using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_games
{
    class Phrase
    {
        private string content = "";
        private string category = "";
        private string hiddenPhraseToDisplay = "";
        private string hiddenPhrase = "";

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
            get { return hiddenPhraseToDisplay; }
        }
        void GenerateHiddenPhrase()
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == ' ')
                    hiddenPhrase += ' ';
                else
                    hiddenPhrase += '_';
            }
            hiddenPhraseToDisplay = ConvertToDisplayFormat(hiddenPhrase);
        }

        string ConvertToDisplayFormat(string s)
        {
            string retVal = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    retVal += ' ';
                else
                    retVal += s[i] + " ";
            }
            retVal.Remove(retVal.Length - 1);
            return retVal;
        }
        
        public void UncoverCharacters(char c)
        {
            char[] hiddenPhraseChars = hiddenPhrase.ToCharArray();
            for (int i = 0; i < hiddenPhrase.Length; i++)
                if (content[i] == c)
                    hiddenPhraseChars[i] = c;
            hiddenPhrase = new string(hiddenPhraseChars);
            hiddenPhraseToDisplay = ConvertToDisplayFormat(hiddenPhrase);
        }

        public bool IsDecrypted()
        {
            for (int i = 0; i < hiddenPhrase.Length; i++)
                if (hiddenPhrase[i] == '_')
                    return false;
            return true;
        }
    }
}
