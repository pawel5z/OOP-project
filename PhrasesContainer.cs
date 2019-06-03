using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman_game
{
    class PhrasesContainer
    {
        int count = 0;
        //Random rng;

        public PhrasesContainer()
        {
            //rng = new Random();
            try
            {
                using (StreamReader sr = new StreamReader("phrases.dat"))
                {
                    while (!sr.EndOfStream)
                    {
                        string category = sr.ReadLine();
                        string phrase = sr.ReadLine();
                        count++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public Phrase RandomPhrase
        {
            get
            {
                int phraseNr = App.rng.Next(0, count);
                int i = 0;
                string category = "";
                string phrase = "";
                try
                {
                    using (StreamReader sr = new StreamReader("phrases.dat"))
                    {
                        while (!sr.EndOfStream && i < phraseNr)
                        {
                            category = sr.ReadLine();
                            phrase = sr.ReadLine();
                            i++;
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                return new Phrase(phrase, category);
            }
        }
    }


}
