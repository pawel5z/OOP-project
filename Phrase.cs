using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_game
{
    class Phrase
    {
        string phrase = "";
        string category = "";
        string hiddenPhraseToDisplay = "";
        string hiddenPhrase = "";

        public Phrase(string phrase, string category)
        {
            this.phrase = phrase;
            this.category = category;
            GenerateHiddenPhrase();
        }

        public string GetPhraseStr()
        { return phrase; }

        public string GetCategoryStr()
        { return category; }

        public string GetHiddenPhraseToDisplayStr()
        { return hiddenPhraseToDisplay; }

        void GenerateHiddenPhrase()
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ')
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
                if (phrase[i] == c)
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
